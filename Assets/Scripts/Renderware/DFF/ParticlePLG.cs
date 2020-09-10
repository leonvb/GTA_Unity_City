using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class ParticlePLG
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint particleVal;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public ParticlePLG(ref BufferReader reader)
        {
            particleVal = reader.ReadUInt32();
        }
    }
}
