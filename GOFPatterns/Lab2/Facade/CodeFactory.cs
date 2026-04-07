using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Facade
{
    public class CodeFactory
    {
         public static string Extract(VideoFile f)
        {
            Console.WriteLine($"CodecFactory: extracting {f.CodecType} codec");
            return f.CodecType;
        }
    }
}