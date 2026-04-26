namespace Lab2.Strategy
{
    public class StandardShippingStrategy : IShippingStrategy
    {
        public string Name => "Standard";

        public decimal Calculate(decimal orderTotal)
        {
            return 5m;
        }
    }
}
