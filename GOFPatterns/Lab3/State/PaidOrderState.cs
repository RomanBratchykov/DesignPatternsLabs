using System;

namespace Lab2.State
{
    public class PaidOrderState : IOrderState
    {
        public void Handle(OrderContext context)
        {
            Console.WriteLine($"Order {context.OrderId}: payment received.");
            context.SetState(new ShippedOrderState());
        }
    }
}
