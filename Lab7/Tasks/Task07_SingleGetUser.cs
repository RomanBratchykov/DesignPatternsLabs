using System;
using System.Reactive.Linq;
using Lab7;

namespace Lab7.Tasks;

public sealed class Task07_SingleGetUser : ILabTask
{
    public string Name => "4.1 Single (getUserById)";
    public string Description => "IObservable як Single: успіх при id > 0 та помилка при id <= 0.";

    public void Run()
    {
        GetUserById(42).Subscribe(
            user => Console.WriteLine($"(+) Знайдено: {user}"),
            ex => Console.WriteLine($"(-) Помилка: {ex.Message}"));

        GetUserById(-1).Subscribe(
            user => Console.WriteLine($"(+) Знайдено: {user}"),
            ex => Console.WriteLine($"(-) Помилка: {ex.Message}"));
    }

    private static IObservable<string> GetUserById(int id)
    {
        if (id <= 0)
        {
            return Observable.Throw<string>(new ArgumentOutOfRangeException(nameof(id), "ID не може бути від'ємним або нульовим"));
        }

        return Observable.Return($"Користувач #{id}: Іван Франко");
    }
}
