using System.Text;

namespace Lab5.Decorator;

internal static class Decorator
{
    public static void Run()
    {
        Console.WriteLine("Decorator (functional)");

        var dataSource = InMemoryDataSource();
        var decorate = Compose(CompressionDecorator(), EncryptionDecorator());
        var decorated = decorate(dataSource);

        var message = "Functional decorators";
        decorated.Write(message);
        var restored = decorated.Read();

        Console.WriteLine($"Original:  {message}");
        Console.WriteLine($"Restored:  {restored}");
    }

    private static DataSource InMemoryDataSource()
    {
        var buffer = string.Empty;
        return new DataSource(
            Write: data => buffer = data,
            Read: () => buffer);
    }

    private static Func<DataSource, DataSource> CompressionDecorator()
    {
        return source => new DataSource(
            Write: data =>
            {
                Console.WriteLine("[Compressing data...]");
                source.Write(Reverse(data));
            },
            Read: () =>
            {
                Console.WriteLine("[Decompressing data...]");
                return Reverse(source.Read());
            });
    }

    private static Func<DataSource, DataSource> EncryptionDecorator()
    {
        return source => new DataSource(
            Write: data =>
            {
                Console.WriteLine("[Encrypting data...]");
                var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
                source.Write(encoded);
            },
            Read: () =>
            {
                var encoded = source.Read();
                var bytes = Convert.FromBase64String(encoded);
                Console.WriteLine("[Decrypting data...]");
                return Encoding.UTF8.GetString(bytes);
            });
    }

    private static string Reverse(string input)
        => new string(input.Reverse().ToArray());

    private static Func<T, T> Compose<T>(Func<T, T> outer, Func<T, T> inner)
        => value => outer(inner(value));

    private record DataSource(Action<string> Write, Func<string> Read);
}
