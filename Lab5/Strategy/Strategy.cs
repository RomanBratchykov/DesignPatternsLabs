namespace Lab5.Strategy;

internal static class Strategy
{
    public static void Run()
    {
        Console.WriteLine("Strategy (functional)");

        var orderTotal = 120m;
        var strategies = new Dictionary<string, Func<decimal, decimal>>(StringComparer.OrdinalIgnoreCase)
        {
            ["standard"] = total => 5m,
            ["express"] = total => Math.Max(10m, total * 0.08m),
            ["economy"] = total => Math.Max(2m, total * 0.03m)
        };

        Console.WriteLine($"Order total: {orderTotal:C}");
        PrintShipping("standard", strategies, orderTotal);
        PrintShipping("express", strategies, orderTotal);
    }

    private static void PrintShipping(
        string name,
        IReadOnlyDictionary<string, Func<decimal, decimal>> strategies,
        decimal orderTotal)
    {
        if (!strategies.TryGetValue(name, out var strategy))
        {
            Console.WriteLine($"Unknown strategy: {name}");
            return;
        }

        var cost = strategy(orderTotal);
        Console.WriteLine($"{name} shipping: {cost:C}");
    }
}
