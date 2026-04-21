using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Decorator
{
    public class CompressionDecorator : DataSourceDecorator
    {
        public CompressionDecorator(IDataSource s) : base(s) {}

        public override void Write(string data)
        {
            Console.WriteLine("[Compressing data...]");
            base.Write(data); 
        }
    
        public override string Read()
        {
            Console.WriteLine("[Decompressing data...]");
            return base.Read();
        }
    }
}