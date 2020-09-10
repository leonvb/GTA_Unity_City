using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class PipelineSet
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint pipelineVal;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public PipelineSet(ref BufferReader reader)
        {
            pipelineVal = reader.ReadUInt32();
        }

        /*
         *  0x53F20098 – Render pipeline used for buildings with reflective materials.
         *  0x53F2009A – Render pipeline used for vehicles.
         *  0x53F2009C – Render pipeline used for night vertex colors.
         */
    }
}
