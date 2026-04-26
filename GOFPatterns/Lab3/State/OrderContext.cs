using System;

namespace Lab2.State
{
    public class OrderContext
    {
        public string OrderId { get; }
        public IOrderState State { get; private set; }

        public OrderContext(string orderId)
        {
            OrderId = orderId;
            State = new NewOrderState();
        }

        public void SetState(IOrderState state)
        {
            State = state;
        }

        public void Next()
        {
            if (State == null)
            {
                Console.WriteLine("No state assigned.");
                return;
            }

            State.Handle(this);
        }
    }
}
