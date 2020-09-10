using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class Clump
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public int numAtomics; // Number of Atomics
        public int numLights; // Number of Lights - only present after version 0x33000
        public int numCameras; // Number of Cameras, 0 in all GTA files

        // CHILD SECTIONS
        public FrameList frameList;
        public GeometryList geometryList;
        public List<Atomic> atomics;
        //public Lights lights;
        //public Cameras cameras;

        // EXTENSIONS
        //public CollisionModel collisionModel;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public Clump(ref BufferReader reader)
        {
            //*******************************
            //         INITIALIZE
            //*******************************
            atomics = new List<Atomic>();

            Header header = new Header();

            header.Read(ref reader); // CLUMP HEADER
            header.Read(ref reader); // STRUCT HEADER

            //*******************************
            //          CLUMP
            //*******************************
            numAtomics = reader.ReadInt32();
            numLights = 0;
            if (header.size == 0xC)
            {
                numLights = reader.ReadInt32();
                numCameras = reader.ReadInt32();
            }

            //*******************************
            //          CHILDREN
            //*******************************
            frameList = new FrameList(ref reader);
            geometryList = new GeometryList(ref reader);

            // ATOMICS
            for (int i = 0; i < numAtomics; i++)
            {
                atomics.Add(new Atomic(ref reader));
            }

            //*******************************
            //         EXTENSIONS
            //*******************************
            //
            // NONE CURRENTLY
            //

            header.Read(ref reader); // EXIT EXTENSION

        } // Constructor end
    }
}
