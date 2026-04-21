namespace Lab2.ChainOfResponsibility
{
    public abstract class OrderHandlerBase : IOrderHandler
    {
        private IOrderHandler _next;

        public IOrderHandler SetNext(IOrderHandler next)
        {
            _next = next;
            return next;
        }

        public abstract void Handle(OrderRequest request);

        protected void HandleNext(OrderRequest request)
        {
            if (_next != null)
            {
                _next.Handle(request);
            }
        }
    }
}
