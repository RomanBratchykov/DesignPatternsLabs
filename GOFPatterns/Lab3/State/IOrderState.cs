namespace Lab2.State
{
    public interface IOrderState
    {
        void Handle(OrderContext context);
    }
}
