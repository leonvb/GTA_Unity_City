using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class SkinBoneWeights
    {
        public Single[] Weights;

        public SkinBoneWeights(ref BufferReader reader)
        {
            Weights = new Single[4];

            for (int i = 0; i < Weights.Length; ++i)
                Weights[i] = reader.ReadSingle();
        }
    }

    class SkinBoneIndices
    {
        public byte[] Indices;

        public SkinBoneIndices(ref BufferReader reader)
        {
            Indices = reader.ReadBytes(4);
        }
    }

    class SkinPLG
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        #region PROPERTIES
        
        public byte numBones; // numMatrices
        public byte numBoneIds;
        public ushort maxWeightsPerVertex;
        //public byte padding; // Unused

        public byte[] boneIds;

        public SkinBoneIndices[] vertexBoneIndices; // Size geometry.NumVertices; Maybe int
        public SkinBoneWeights[] vertexBoneWeights; // Size geometry.NumVertices * 4;

        public Matrix4x4[] skinToBoneMatrices; // Size numBones * 16;

        public uint boneLimit;
        public uint numMeshes;
        public uint numRLE;

        //public byte[] meshBoneRemapIndices;
        public byte[] meshBoneRemapIndices;
        public ushort[] meshBoneRLECount;
        public ushort[] meshBoneRLE;

        // PRIVATE
        private int numVertices;
        private Header parent;

        #endregion

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public SkinPLG(int numVertices, Header parent, ref BufferReader reader)
        {
            //*******************************
            //         INITIALIZE
            //*******************************
            this.numVertices = numVertices;
            this.parent = parent;

            //*******************************
            //            SKIN
            //*******************************
            numBones = reader.ReadByte();
            numBoneIds = reader.ReadByte();
            maxWeightsPerVertex = reader.ReadUInt16();

            boneIds = reader.ReadBytes(numBoneIds);

            vertexBoneIndices = new SkinBoneIndices[numVertices];
            vertexBoneWeights = new SkinBoneWeights[numVertices];

            for (int i = 0; i < numVertices; i++)
                vertexBoneIndices[i] = new SkinBoneIndices(ref reader);

            for (int i = 0; i < numVertices; i++)
                vertexBoneWeights[i] = new SkinBoneWeights(ref reader);

            skinToBoneMatrices = new Matrix4x4[numBones];

            for (int i = 0; i < numBones; i++)
            {
                if (numBoneIds == 0)
                    reader.Skip(4);

                skinToBoneMatrices[i] = new Matrix4x4(ref reader);
            } // endfor

            //boneLimit = reader.ReadUInt32();
            //numMeshes = reader.ReadUInt32();
            //numRLE = reader.ReadUInt32();

            /*
            if (numMeshes > 0)
            {
                //meshBoneRemapIndices = reader.ReadBytes((Int32)(numBones + 2 * (rle + meshCount)));
                meshBoneRemapIndices = new byte[numBones];
                for (int i = 0; i < numBones; i++)
                {
                    meshBoneRemapIndices[i] = reader.ReadByte();
                }

                meshBoneRLECount = new ushort[numMeshes];
                for (int i = 0; i < numMeshes; i++)
                {
                    meshBoneRLECount[i] = reader.ReadUInt16();
                }

                meshBoneRLE = new ushort[numRLE];
                for (int i = 0; i < numRLE; i++)
                {
                    meshBoneRLE[i] = reader.ReadUInt16();
                }
            }*/

            //Console.WriteLine((int)(parent.size - (reader.Position - startReadPosition)));
            //reader.Skip((int)(parent.size - (reader.Position - startReadPosition)));
            reader.ReadUInt32();
            reader.ReadUInt32();
            reader.ReadUInt32();
            reader.ReadUInt32();
            reader.ReadUInt32();
            reader.ReadUInt32();
        } // end constructor
    }
}