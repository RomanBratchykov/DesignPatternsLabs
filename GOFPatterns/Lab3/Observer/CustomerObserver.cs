using System;

namespace Lab2.Observer
{
    public class CustomerObserver : IObserver
    {
        private readonly string _name;

        public CustomerObserver(string name)
        {
            _name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"Customer {_name} received update: {message}");
        }
    }
}
