using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    struct RGBA
    {
        public byte Red;
        public byte Green;
        public byte Blue;
        public byte Alpha;

        public RGBA(byte r, byte g, byte b, byte a)
        {
            this.Red = r;
            this.Green = g;
            this.Blue = b;
            this.Alpha = a;
        }
    }
}
