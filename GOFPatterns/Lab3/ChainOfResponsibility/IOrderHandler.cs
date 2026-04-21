namespace Lab2.ChainOfResponsibility
{
    public interface IOrderHandler
    {
        IOrderHandler SetNext(IOrderHandler next);
        void Handle(OrderRequest request);
    }
}
