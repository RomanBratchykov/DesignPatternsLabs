using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Patterns
{
    public class Prototype : IDemonstrate
    {
        public void Demonstrate()
        {
            Console.WriteLine("This is the Prototype pattern demonstration.");
        }
    }
}