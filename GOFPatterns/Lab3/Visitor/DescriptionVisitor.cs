using System;

namespace Lab2.Visitor
{
    public class DescriptionVisitor : IVisitor
    {
        public void Visit(OrderItem item)
        {
            Console.WriteLine($"Item: {item.Name} ({item.Price:C})");
        }

        public void Visit(ShippingItem item)
        {
            Console.WriteLine($"Shipping: {item.Method} ({item.Cost:C})");
        }
    }
}
