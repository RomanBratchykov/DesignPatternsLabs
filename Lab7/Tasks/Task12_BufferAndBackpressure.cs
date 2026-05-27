using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Lab7;

namespace Lab7.Tasks;

public sealed class Task12_BufferAndBackpressure : ILabTask
{
    public string Name => "6.2 buffer + backpressure";
    public string Description => "buffer(5) для пакетної вставки та симуляція DROP при перевантаженні.";

    public void Run()
    {
        Console.WriteLine("Частина A: buffer(5)");
        var eventsStream = new List<string>
        {
            "LOGIN:user1",
            "CLICK:btn_buy",
            "VIEW:product_42",
            "LOGIN:user2",
            "LOGOUT:user1",
            "CLICK:btn_cart",
            "VIEW:product_7",
            "LOGIN:user3",
            "CLICK:btn_pay",
            "LOGOUT:user2",
            "LOGIN:user4",
            "VIEW:product_1"
        };

        var batchIndex = 0;
        eventsStream
            .ToObservable()
            .Buffer(5)
            .Subscribe(batch =>
            {
                batchIndex++;
                Console.WriteLine($"[DB] Batch INSERT #{batchIndex}: [{string.Join(", ", batch)}]");
            });

        Console.WriteLine($"(+) Збережено подій: {eventsStream.Count}");

        Console.WriteLine();
        Console.WriteLine("Частина B: backpressure DROP");

        var capacity = 128;
        var processed = 0;
        var dropped = 0;

        var channel = Channel.CreateBounded<int>(new BoundedChannelOptions(capacity)
        {
            FullMode = BoundedChannelFullMode.Wait
        });

        var done = new ManualResetEventSlim(false);

        Task.Run(async () =>
        {
            await foreach (var item in channel.Reader.ReadAllAsync())
            {
                processed++;
                await Task.Delay(10);
            }

            done.Set();
        });

        for (var i = 1; i <= 1000; i++)
        {
            if (!channel.Writer.TryWrite(i))
            {
                dropped++;
            }
        }

        channel.Writer.Complete();
        done.Wait();

        Console.WriteLine($"[ЗВІТ] Оброблено: {processed}");
        Console.WriteLine($"[ЗВІТ] Відкинуто: {dropped}");
        Console.WriteLine("(!) Стратегія DROP: частину елементів втрачено");
    }
}
