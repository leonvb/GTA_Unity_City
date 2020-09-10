using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class ReflectionMaterial
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public float environmentMapScaleX;
        public float environmentMapScaleY;
        public float environmentMapOffsetX;
        public float environmentMapOffsetY;
        public float reflectionIntensity;
        public uint environmentTexturePtr; // Always 0

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public ReflectionMaterial(ref BufferReader reader)
        {
            environmentMapScaleX = reader.ReadSingle();
            environmentMapScaleY = reader.ReadSingle();
            environmentMapOffsetX = reader.ReadSingle();
            environmentMapOffsetY = reader.ReadSingle();
            reflectionIntensity = reader.ReadSingle();
            environmentTexturePtr = reader.ReadUInt32();
        }
    }
}
