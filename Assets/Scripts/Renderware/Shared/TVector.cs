using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{

    struct TVector2
    {
        public float X;
        public float Y;

        public override string ToString()
        {
            return String.Format("X: {0}, Y: {1}", Rounding.RoundToThree(X), Rounding.RoundToThree(Y));
        }
    }

    struct TVector3
    {
        public float X;
        public float Y;
        public float Z;

        public TVector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return String.Format("X: {0}, Y: {1}, Z: {2}", Rounding.RoundToThree(X), Rounding.RoundToThree(Y), Rounding.RoundToThree(Z));
        }
    }

    struct TVector4
    {
        public readonly float X;
        public readonly float Y;
        public readonly float Z;
        public readonly float W;

        public TVector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public TVector4(ref BufferReader reader)
        {
            X = reader.ReadSingle();
            Y = reader.ReadSingle();
            Z = reader.ReadSingle();
            W = reader.ReadSingle();
        }
    }
}
