using System;

namespace Lab2.ChainOfResponsibility
{
    public class ShippingHandler : OrderHandlerBase
    {
        public override void Handle(OrderRequest request)
        {
            Console.WriteLine($"Order {request.OrderId}: approved for shipping.");
        }
    }
}
