using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    struct Matrix4x4
    {
        public readonly TVector4 V0;
        public readonly TVector4 V1;
        public readonly TVector4 V2;
        public readonly TVector4 V3;

        public Matrix4x4(TVector4 v0, TVector4 v1, TVector4 v2, TVector4 v3)
        {
            V0 = v0;
            V1 = v1;
            V2 = v2;
            V3 = v3;
        }

        public Matrix4x4(ref BufferReader reader)
        {
            V0 = new TVector4(ref reader);
            V1 = new TVector4(ref reader);
            V2 = new TVector4(ref reader);
            V3 = new TVector4(ref reader);
        }
    }
}
