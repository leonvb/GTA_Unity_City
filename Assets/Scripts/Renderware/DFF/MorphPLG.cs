using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class MorphPLG
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint unknown;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public MorphPLG(ref BufferReader reader)
        {
            unknown = reader.ReadUInt32();
        }
    }
}
