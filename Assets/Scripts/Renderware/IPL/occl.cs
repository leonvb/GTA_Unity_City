using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class occl
    {
        public float midX, midY;
        public float bottomZ;
        public float widthX, widthY;
        public float height;
        public float rotation;

        private string[] pars;

        public occl(string[] pars)
        {
            this.pars = pars;

            VC_occl();
        }

        private void VC_occl()
        {
            this.midX = Convert.ToSingle(pars[0]);
            this.midY = Convert.ToSingle(pars[1]);

            this.bottomZ = Convert.ToSingle(pars[2]);

            this.widthX = Convert.ToSingle(pars[3]);
            this.widthY = Convert.ToSingle(pars[4]);

            this.height = Convert.ToSingle(pars[5]);
            this.rotation = Convert.ToSingle(pars[6]);
        }
    }     
}
