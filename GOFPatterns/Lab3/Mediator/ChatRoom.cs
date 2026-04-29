using System;
using System.Collections.Generic;

namespace Lab2.Mediator
{
    public class ChatRoom : IChatMediator
    {
        private readonly Dictionary<string, ChatUser> _users = new Dictionary<string, ChatUser>(StringComparer.OrdinalIgnoreCase);

        public void Register(ChatUser user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Name))
            {
                return;
            }

            _users[user.Name] = user;
            user.SetMediator(this);
        }

        public void Send(string from, string to, string message)
        {
            if (string.IsNullOrWhiteSpace(to))
            {
                Broadcast(from, message);
                return;
            }

            if (_users.TryGetValue(to, out var recipient))
            {
                recipient.Receive(from, message);
                return;
            }

            Console.WriteLine($"[{from}] could not find recipient {to}.");
        }

        public void Broadcast(string from, string message)
        {
            foreach (var user in _users.Values)
            {
                if (string.Equals(user.Name, from, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                user.Receive(from, message);
            }
        }
    }
}