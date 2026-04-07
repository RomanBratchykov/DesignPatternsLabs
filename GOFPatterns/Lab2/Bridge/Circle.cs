using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Bridge
{
    public class Circle : Shape
    {
        private float _radius;
        public Circle(IRenderer r, float radius) : base(r)
            => _radius = radius;

        public override void Draw() => Renderer.RenderCircle(_radius);
        public override void Resize(float f) => _radius *= f;
    }
}