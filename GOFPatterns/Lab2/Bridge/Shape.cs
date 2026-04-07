using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Bridge
{
    public abstract class Shape
    {
         protected IRenderer Renderer;
        protected Shape(IRenderer renderer) => Renderer = renderer;
        public abstract void Draw();
        public abstract void Resize(float factor);
    }
}