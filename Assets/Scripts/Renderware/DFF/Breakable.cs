using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class Breakable
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint magicNumber;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public Breakable(ref BufferReader reader)
        {
            magicNumber = reader.ReadUInt32();

            // If not 0 then do something
        }
    }
}
