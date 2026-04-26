namespace Lab2.Visitor
{
    public interface IVisitor
    {
        void Visit(OrderItem item);
        void Visit(ShippingItem item);
    }
}
