using System;

namespace Lab2.ChainOfResponsibility
{
    public class StockCheckHandler : OrderHandlerBase
    {
        public override void Handle(OrderRequest request)
        {
            if (!request.InStock)
            {
                Console.WriteLine($"Order {request.OrderId}: rejected - item is out of stock.");
                return;
            }

            Console.WriteLine($"Order {request.OrderId}: stock check passed.");
            HandleNext(request);
        }
    }
}
