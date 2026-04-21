using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Bridge
{
    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float r)
            => Console.WriteLine($"Vectorizing circle r={r}");
        public void RenderSquare(float s)
            => Console.WriteLine($"Vectorizing square s={s}");
    }
}