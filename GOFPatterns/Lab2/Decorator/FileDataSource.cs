using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Decorator
{
    public class FileDataSource
    {
         private string _stored = "";
        public void   Write(string data) => _stored = data;
        public string Read()             => _stored;
    }
}