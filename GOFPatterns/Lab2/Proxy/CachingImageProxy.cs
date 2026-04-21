using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Proxy
{
    public class CachingImageProxy : IImageLoader
    {
        private static readonly Dictionary<string,RealImage> _cache = new();
        private readonly string _filename;

        public CachingImageProxy(string f) => _filename = f;

        public void Display()
        {
            Console.WriteLine($"[CachingProxy] Requesting image: {_filename}");
            if (!_cache.TryGetValue(_filename, out var img))
            {
                img = new RealImage(_filename);
                _cache[_filename] = img;
            }
            img.Display();
        }
    }
}