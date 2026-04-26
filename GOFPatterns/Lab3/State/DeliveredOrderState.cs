using System;

namespace Lab2.State
{
    public class DeliveredOrderState : IOrderState
    {
        public void Handle(OrderContext context)
        {
            Console.WriteLine($"Order {context.OrderId}: delivered. No further transitions.");
        }
    }
}
