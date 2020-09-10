using System;
using System.Linq;

namespace GTAImgEditor
{
    class inst
    {
        public int id;
        public string modelName;
        public float interior;
        public float posX, posY, posZ;
        public float scaleX, scaleY, scaleZ;
        public float rotX, rotY, rotZ, rotW;
        public int lod;

        private string[] pars;

        public inst(string[] pars)
        {
            this.pars = pars;

            switch (pars.Count())
            {
                case (12):
                    III_inst();
                    break;

                case (13):
                    VC_inst();
                    break;

                case (11):
                    SA_inst();
                    break;

                default:
                    throw new Exception("Invalid number of parameters for inst line");

            } // end switch
        }

        // 12 parameters
        private void III_inst()
        {
            this.interior = 0;
            this.lod = 0;

            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];

            this.posX = Convert.ToSingle(pars[2]);
            this.posY = Convert.ToSingle(pars[3]);
            this.posZ = Convert.ToSingle(pars[4]);

            this.scaleX = Convert.ToSingle(pars[5]);
            this.scaleY = Convert.ToSingle(pars[6]);
            this.scaleZ = Convert.ToSingle(pars[7]);

            this.rotX = Convert.ToSingle(pars[8]);
            this.rotY = Convert.ToSingle(pars[9]);
            this.rotZ = Convert.ToSingle(pars[10]);
            this.rotW = Convert.ToSingle(pars[11]);
        }

        // 13 parameters
        private void VC_inst()
        {
            this.lod = 0;

            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.interior = Convert.ToSingle(pars[2]);

            this.posX = Convert.ToSingle(pars[3]);
            this.posY = Convert.ToSingle(pars[4]);
            this.posZ = Convert.ToSingle(pars[5]);

            this.scaleX = Convert.ToSingle(pars[6]);
            this.scaleY = Convert.ToSingle(pars[7]);
            this.scaleZ = Convert.ToSingle(pars[8]);

            this.rotX = Convert.ToSingle(pars[9]);
            this.rotY = Convert.ToSingle(pars[10]);
            this.rotZ = Convert.ToSingle(pars[11]);
            this.rotW = Convert.ToSingle(pars[12]);
        }

        // 11 parameters
        private void SA_inst()
        {
            this.interior = 0;
            this.scaleX = this.scaleY = this.scaleZ = 0;

            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.interior = Convert.ToSingle(pars[2]);

            this.posX = Convert.ToSingle(pars[3]);
            this.posY = Convert.ToSingle(pars[4]);
            this.posZ = Convert.ToSingle(pars[5]);

            this.rotX = Convert.ToSingle(pars[6]);
            this.rotY = Convert.ToSingle(pars[7]);
            this.rotZ = Convert.ToSingle(pars[8]);
            this.rotW = Convert.ToSingle(pars[9]);

            this.lod = Convert.ToInt32(pars[10]);
        }
    }
}
