using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Lab7;

namespace Lab7.Tasks;

public sealed class Task03_AtmObservable : ILabTask
{
    public string Name => "2.1 Перший Observable (банкомат)";
    public string Description => "Створення Observable зі списком кроків і підписником (Observer).";

    public void Run()
    {
        var steps = new[]
        {
            "Вставте картку",
            "Введіть PIN-код",
            "Оберіть суму: 500 грн",
            "Видача готівки...",
            "Дякуємо! Заберіть картку"
        };

        var atm = Observable.Create<string>(observer =>
        {
            foreach (var step in steps)
            {
                observer.OnNext(step);
            }

            observer.OnCompleted();
            return Disposable.Empty;
        });

        Console.WriteLine("[БАНКОМАТ] Сесію розпочато");
        using var subscription = atm.Subscribe(
            step => Console.WriteLine($">> {step}"),
            ex => Console.WriteLine($"[БАНКОМАТ] Помилка: {ex.Message}"),
            () => Console.WriteLine("[БАНКОМАТ] Сесію завершено"));
    }
}
