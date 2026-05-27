using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading;
using Lab7;

namespace Lab7.Tasks;

public sealed class Task04_ColdHotObservable : ILabTask
{
    public string Name => "2.2 Cold vs Hot observable";
    public string Description => "Порівняння холодного та гарячого Observable для спортивних результатів.";

    public void Run()
    {
        var results = new List<string>
        {
            "Динамо 2:1 Шахтар",
            "Шахтар 3:0 Металіст",
            "Дніпро 1:1 Зоря",
            "Карпати 0:2 Полісся",
            "Олександрія 2:2 Верес"
        };

        Console.WriteLine("Холодний Observable:");
        var cold = CreateResultsStream(results);
        cold.Subscribe(result => Console.WriteLine($"[Cold A] {result}"));

        Thread.Sleep(2000);

        cold.Subscribe(result => Console.WriteLine($"[Cold B] {result}"));

        Thread.Sleep(3500);

        Console.WriteLine();
        Console.WriteLine("Гарячий Observable:");
        var hot = CreateResultsStream(results).Publish();

        hot.Subscribe(result => Console.WriteLine($"[Hot A] {result}"));
        using var connection = hot.Connect();

        Thread.Sleep(2000);

        hot.Subscribe(result => Console.WriteLine($"[Hot B] {result}"));

        Thread.Sleep(3500);
    }

    private static IObservable<string> CreateResultsStream(IReadOnlyList<string> results)
    {
        return Observable.Interval(TimeSpan.FromMilliseconds(600))
            .Take(results.Count)
            .Select(index => results[(int)index]);
    }
}
