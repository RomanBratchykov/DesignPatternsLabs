namespace Lab2.Mediator
{
    public interface IChatMediator
    {
        void Register(ChatUser user);
        void Send(string from, string to, string message);
        void Broadcast(string from, string message);
    }
}