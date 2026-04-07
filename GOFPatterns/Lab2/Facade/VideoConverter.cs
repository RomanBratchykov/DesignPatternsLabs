using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Facade
{
    public class VideoConverter
    {
         public string Convert(string filename, string targetFormat)
        {
            Console.WriteLine("VideoConverter: starting conversion");
            var file    = new VideoFile(filename);
            var srcCodec = CodeFactory.Extract(file);
            var buffer   = BitrateReader.Read(file, srcCodec);
            var result   = BitrateReader.Convert(buffer, targetFormat);
            return new AudioMixer().Fix(result);
        }
    }
}