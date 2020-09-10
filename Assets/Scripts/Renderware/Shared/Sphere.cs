using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    struct Sphere
    {
        public float X;
        public float Y;
        public float Z;
        public float Radius;

        public Sphere(float x, float y, float z, float r)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Radius = r;
        }
    }
}
