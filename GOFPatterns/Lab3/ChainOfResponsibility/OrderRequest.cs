namespace Lab2.ChainOfResponsibility
{
    public class OrderRequest
    {
        public string OrderId { get; }
        public bool InStock { get; }
        public bool PaymentApproved { get; }

        public OrderRequest(string orderId, bool inStock, bool paymentApproved)
        {
            OrderId = orderId;
            InStock = inStock;
            PaymentApproved = paymentApproved;
        }
    }
}
