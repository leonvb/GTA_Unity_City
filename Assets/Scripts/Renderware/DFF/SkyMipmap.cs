using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class SkyMipmap
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public int value;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public SkyMipmap(Header parent, ref BufferReader reader)
        {
            value = reader.ReadInt32();

        } // Constructor end
    }
}
