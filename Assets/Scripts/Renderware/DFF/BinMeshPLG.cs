using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class BinMeshPLG
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint flags; // (0 = tri list; 1 = tri strip)
        public uint numMeshes; // Number of meshes
        public uint totalIndices; // Total number of indices

        public List<BinMeshData> data;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public BinMeshPLG(ref BufferReader reader)
        {
            //*******************************
            //         INITIALIZE
            //*******************************
            data = new List<BinMeshData>();

            //*******************************
            //          BinMesh PLG
            //*******************************
            flags = reader.ReadUInt32();
            numMeshes = reader.ReadUInt32();
            totalIndices = reader.ReadUInt32();

            for (int i = 0; i < numMeshes; i++)
                data.Add(new BinMeshData(ref reader));
        }
    }

    class BinMeshData
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint numIndices;
        public uint materialIndex;
        public uint indices;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public BinMeshData(ref BufferReader reader)
        {
            numIndices = reader.ReadUInt32();
            materialIndex = reader.ReadUInt32();

            for (int j = 0; j < numIndices; j++)
                indices = reader.ReadUInt32();
        }
    }
}
