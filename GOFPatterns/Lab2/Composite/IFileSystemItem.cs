using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Bridge
{
    public interface IFileSystemItem
{
    string Name { get; }
    void Print(string indent = "");
    long GetSize();
}
}