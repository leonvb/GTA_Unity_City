using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class Atomic
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint frameIndex; // zero-based index
        public uint geometryIndex; // zero-based index
        public uint flags;
        public uint unused;

        // EXTENSIONS
        public RightToRender rightToRender;
        public ParticlePLG particlesPLG;
        public PipelineSet pipelineSet;
        //public UserDataPLG userDataPLG;
        public MatFx materialEffects;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public Atomic(ref BufferReader reader)
        {
            //*******************************
            //         INITIALIZE
            //*******************************
            Header header = new Header();

            header.Read(ref reader); // ATOMIC HEADER
            header.Read(ref reader); // STRUCT HEADER

            //*******************************
            //          ATOMIC
            //*******************************
            frameIndex = reader.ReadUInt32();
            geometryIndex = reader.ReadUInt32();
            flags = reader.ReadUInt32();
            unused = reader.ReadUInt32();

            //*******************************
            //         EXTENSIONS
            //*******************************
            header.Read(ref reader);
            ReadExtensions(header, ref reader);
        }

        private void ReadExtensions(Header header, ref BufferReader reader)
        {
            long end = reader.Position + header.size;

            while (reader.Position < end)
            {
                header.Read(ref reader);

                switch (header.type)
                {
                    case ((int)CHUNK_TYPE.CHUNK_RIGHTTORENDER):
                        rightToRender = new RightToRender(ref reader);
                        break;

                    case ((int)CHUNK_TYPE.CHUNK_MATERIALEFFECTS):
                        ReadFx(ref reader);
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

                    break;

                case ((int)MATFX_TYPE.MATFX_ENVMAP):
                    materialEffects = new MatFxEnvMap(ref reader);
                    break;

                case ((int)MATFX_TYPE.MATFX_BUMPENVMAP):

                    break;

                case ((int)MATFX_TYPE.MATFX_DUAL):

                    break;

                case ((int)MATFX_TYPE.MATFX_UVTRANSFORM):

                    break;

                case ((int)MATFX_TYPE.MATFX_DUALUVTRANSFORM):

                    break;

                default:
                    break;
            }
        }
    }
}
