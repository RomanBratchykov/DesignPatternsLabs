using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using Lab7;

namespace Lab7.Tasks;

public sealed class Task11_DebounceSearch : ILabTask
{
    public string Name => "6.1 debounce (пошук)";
    public string Description => "Відправка запиту лише після 300 мс паузи між введенням.";

    public void Run()
    {
        var subject = new Subject<string>();

        subject
            .Throttle(TimeSpan.FromMilliseconds(300))
            .Subscribe(query => Console.WriteLine($"[ПОШУК] Запит до API: \"{query}\""));

        Task.Run(() =>
        {
            var inputs = new[] { "К", "Ки", "Киї", "Київ", "Київ ", "Київ К", "Київ Ки" };
            var delays = new[] { 50, 80, 120, 100, 400, 60, 80 };

            for (var i = 0; i < inputs.Length; i++)
            {
                Thread.Sleep(delays[i]);
                subject.OnNext(inputs[i]);
            }

            Thread.Sleep(350);
            subject.OnCompleted();
        });

        Thread.Sleep(10_000);
    }
}
