using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Adapter
{
    public class LegacyLogger
    {
        public void WriteEntry(string source, string text, int level)
        {
            Console.WriteLine($"[{source}][Level {level}] {text}");
        }
    }
}