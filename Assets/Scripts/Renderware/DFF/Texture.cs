using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class Texture
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint filterFlags;

        // CHILD SECTIONS
        public string textureName;
        public string maskName;

        // EXTENSIONS
        public SkyMipmap skyMipmapVal;
        //public Anisotropy anisotropy;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public Texture(ref BufferReader reader)
        {
            //*******************************
            //         INITIALIZE
            //*******************************
            Header header = new Header();

            header.Read(ref reader); // TEXTURE HEADER
            header.Read(ref reader); // STRUCT HEADER

            //*******************************
            //           TEXTURE
            //*******************************
            filterFlags = reader.ReadUInt32();

            //*******************************
            //          CHILDREN
            //*******************************
            header.Read(ref reader); // STRING HEADER
            textureName = reader.ReadString((int)header.size);

            header.Read(ref reader); // STRING HEADER
            maskName = reader.ReadString((int)header.size);

            //*******************************
            //         EXTENSIONS
            //*******************************
            ReadExtensions(ref reader); // EXTENSION HEADER
        }

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
                    case ((int)CHUNK_TYPE.CHUNK_SKYMIPMAP):
                        skyMipmapVal = new SkyMipmap(header, ref reader);
                        break;
                }
            }
        }
    }
}
