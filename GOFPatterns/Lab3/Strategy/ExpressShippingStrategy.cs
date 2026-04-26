using System;

namespace Lab2.Strategy
{
    public class ExpressShippingStrategy : IShippingStrategy
    {
        public string Name => "Express";

        public decimal Calculate(decimal orderTotal)
        {
            return Math.Max(10m, orderTotal * 0.08m);
        }
    }
}
