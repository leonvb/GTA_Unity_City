using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class MaterialList
    {
        //*******************************
        //          PROPERTIES
        //*******************************

        public int numMaterials; // Including material instances
        public List<int> materialIndices; // Array of material indices

        // CHILD SECTIONS
        public List<Material> materials;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public MaterialList(ref BufferReader reader)
        {
            //*******************************
            //         INITIALIZE
            //*******************************
            materialIndices = new List<int>();
            materials = new List<Material>();

            Header header = new Header();

            // READ THE HEADERS MATERIALLIST/STRUCT
            header.Read(ref reader); // Material List
            header.Read(ref reader); // Struct

            //*******************************
            //        MATERIAL LIST
            //*******************************
            numMaterials = reader.ReadInt32();

            for (int i = 0; i < numMaterials; i++)
                materialIndices.Add(reader.ReadInt32());

            //*******************************
            //          CHILDREN
            //*******************************
            int counter = 0;
            for (int i = 0; i < numMaterials; i++)
            {
                counter++;
                Console.WriteLine(counter);
                materials.Add(new Material(ref reader));
            }
        }
    }
}
