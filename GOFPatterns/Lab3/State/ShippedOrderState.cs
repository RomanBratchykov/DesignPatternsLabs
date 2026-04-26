using System;

namespace Lab2.State
{
    public class ShippedOrderState : IOrderState
    {
        public void Handle(OrderContext context)
        {
            Console.WriteLine($"Order {context.OrderId}: shipped.");
            context.SetState(new DeliveredOrderState());
        }
    }
}
