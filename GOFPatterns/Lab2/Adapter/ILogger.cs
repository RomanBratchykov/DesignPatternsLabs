using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Adapter
{
    public interface ILogger
    {
        void Log(string message);
    }
}