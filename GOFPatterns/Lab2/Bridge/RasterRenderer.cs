using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Bridge
{
    public class RasterRenderer : IRenderer
{
    public void RenderCircle(float r)
        => Console.WriteLine($"Rasterizing circle r={r}");
    public void RenderSquare(float s)
        => Console.WriteLine($"Rasterizing square s={s}");
}
}