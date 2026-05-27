using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using Lab7;

namespace Lab7.Tasks;

public sealed class Task09_SchedulersPhoto : ILabTask
{
    public string Name => "5.1 subscribeOn + observeOn";
    public string Description => "Зміна планувальників для завантаження, стиснення та відображення.";

    public void Run()
    {
        var images = new[] { "photo_1.jpg", "photo_2.jpg", "photo_3.jpg" };
        var ioScheduler = TaskPoolScheduler.Default;
        var computationScheduler = NewThreadScheduler.Default;
        var trampolineScheduler = CurrentThreadScheduler.Instance;

        images
            .ToObservable()
            .SubscribeOn(ioScheduler)
            .Select(DownloadImage)
            .Do(image => Console.WriteLine($"{ThreadLabel("io")} [ЗАВАНТ] Завантаження: {image}"))
            .ObserveOn(computationScheduler)
            .Select(CompressImage)
            .Do(image => Console.WriteLine($"{ThreadLabel("computation")} [СТИСК] Стиснення: {image}"))
            .ObserveOn(trampolineScheduler)
            .Subscribe(image => Console.WriteLine($"{ThreadLabel("main")} [ФОТО] Відображення: {image}"));

        Thread.Sleep(10_000);
    }

    private static string DownloadImage(string name)
    {
        Thread.Sleep(1000);
        return name;
    }

    private static string CompressImage(string name)
    {
        Thread.Sleep(500);
        return name;
    }

    private static string ThreadLabel(string label)
    {
        return $"[{label}-{Thread.CurrentThread.ManagedThreadId}]";
    }
}
