using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Composite
{
    public class FiLe : IFileSystemItem
{
    private readonly long _size;
    public string Name { get; }

    public FiLe(string name, long size)
    { Name = name; _size = size; }

    public void Print(string indent)
        => Console.WriteLine($"File: {indent} {Name} ({_size}B)");

    public long GetSize() => _size;
}
}