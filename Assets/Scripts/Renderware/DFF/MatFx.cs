using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class MatFx
    {
        public uint type;
    }

    class MatFxBumpMap : MatFx
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint fxType;
        public float intensity;
        public bool containsBumpMap; // Bool
        public Texture bumpMap; // Only if contains a bumpmap
        public bool containsHeightMap; // Bool
        public Texture heightMap; // Only if caintains heightmap

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public MatFxBumpMap(ref BufferReader reader)
        {
            //*******************************
            //           MATFX
            //*******************************
            type = reader.ReadUInt32();
            fxType = type;
            intensity = reader.ReadSingle();

            containsBumpMap = Convert.ToBoolean(reader.ReadInt32());
            if (containsBumpMap)
                bumpMap = new Texture(ref reader);


            containsHeightMap = Convert.ToBoolean(reader.ReadInt32());
            if (containsHeightMap)
                heightMap = new Texture(ref reader);

            //*******************************
            //         EXTENSIONS
            //*******************************
            Header header = new Header();
            header.Read(ref reader); // EXIT EXTENSION

        } // Constructor end
    }

    class MatFxEnvMap : MatFx
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint fxType;
        public float reflectionCoefficient;
        public bool bFrameBufferAlphaChannel;
        public bool containsEnvironmentMap;
        public Texture environmentMap;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public MatFxEnvMap(ref BufferReader reader)
        {
            //*******************************
            //           MATFX
            //*******************************
            type = reader.ReadUInt32();
            fxType = type;
            reflectionCoefficient = reader.ReadSingle();
            bFrameBufferAlphaChannel = Convert.ToBoolean(reader.ReadInt32());
            containsEnvironmentMap = Convert.ToBoolean(reader.ReadInt32());

            if (containsEnvironmentMap)
                environmentMap = new Texture(ref reader);

            //*******************************
            //         EXTENSIONS
            //*******************************
            reader.ReadBytes(4); // EXIT EXTENSION

        } // Constructor end
    }

    class MatFxDual : MatFx
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint fxType;
        public int srcBlendMode;
        public int destBlendMode;
        public bool containsTexture;
        public Texture texture;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public MatFxDual(ref BufferReader reader)
        {
            //*******************************
            //           MATFX
            //*******************************
            type = reader.ReadUInt32();
            fxType = type;
            srcBlendMode = reader.ReadInt32();
            destBlendMode = reader.ReadInt32();
            containsTexture = Convert.ToBoolean(reader.ReadInt32());

            if (containsTexture)
                texture = new Texture(ref reader);

            //*******************************
            //         EXTENSIONS
            //*******************************
            Header header = new Header();
            header.Read(ref reader); // EXIT EXTENSION

        } // Constructor end
    }

    class MatFxUvTransform : MatFx
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint fxType;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public MatFxUvTransform(ref BufferReader reader)
        {
            //*******************************
            //           MATFX
            //*******************************
            type = reader.ReadUInt32();
            fxType = type;

            //*******************************
            //         EXTENSIONS
            //*******************************
            Header header = new Header();
            header.Read(ref reader); // EXIT EXTENSION

        } // Constructor end
    }
}
