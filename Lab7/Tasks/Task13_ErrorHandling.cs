using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Lab7;

namespace Lab7.Tasks;

public sealed class Task13_ErrorHandling : ILabTask
{
    public string Name => "7.1 onErrorReturn / onErrorResumeNext";
    public string Description => "Відновлення після помилки через Catch та OnErrorResumeNext.";

    public void Run()
    {
        var currencyService = Observable.Create<string>(observer =>
        {
            observer.OnNext("USD -> UAH: 41.50");
            observer.OnNext("EUR -> UAH: 44.20");
            observer.OnError(new Exception("Сервіс тимчасово недоступний"));
            observer.OnNext("GBP -> UAH: 52.10");
            observer.OnCompleted();
            return Disposable.Empty;
        });

        Console.WriteLine("Сценарій A: onErrorReturn");
        currencyService
            .Catch(Observable.Return("Використовується кешований курс: USD -> UAH: 41.00"))
            .Subscribe(value => Console.WriteLine(value));

        Console.WriteLine();
        Console.WriteLine("Сценарій B: onErrorResumeNext");
        currencyService
            .OnErrorResumeNext(new[] { "JPY -> UAH: 0.27", "PLN -> UAH: 10.30" }.ToObservable())
            .Subscribe(value => Console.WriteLine(value));
    }
}
