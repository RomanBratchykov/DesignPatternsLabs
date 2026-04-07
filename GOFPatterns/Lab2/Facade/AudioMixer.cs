using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Facade
{
    public class AudioMixer
    {
       public string Fix(string result)
        {
            Console.WriteLine("AudioMixer: fixing audio");
            return result + ".mp4";
        } 
    }
}