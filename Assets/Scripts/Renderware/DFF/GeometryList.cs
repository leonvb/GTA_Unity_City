using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class GeometryList
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint geometryCount;

        /// CHILD SECTIONS
        public List<Geometry> geometries;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public GeometryList(ref BufferReader reader)
        {
            //*******************************
            //         INITIALIZE
            //*******************************
            geometries = new List<Geometry>();

            Header header = new Header();

            header.Read(ref reader); // GEOMETRY LIST HEADER
            header.Read(ref reader); // STRUCT HEADER

            //*******************************
            //         GEOMETRY LIST
            //*******************************
            geometryCount = reader.ReadUInt32();

            //*******************************
            //          CHILDREN
            //*******************************
            for (int i = 0; i < geometryCount; i++)
                geometries.Add(new Geometry(ref reader));

        } // Constructor end
    }
}
