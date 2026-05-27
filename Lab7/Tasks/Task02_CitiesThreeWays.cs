using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reactive.Linq;
using Lab7;

namespace Lab7.Tasks;

public sealed class Task02_CitiesThreeWays : ILabTask
{
    public string Name => "1.2 Міста: for / LINQ / Rx";
    public string Description => "Фільтр \"К\", upper-case і сортування трьома підходами.";

    public void Run()
    {
        var cities = new List<string>
        {
            "Київ",
            "Харків",
            "Одеса",
            "Дніпро",
            "Запоріжжя",
            "Кривий Ріг",
            "Миколаїв",
            "Херсон",
            "Кропивницький",
            "Черкаси",
            "Суми",
            "Хмельницький",
            "Чернівці",
            "Каховка"
        };

        var culture = CultureInfo.GetCultureInfo("uk-UA");
        var comparer = StringComparer.Create(culture, ignoreCase: false);

        var loopResult = new List<string>();
        foreach (var city in cities)
        {
            if (city.StartsWith("К", StringComparison.CurrentCulture))
            {
                loopResult.Add(city.ToUpper(culture));
            }
        }
        loopResult.Sort(comparer);

        var linqResult = cities
            .Where(city => city.StartsWith("К", StringComparison.CurrentCulture))
            .Select(city => city.ToUpper(culture))
            .OrderBy(city => city, comparer)
            .ToList();

        var rxResult = cities
            .ToObservable()
            .Where(city => city.StartsWith("К", StringComparison.CurrentCulture))
            .Select(city => city.ToUpper(culture))
            .ToList()
            .Select(list => list.OrderBy(city => city, comparer).ToList())
            .Wait();

        Print("Імперативний", loopResult);
        Print("Функціональний (LINQ)", linqResult);
        Print("Реактивний (Rx)", rxResult);
    }

    private static void Print(string title, IEnumerable<string> items)
    {
        Console.WriteLine(title);
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }
}
