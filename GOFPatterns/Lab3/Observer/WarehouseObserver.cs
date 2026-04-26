using System;

namespace Lab2.Observer
{
    public class WarehouseObserver : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"Warehouse received update: {message}");
        }
    }
}
