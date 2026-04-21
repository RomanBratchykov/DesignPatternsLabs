using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Proxy
{
    public class LoggingImageProxy : IImageLoader
    {
        private readonly IImageLoader _inner;
        public LoggingImageProxy(IImageLoader inner) => _inner = inner;

        public void Display()
        {
            Console.WriteLine($"[LoggingProxy] Requesting image: ");
            Console.WriteLine($"[{DateTime.Now:T}] Display called");
            _inner.Display();
            Console.WriteLine($"[{DateTime.Now:T}] Display finished");
        }
    }
}