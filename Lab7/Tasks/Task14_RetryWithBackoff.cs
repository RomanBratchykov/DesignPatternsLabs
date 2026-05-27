using System;
using System.IO;
using System.Reactive.Linq;
using System.Threading;
using Lab7;

namespace Lab7.Tasks;

public sealed class Task14_RetryWithBackoff : ILabTask
{
    public string Name => "7.2 retry з exponential backoff";
    public string Description => "Повтор запиту з затримкою 1s/2s/4s до успіху або помилки.";

    public void Run()
    {
        var done = new ManualResetEventSlim(false);

        var pipeline = RetryWithBackoff(UnstableCall, maxAttempts: 4);

        pipeline.Subscribe(
            value => Console.WriteLine(value),
            ex =>
            {
                Console.WriteLine($"Error: {ex.Message}");
                done.Set();
            },
            () => done.Set());

        done.Wait();
    }

    private static IObservable<string> UnstableCall(int attempt)
    {
        Console.WriteLine($"[ПОВТОР] Спроба #{attempt}");

        if (attempt < 4)
        {
            return Observable.Throw<string>(new IOException("Connection timeout"));
        }

        return Observable.Return("(+) Відповідь API: {status: 'ok', data: [...]}" );
    }

    private static IObservable<string> RetryWithBackoff(Func<int, IObservable<string>> action, int maxAttempts)
    {
        return Observable.Defer(() =>
        {
            var attempt = 0;

            IObservable<string> Execute()
            {
                attempt++;
                return action(attempt).Catch<string, Exception>(ex =>
                {
                    if (attempt >= maxAttempts)
                    {
                        return Observable.Throw<string>(ex);
                    }

                    var delaySeconds = Math.Pow(2, attempt - 1);
                    Console.WriteLine($"Очікуємо {delaySeconds:0} сек перед повтором...");
                    var delay = TimeSpan.FromSeconds(delaySeconds);
                    return Observable.Timer(delay).SelectMany(_ => Execute());
                });
            }

            return Execute();
        });
    }
}
