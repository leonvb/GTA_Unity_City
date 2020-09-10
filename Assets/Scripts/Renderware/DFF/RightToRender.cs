using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class RightToRender
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint rwPluginId;
        public uint extraData;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public RightToRender(ref BufferReader reader)
        {
            rwPluginId = reader.ReadUInt32();
            extraData = reader.ReadUInt32();
        }
    }
}
