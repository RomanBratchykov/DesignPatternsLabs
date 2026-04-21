using System;

namespace Lab2.ChainOfResponsibility
{
    public class PaymentCheckHandler : OrderHandlerBase
    {
        public override void Handle(OrderRequest request)
        {
            if (!request.PaymentApproved)
            {
                Console.WriteLine($"Order {request.OrderId}: rejected - payment is not approved.");
                return;
            }

            Console.WriteLine($"Order {request.OrderId}: payment check passed.");
            HandleNext(request);
        }
    }
}
