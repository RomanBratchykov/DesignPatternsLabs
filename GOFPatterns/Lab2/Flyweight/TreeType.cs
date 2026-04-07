using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Flyweight
{
    public class TreeType
    {
        public string Name    { get; }
        public string Color   { get; }
        public string Texture { get; }

        public TreeType(string name, string color, string texture)
        { Name = name; Color = color; Texture = texture; }

        public void Draw(int x, int y)
            => Console.WriteLine(
                $"Drawing {Name} [{Color}] at ({x},{y}) tex={Texture}");
    }
}