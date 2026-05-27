using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using Lab7;

namespace Lab7.Tasks;

public sealed class Task10_ParallelSchedulers : ILabTask
{
    public string Name => "5.2 Паралельна обробка + Schedulers";
    public string Description => "Послідовне concatMap vs паралельне flatMap з вимірюванням часу.";

    private record ServiceCall(string ServiceName, int DelayMs);

    public void Run()
    {
        var services = new List<ServiceCall>
        {
            new("UserService", 800),
            new("OrderService", 1200),
            new("RecommendationService", 600)
        };

        Console.WriteLine("Послідовно (concatMap):");
        RunSequential(services);
        Console.WriteLine();
        Console.WriteLine("Паралельно (flatMap + Schedulers.io):");
        RunParallel(services);

        Thread.Sleep(3000);
    }

    private static void RunSequential(IReadOnlyList<ServiceCall> services)
    {
        var done = new ManualResetEventSlim(false);
        var stopwatch = Stopwatch.StartNew();

        Observable.Concat(services.Select(CallService))
            .Subscribe(
                result => Console.WriteLine(result),
                ex =>
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                    done.Set();
                },
                () =>
                {
                    stopwatch.Stop();
                    Console.WriteLine($"Загальний час (послідовно): {stopwatch.ElapsedMilliseconds} мс");
                    done.Set();
                });

        done.Wait();
    }

    private static void RunParallel(IReadOnlyList<ServiceCall> services)
    {
        var done = new ManualResetEventSlim(false);
        var stopwatch = Stopwatch.StartNew();

        Observable.Merge(services.Select(service => CallService(service).SubscribeOn(TaskPoolScheduler.Default)))
            .Subscribe(
                result => Console.WriteLine(result),
                ex =>
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                    done.Set();
                },
                () =>
                {
                    stopwatch.Stop();
                    Console.WriteLine($"Загальний час (паралельно): {stopwatch.ElapsedMilliseconds} мс");
                    done.Set();
                });

        done.Wait();
    }

    private static IObservable<string> CallService(ServiceCall service)
    {
        return Observable.Start(() =>
        {
            var timer = Stopwatch.StartNew();
            Thread.Sleep(service.DelayMs);
            timer.Stop();
            return $"{ThreadLabel()} (+) {service.ServiceName} відповів за {timer.ElapsedMilliseconds} мс";
        });
    }

    private static string ThreadLabel()
    {
        return $"[io-{Thread.CurrentThread.ManagedThreadId}]";
    }
}
