using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Bridge
{
    public interface IRenderer
    {
        void RenderCircle(float radius);
        void RenderSquare(float side);
    }
}