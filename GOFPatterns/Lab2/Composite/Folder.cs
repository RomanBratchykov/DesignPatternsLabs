using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Composite
{
    public class Folder : IFileSystemItem
    {
        private readonly List<IFileSystemItem> _children = new();
        public string Name { get; }
    
        public Folder(string name) => Name = name;
    
        public void Add(IFileSystemItem item) => _children.Add(item);
        public void Remove(IFileSystemItem item) => _children.Remove(item);
    
        public void Print(string indent = "")
        {
            Console.WriteLine($"Folder: {indent} {Name}");
            foreach (var child in _children)
                child.Print(indent + "  ");
        }
    
        public long GetSize()
            => _children.Sum(c => c.GetSize());
    }
}