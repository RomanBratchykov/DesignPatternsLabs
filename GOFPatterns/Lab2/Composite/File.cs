using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Bridge
{
    public class File : IFileSystemItem
{
    private readonly long _size;
    public string Name { get; }

    public File(string name, long size)
    { Name = name; _size = size; }

    public void Print(string indent)
        => Console.WriteLine($"{indent}📄 {Name} ({_size}B)");

    public long GetSize() => _size;
}
}