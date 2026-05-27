using System;
using System.Collections.Generic;
using System.Linq;
using Lab7;

namespace Lab7.Tasks;

public sealed class Task01_OrdersFunctional : ILabTask
{
    public string Name => "1.1 Імперативний -> функціональний (замовлення)";
    public string Description => "LINQ .Where/.Count/.Sum замість циклу для підрахунку виконаних замовлень.";

    private enum Status
    {
        Delivered,
        Pending,
        Cancelled
    }

    private record Order(string Id, Status Status, decimal Amount);

    public void Run()
    {
        var orders = new List<Order>
        {
            new("O-001", Status.Delivered, 1500.00m),
            new("O-002", Status.Pending, 300.00m),
            new("O-003", Status.Cancelled, 75.00m),
            new("O-004", Status.Delivered, 2200.00m),
            new("O-005", Status.Pending, 450.00m),
            new("O-006", Status.Delivered, 980.00m)
        };

        var delivered = orders.Where(order => order.Status == Status.Delivered);
        var count = delivered.Count();
        var totalDelivered = delivered.Sum(order => order.Amount);

        Console.WriteLine($"Виконаних замовлень: {count}");
        Console.WriteLine($"Загальна сума: {totalDelivered:F1}");
    }
}
