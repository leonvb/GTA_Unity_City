using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class cull
    {
        public float centerX, centerY, centerZ;
        public float x1, y1, z1;
        public float x2, y2, z2;
        public int attribute;
        public int wantedLevelDrop;

        private string[] pars;

        public cull(string[] pars)
        {
            this.pars = pars;

            Create();
        }

        private void Create()
        {
            this.centerX = Convert.ToSingle(pars[0]);
            this.centerY = Convert.ToSingle(pars[1]);
            this.centerZ = Convert.ToSingle(pars[2]);

            this.x1 = Convert.ToSingle(pars[3]);
            this.y1 = Convert.ToSingle(pars[4]);
            this.z1 = Convert.ToSingle(pars[5]);

            this.x2 = Convert.ToSingle(pars[6]);
            this.y2 = Convert.ToSingle(pars[7]);
            this.z2 = Convert.ToSingle(pars[8]);

            this.attribute = Convert.ToInt32(pars[9]);
            this.wantedLevelDrop = Convert.ToInt32(pars[10]);
        }
    }
}
