using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Flyweight
{
    public class Tree
    {
        public int      X    { get; }
        public int      Y    { get; }
        public TreeType Type { get; }

        public Tree(int x, int y, TreeType type)
        { X = x; Y = y; Type = type; }

        public void Draw() => Type.Draw(X, Y);
    }
}