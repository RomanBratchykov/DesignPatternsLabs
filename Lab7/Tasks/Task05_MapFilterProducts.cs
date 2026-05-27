using System;
using System.Collections.Generic;
using System.Linq;
using Lab7;

namespace Lab7.Tasks;

public sealed class Task05_MapFilterProducts : ILabTask
{
    public string Name => "3.1 map + filter (товари)";
    public string Description => "Фільтр дорожче $100, конвертація в UAH і форматування.";

    private record Product(string Name, decimal PriceUsd);

    public void Run()
    {
        var usdToUah = 41.5m;
        var products = new List<Product>
        {
            new("Навушники Sony", 49.99m),
            new("Клавіатура Logitech", 129.00m),
            new("Монітор LG 27\"", 399.00m),
            new("USB-хаб Anker", 35.00m),
            new("Веб-камера Logitech", 149.00m),
            new("Килимок для миші", 18.00m),
            new("SSD Samsung 1TB", 110.00m)
        };

        var result = products
            .Where(product => product.PriceUsd > 100m)
            .Select(product => new
            {
                product.Name,
                PriceUah = product.PriceUsd * usdToUah
            })
            .Select(product => $"{product.Name} -- {product.PriceUah:F2} грн (є в наявності)");

        foreach (var line in result)
        {
            Console.WriteLine(line);
        }
    }
}
