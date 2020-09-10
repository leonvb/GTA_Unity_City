using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class zon
    {
        public string name;
        public int type;
        public float x1, y1, z1;
        public float x2, y2, z2;
        public int level;
        public string text;

        private string[] pars;

        public zon(string[] pars)
        {
            this.pars = pars;

            if (pars.Count() == 9)
                zon1();
            else
                zon2();
        }

        private void zon1()
        {
            this.text = string.Empty;

            this.name = pars[0];
            this.type = Convert.ToInt32(pars[1]);

            this.x1 = Convert.ToSingle(pars[2]);
            this.y1 = Convert.ToSingle(pars[3]);
            this.z1 = Convert.ToSingle(pars[4]);

            this.x2 = Convert.ToSingle(pars[5]);
            this.y2 = Convert.ToSingle(pars[6]);
            this.z2 = Convert.ToSingle(pars[7]);

            this.level = Convert.ToInt32(pars[8]);
        }

        private void zon2()
        {
            this.name = pars[0];
            this.type = Convert.ToInt32(pars[1]);

            this.x1 = Convert.ToSingle(pars[2]);
            this.y1 = Convert.ToSingle(pars[3]);
            this.z1 = Convert.ToSingle(pars[4]);

            this.x2 = Convert.ToSingle(pars[5]);
            this.y2 = Convert.ToSingle(pars[6]);
            this.z2 = Convert.ToSingle(pars[7]);

            this.level = Convert.ToInt32(pars[8]);
            this.text = pars[9];
        }
    }   
}
