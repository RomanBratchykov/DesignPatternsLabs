using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using Lab7;

namespace Lab7.Tasks;

public sealed class Task06_FlatMapVsConcatMap : ILabTask
{
    public string Name => "3.2 flatMap vs concatMap";
    public string Description => "Розгортання страв у плоский потік та порівняння порядку.";

    private record FoodOrder(string OrderId, IReadOnlyList<string> Items);

    public void Run()
    {
        var orders = new List<FoodOrder>
        {
            new("ZAM-01", new List<string> { "Піца Маргарита", "Кола 0.5л" }),
            new("ZAM-02", new List<string> { "Борщ", "Вареники", "Компот" }),
            new("ZAM-03", new List<string> { "Суші-сет 20шт", "Місо-суп" })
        };

        Console.WriteLine("Частина A: flatMap (SelectMany)");
        orders
            .ToObservable()
            .SelectMany(order => order.Items.ToObservable())
            .Subscribe(item => Console.WriteLine($">> {item}"));

        Console.WriteLine();
        Console.WriteLine("Частина B: затримка 500 мс + порівняння порядку");

        Console.WriteLine("concatMap:");
        orders
            .ToObservable()
            .Select(ExpandWithDelay)
            .Concat()
            .Subscribe(item => Console.WriteLine($">> {item}"));

        Thread.Sleep(2500);

        Console.WriteLine();
        Console.WriteLine("flatMap:");
        orders
            .ToObservable()
            .SelectMany(ExpandWithDelay)
            .Subscribe(item => Console.WriteLine($">> {item}"));

        Thread.Sleep(2500);
    }

    private static IObservable<string> ExpandWithDelay(FoodOrder order)
    {
        return Observable.Timer(TimeSpan.FromMilliseconds(500))
            .SelectMany(_ => order.Items.ToObservable().Select(item => $"{item} ({order.OrderId})"));
    }
}
