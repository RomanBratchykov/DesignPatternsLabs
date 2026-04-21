using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Proxy
{
    public class LazyImageProxy : IImageLoader
    {
        private RealImage? _real;
        private readonly string _filename;
        public LazyImageProxy(string f) => _filename = f;

        public void Display()
        {
            Console.WriteLine($"[LazyProxy] Requesting image: {_filename}");

            _real ??= new RealImage(_filename);
            _real.Display();
        }
    }
}