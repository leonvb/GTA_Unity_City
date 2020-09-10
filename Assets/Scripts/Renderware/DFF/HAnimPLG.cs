using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class HAnimPLG
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint version; // Animation version format
        public uint boneId; // User ID for this bone
        public uint numBones; // Number of bones if hierarchy (0 if not root bone)

        // If any bones are affected
        public uint flags;
        public uint keyFrameSize;

        public List<BoneInfo> bones;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public HAnimPLG(ref BufferReader reader)
        {
            //*******************************
            //         INITIALIZE
            //*******************************
            bones = new List<BoneInfo>();

            //*******************************
            //          HANIM PLG
            //*******************************
            version = reader.ReadUInt32();
            boneId = reader.ReadUInt32();
            numBones = reader.ReadUInt32();

            if (numBones != 0)
            {
                flags = reader.ReadUInt32();
                keyFrameSize = reader.ReadUInt32();

                for (int i = 0; i < numBones; i++)
                    bones.Add(new BoneInfo(ref reader));
            }  
        } // Constructor end
    }

    class BoneInfo
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint boneId; // User Id for this bone
        public uint boneIndex; // Bone index in this array;
        public uint boneTypes; // Bone flags;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public BoneInfo(ref BufferReader reader)
        {
            boneId = reader.ReadUInt32();
            boneIndex = reader.ReadUInt32();
            boneTypes = reader.ReadUInt32();
        }
    }
}
