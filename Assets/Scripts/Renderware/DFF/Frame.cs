using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class Frame
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public string nodeName;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public Frame(Header header, ref BufferReader reader)
        {
            nodeName = reader.ReadString((int)header.size);
        }
    }
}
