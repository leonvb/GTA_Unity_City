using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    struct Light
    {
        public int frameIndex;
        public float radius;
        public float red;
        public float green;
        public float blue;
        public float minusCosAngle; // DirectionAngle
        public uint flags;
        public uint type;
    }
}
