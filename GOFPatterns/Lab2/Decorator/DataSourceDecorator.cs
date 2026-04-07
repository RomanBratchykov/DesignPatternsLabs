using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Decorator
{
    public class DataSourceDecorator : IDataSource
    {
         protected IDataSource _wrappee;
    protected DataSourceDecorator(IDataSource source)
        => _wrappee = source;

        public virtual void   Write(string data) => _wrappee.Write(data);
        public virtual string Read()             => _wrappee.Read();
    }
}