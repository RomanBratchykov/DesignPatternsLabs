namespace Lab2.Visitor
{
    public class PriceVisitor : IVisitor
    {
        public decimal Total { get; private set; }

        public void Visit(OrderItem item)
        {
            Total += item.Price;
        }

        public void Visit(ShippingItem item)
        {
            Total += item.Cost;
        }
    }
}
