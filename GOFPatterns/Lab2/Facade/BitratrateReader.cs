using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Facade
{
    public class BitrateReader
    {
        public static string Read(VideoFile f, string codec)
        {
            Console.WriteLine($"BitrateReader: reading file in {codec}");
            return f.Name;
        }
        public static string Convert(string buffer, string codec)
        {
            Console.WriteLine($"BitrateReader: converting to {codec}");
            return buffer;
        }
    }
}