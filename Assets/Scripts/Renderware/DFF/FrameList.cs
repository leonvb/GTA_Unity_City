using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class FrameList
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint numFrames;
        public List<FrameInfo> framesInfo;

        // EXTENSIONS
        public List<Frame> frames;
        public List<HAnimPLG> hAnimPLGs;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public FrameList(ref BufferReader reader)
        {
            //*******************************
            //         INITIALIZE
            //*******************************
            framesInfo = new List<FrameInfo>();
            frames = new List<Frame>();
            hAnimPLGs = new List<HAnimPLG>();

            Header header = new Header();

            header.Read(ref reader); // FRAME LIST HEADER
            header.Read(ref reader); // STRUCT HEADER

            //*******************************
            //          FRAME LIST
            //*******************************
            numFrames = reader.ReadUInt32();

            // FRAME INFO
            for (int i = 0; i < numFrames; i++)
                framesInfo.Add(new FrameInfo(ref reader));

            //*******************************
            //         EXTENSIONS
            //*******************************
            for (int i = 0; i < numFrames; i++)
                ReadExtensions(ref reader);

        } // Constructor end

        private void ReadExtensions(ref BufferReader reader)
        {
            Header header = new Header();

            header.Read(ref reader); // EXTENSION HEADER

            long end = reader.Position + header.size;

            while (reader.Position < end)
            {
                header.Read(ref reader); // ? EXTENSION HEADER

                switch (header.type)
                {
                    case ((int)CHUNK_TYPE.CHUNK_FRAME):
                        frames.Add(new Frame(header, ref reader));
                        break;

                    case ((int)CHUNK_TYPE.CHUNK_HANIM):
                        hAnimPLGs.Add(new HAnimPLG(ref reader));
                        break;
                }
            }
        }
    }

    class FrameInfo
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public TMatrix rotationMatrix;
        public TVector3 position;
        public uint parentFrame;
        public uint flags; //  matrix creation flag, unused

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public FrameInfo(ref BufferReader reader)
        {
            // ROTATION
            TVector3 v1 = new TVector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
            TVector3 v2 = new TVector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
            TVector3 v3 = new TVector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

            rotationMatrix = new TMatrix(v1, v2, v3);

            // POSITION
            position = new TVector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

            // PARENT
            parentFrame = reader.ReadUInt32();

            // FLAGS
            flags = reader.ReadUInt32();
        }
    }
}
