using System.IO;

namespace Lab5.ExecuteAround;

internal static class ExecuteAround
{
    public static void Run()
    {
        Console.WriteLine("Execute Around (functional)");

        var text = "alpha\nbeta\ngamma";
        var lineCount = Using(
            acquire: () => new StringReader(text),
            use: reader =>
            {
                var count = 0;
                while (reader.ReadLine() != null)
                {
                    count++;
                }

                return count;
            });

        Console.WriteLine($"Lines: {lineCount}");
    }

    private static T ExecuteAroundCore<TResource, T>(
        Func<TResource> acquire,
        Func<TResource, T> use,
        Action<TResource> release)
    {
        var resource = acquire();
        try
        {
            return use(resource);
        }
        finally
        {
            release(resource);
        }
    }

    private static T Using<TResource, T>(Func<TResource> acquire, Func<TResource, T> use)
        where TResource : IDisposable
    {
        return ExecuteAroundCore(acquire, use, resource => resource.Dispose());
    }
}
