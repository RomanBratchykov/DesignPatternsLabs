using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Decorator
{
    public class EncryptionDecorator : DataSourceDecorator
    {
         public EncryptionDecorator(IDataSource s) : base(s) {}

    public override void Write(string data)
    {
        var encoded = Convert.ToBase64String(
            System.Text.Encoding.UTF8.GetBytes(data));
        base.Write(encoded);
    }

    public override string Read()
    {
        var bytes = Convert.FromBase64String(base.Read());
        return System.Text.Encoding.UTF8.GetString(bytes);
    }
    }
}