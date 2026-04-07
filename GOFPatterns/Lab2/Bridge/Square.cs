using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Bridge
{
    public class Square : Shape
    {
        private float _side;
        public Square(IRenderer r, float side) : base(r)
            => _side = side;

        public override void Draw() => Renderer.RenderSquare(_side);
        public override void Resize(float f) => _side *= f;
    }
}