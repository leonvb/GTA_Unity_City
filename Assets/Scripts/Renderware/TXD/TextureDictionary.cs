using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class TextureDictionary
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public int textureCount; // No of NativeTexture sections (read as short)
        //public short deviceID; // 1 - D3D8, 2 - D3D9, 6 - Playstation2, 8 - Xbox

        // CHILD SECTIONS
        public List<TextureNative> textureNative;


        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public TextureDictionary(ref BufferReader reader)
        {
            //*******************************
            //         INITIALIZE
            //*******************************
            textureNative = new List<TextureNative>();

            Header header = new Header();

            header.Read(ref reader); // TEXTURE DICTIONARY HEADER
            header.Read(ref reader); // STRUCT HEADER

            //*******************************
            //       TEXTURE DICTIONARY
            //*******************************
            textureCount = reader.ReadInt32();

            //*******************************
            //          CHILDREN
            //*******************************
            for (int i = 0; i < textureCount; i++)
            {
                textureNative.Add(new TextureNative(ref reader));
            }

            //*******************************
            //         EXTENSIONS
            //*******************************
            //header.Read(ref reader); // EXIT EXTENSION

        } // Constructor end
    }
}
