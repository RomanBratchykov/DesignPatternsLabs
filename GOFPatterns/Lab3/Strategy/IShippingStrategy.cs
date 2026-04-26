namespace Lab2.Strategy
{
    public interface IShippingStrategy
    {
        string Name { get; }
        decimal Calculate(decimal orderTotal);
    }
}
