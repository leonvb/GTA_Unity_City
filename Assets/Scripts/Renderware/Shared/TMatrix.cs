using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    struct TMatrix
    {
        public TVector3 V1;
        public TVector3 V2;
        public TVector3 V3;

        public TMatrix(TVector3 v1, TVector3 v2, TVector3 v3)
        {
            this.V1 = v1;
            this.V2 = v2;
            this.V3 = v3;
        }

        public override string ToString()
        {
            return String.Format("V1: {0}, V2: {1}, V3: {2}", V1.ToString(), V2.ToString(), V3.ToString());
        }
    }
}
