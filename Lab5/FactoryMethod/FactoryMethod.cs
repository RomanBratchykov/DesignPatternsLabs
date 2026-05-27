namespace Lab5.FactoryMethod;

internal static class FactoryMethod
{
    public static void Run()
    {
        Console.WriteLine("Factory Method (functional)");

        Func<string, Func<Gadget>> factoryMethod = type =>
            type.ToLowerInvariant() switch
            {
                "phone" => () => new Gadget("Phone", () => Console.WriteLine("Using a phone.")),
                "laptop" => () => new Gadget("Laptop", () => Console.WriteLine("Using a laptop.")),
                _ => () => new Gadget("Unknown", () => Console.WriteLine("Unknown gadget."))
            };

        var creators = new[]
        {
            factoryMethod("phone"),
            factoryMethod("laptop"),
            factoryMethod("headphones")
        };

        foreach (var create in creators)
        {
            var gadget = create();
            Console.WriteLine($"Created: {gadget.Name}");
            gadget.Use();
        }
    }

    private record Gadget(string Name, Action Use);
}
