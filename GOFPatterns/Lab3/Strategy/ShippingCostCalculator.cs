using System;

namespace Lab2.Strategy
{
    public class ShippingCostCalculator
    {
        private IShippingStrategy _strategy;

        public ShippingCostCalculator(IShippingStrategy strategy)
        {
            _strategy = strategy;
        }

        public string StrategyName => _strategy == null ? "None" : _strategy.Name;

        public void SetStrategy(IShippingStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal Calculate(decimal orderTotal)
        {
            if (_strategy == null)
            {
                Console.WriteLine("No strategy assigned.");
                return 0m;
            }

            return _strategy.Calculate(orderTotal);
        }
    }
}
