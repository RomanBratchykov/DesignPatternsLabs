using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Facade
{
    public class VideoFile
    {
        public string Name { get; }
        public string CodecType { get; }
        public VideoFile(string name)
        {
            Name = name;
            CodecType = name.EndsWith(".ogg") ? "ogg" : "mpeg4";
        }
    }
}