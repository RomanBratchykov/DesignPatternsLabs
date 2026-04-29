using System;

namespace Lab2.Mediator
{
    public class ChatUser
    {
        private IChatMediator? _mediator;

        public string Name { get; }

        public ChatUser(string name)
        {
            Name = name;
        }

        public void SetMediator(IChatMediator mediator)
        {
            _mediator = mediator;
        }

        public void SendTo(string to, string message)
        {
            if (_mediator == null)
            {
                Console.WriteLine($"{Name} is not connected to a chat room.");
                return;
            }

            Console.WriteLine($"{Name} -> {to}: {message}");
            _mediator.Send(Name, to, message);
        }

        public void SendBroadcast(string message)
        {
            if (_mediator == null)
            {
                Console.WriteLine($"{Name} is not connected to a chat room.");
                return;
            }

            Console.WriteLine($"{Name} to all: {message}");
            _mediator.Broadcast(Name, message);
        }

        public void Receive(string from, string message)
        {
            Console.WriteLine($"{Name} received from {from}: {message}");
        }
    }
}