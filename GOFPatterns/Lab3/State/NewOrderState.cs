using System;

namespace Lab2.State
{
    public class NewOrderState : IOrderState
    {
        public void Handle(OrderContext context)
        {
            Console.WriteLine($"Order {context.OrderId}: created.");
            context.SetState(new PaidOrderState());
        }
    }
}
