namespace Lab2.Visitor
{
    public class ShippingItem : IVisitable
    {
        public string Method { get; }
        public decimal Cost { get; }

        public ShippingItem(string method, decimal cost)
        {
            Method = method;
            Cost = cost;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
