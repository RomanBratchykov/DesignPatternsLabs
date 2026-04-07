using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Proxy
{
    public class RealImage : IImageLoader
    {
        private readonly string _filename;
        public RealImage(string filename)
        {
            _filename = filename;
            LoadFromDisk(); 
        }
        private void LoadFromDisk()
            => Console.WriteLine($"Loading {_filename} from disk...");
        public void Display()
            => Console.WriteLine($"Displaying {_filename}");
    }
}