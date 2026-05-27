using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Lab7;

namespace Lab7.Tasks;

public sealed class Task08_MaybeCompletable : ILabTask
{
    public string Name => "4.2 Maybe + Completable";
    public string Description => "Maybe через Empty/DefaultIfEmpty та Completable-ланцюжок з токеном.";

    public void Run()
    {
        Console.WriteLine("Частина A: Maybe + defaultIfEmpty");

        FindInCache("user:1").Subscribe(
            value => Console.WriteLine($"[КЕШ (+)] Знайдено: {value}"),
            ex => Console.WriteLine($"[КЕШ (!)] Помилка: {ex.Message}"));

        FindInCache("user:2")
            .DefaultIfEmpty("Завантажено з БД")
            .Subscribe(
                value => Console.WriteLine($"[КЕШ (-)] Кеш-міс. Значення: {value}"),
                ex => Console.WriteLine($"[КЕШ (!)] Помилка: {ex.Message}"));

        FindInCache("user:error").Subscribe(
            value => Console.WriteLine($"[КЕШ (+)] Знайдено: {value}"),
            ex => Console.WriteLine($"[КЕШ (!)] Помилка: {ex.Message}"));

        Console.WriteLine();
        Console.WriteLine("Частина B: Completable + andThen()");

        Console.WriteLine("Успішна реєстрація:");
        RunRegistration(shouldFail: false);

        Console.WriteLine();
        Console.WriteLine("Реєстрація з помилкою:");
        RunRegistration(shouldFail: true);
    }

    private static IObservable<string> FindInCache(string key)
    {
        if (key == "user:1")
        {
            return Observable.Return("{'name':'Леся','age':28}");
        }

        if (key == "user:2")
        {
            return Observable.Empty<string>();
        }

        return Observable.Throw<string>(new Exception("Redis недоступний"));
    }

    private static void RunRegistration(bool shouldFail)
    {
        var registration = ValidateInput()
            .Concat(SaveToDatabase(shouldFail))
            .LastOrDefaultAsync()
            .SelectMany(_ => GenerateToken());

        registration.Subscribe(
            token => Console.WriteLine($"[ТОКЕН] Токен: {token}"),
            ex => Console.WriteLine($"(-) Помилка: {ex.Message}"),
            () => Console.WriteLine("(+) Реєстрацію завершено успішно!"));
    }

    private static IObservable<Unit> ValidateInput()
    {
        return Observable.Create<Unit>(observer =>
        {
            Console.WriteLine("[ПОШУК] Перевірка даних...");
            Console.WriteLine("(+) Дані валідні");
            observer.OnCompleted();
            return Disposable.Empty;
        });
    }

    private static IObservable<Unit> SaveToDatabase(bool shouldFail)
    {
        return Observable.Create<Unit>(observer =>
        {
            Console.WriteLine("[DB] Збереження в БД...");

            if (shouldFail)
            {
                observer.OnError(new InvalidOperationException("Помилка збереження"));
                return Disposable.Empty;
            }

            Console.WriteLine("(+) Збережено");
            observer.OnCompleted();
            return Disposable.Empty;
        });
    }

    private static IObservable<string> GenerateToken()
    {
        return Observable.Return("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.demo");
    }
}
