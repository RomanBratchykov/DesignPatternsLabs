using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Proxy
{
    public class ProtectedImageProxy : IImageLoader
    {
        private readonly RealImage _real;
        private readonly string    _role;

        public ProtectedImageProxy(string file, string role)
        { _real = new RealImage(file); _role = role; }

        public void Display()
        {
            if (_role != "admin")
                throw new UnauthorizedAccessException(
                    "Only admins can view this image.");
            _real.Display();
        }
    }
}