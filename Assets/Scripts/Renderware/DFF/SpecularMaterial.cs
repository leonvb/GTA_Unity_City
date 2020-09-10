using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class SpecularMaterial
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public float specularLevel; // 0.0 - 1.0
        public string specularName; // Texture Name

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public SpecularMaterial(ref BufferReader reader)
        {
            specularLevel = reader.ReadSingle();
            specularName = reader.ReadNullTerminatedString(24);
        }
    }
}
