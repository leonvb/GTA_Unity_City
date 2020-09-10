using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class Material
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint flags; // Unused
        public RGBA color;
        public uint unused;
        public bool isTextured; // If true, then a Texture chunk with follow the Struct

        // Surface Information
        public float ambient;
        public float specular;
        public float diffuse;

        // CHILD SECTIONS
        public Texture texture;

        // EXTENSIONS
        public RightToRender rightToRender;
        //public UserDataPLG userDataPLG;
        public MatFx materialEffects;
        public UVAnimationPLG uvAnimationPLG;
        public ReflectionMaterial reflectionMaterial;
        public SpecularMaterial specularMaterial;

        // PRIVATE
        private Header header;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public Material(ref BufferReader reader)
        {
            //*******************************
            //         INITIALIZE
            //*******************************
            //Header header = new Header();
            header = new Header();

            header.Read(ref reader); // MATERIAL HEADER
            header.Read(ref reader); // STRUCT HEADER

            //*******************************
            //           MATERIAL
            //*******************************
            flags = reader.ReadUInt32();
            color = new RGBA(reader.ReadByte(), reader.ReadByte(), reader.ReadByte(), reader.ReadByte());
            unused = reader.ReadUInt32();
            isTextured = Convert.ToBoolean(reader.ReadInt32());

            if (header.version > 0x30400)
            {
                ambient = reader.ReadSingle();
                specular = reader.ReadSingle();
                diffuse = reader.ReadSingle();
            }

            //*******************************
            //          CHILDREN
            //*******************************
            if (isTextured)
                texture = new Texture(ref reader);

            //*******************************
            //         EXTENSIONS
            //*******************************
            header.Read(ref reader); // EXTENSION HEADER

            if (header.size > 0)
                ReadExtensions(ref reader);
            // Else, it's an exit extension (0 bytes)

        } // Constructor end

        private void ReadExtensions(ref BufferReader reader)
        {
            long end = reader.Position + header.size;

            while (reader.Position < end)
            {
                header.Read(ref reader); // ? EXTENSION HEADER

                switch (header.type)
                {
                    case ((int)CHUNK_TYPE.CHUNK_MATERIALEFFECTS):
                        ReadFx(ref reader);
                        break;

                    case ((int)CHUNK_TYPE.CHUNK_REFLECTIONMAT):
                        reflectionMaterial = new ReflectionMaterial(ref reader);
                        break;

                    case ((int)CHUNK_TYPE.CHUNK_SPECULARMAT):
                        specularMaterial = new SpecularMaterial(ref reader);
                        break;
                }
            }
        }

        private void ReadFx(ref BufferReader reader)
        {
            uint type = reader.ReadUInt32();

            switch (type)
            {
                case ((int)MATFX_TYPE.MATFX_BUMPMAP):
                    materialEffects = new MatFxBumpMap(ref reader);
                    break;

                case ((int)MATFX_TYPE.MATFX_ENVMAP):
                    materialEffects = new MatFxEnvMap(ref reader);
                    break;

                case ((int)MATFX_TYPE.MATFX_BUMPENVMAP):
                    break;

                case ((int)MATFX_TYPE.MATFX_DUAL):
                    materialEffects = new MatFxDual(ref reader);
                    break;

                case ((int)MATFX_TYPE.MATFX_UVTRANSFORM):
                    materialEffects = new MatFxUvTransform(ref reader);
                    break;

                case ((int)MATFX_TYPE.MATFX_DUALUVTRANSFORM):
                    break;
            }
        }
    }
}
