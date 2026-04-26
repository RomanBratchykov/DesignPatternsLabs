namespace Lab2.Visitor
{
    public class OrderItem : IVisitable
    {
        public string Name { get; }
        public decimal Price { get; }

        public OrderItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
