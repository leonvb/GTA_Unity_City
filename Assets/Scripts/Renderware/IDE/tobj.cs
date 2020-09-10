using System;
using System.Linq;

namespace GTAImgEditor
{
    enum TOBJ_TYPE
    {
        type1 = 8,
        type2 = 9,
        type3 = 10,
        type4 = 7
    }

    class tobj
    {
        public int id;
        public string modelName;
        public string txdName;
        public int meshCount;
        public int drawDistance1;
        public int drawDistance2;
        public int drawDistance3;
        public int flags;
        public int timeOn;
        public int timeOff;

        public ArchiveFile dff;

        public static tobj Create(string[] pars)
        {
            switch (pars.Count())
            {
                case ((int)TOBJ_TYPE.type1):
                    return new tobj_type1(pars);

                case ((int)TOBJ_TYPE.type2):
                    return new tobj_type2(pars);

                case ((int)TOBJ_TYPE.type3):
                    return new tobj_type3(pars);

                case ((int)TOBJ_TYPE.type4):
                    return new tobj_type4(pars);

                default:
                    return null;
            }
        }
    }

    class tobj_type1 : tobj
    {
        public tobj_type1(string[] par)
        {
            this.id = Convert.ToInt32(par[0]);
            this.modelName = par[1];
            this.txdName = par[2];
            this.meshCount = Convert.ToInt32(par[3]);
            this.drawDistance1 = Convert.ToInt32(par[4]);
            this.flags = Convert.ToInt32(par[5]);
            this.timeOn = Convert.ToInt32(par[6]);
            this.timeOff = Convert.ToInt32(par[7]);
        }
    }

    class tobj_type2 : tobj
    {
        public tobj_type2(string[] par)
        {
            this.id = Convert.ToInt32(par[0]);
            this.modelName = par[1];
            this.txdName = par[2];
            this.meshCount = Convert.ToInt32(par[3]);
            this.drawDistance1 = Convert.ToInt32(par[4]);
            this.drawDistance2 = Convert.ToInt32(par[5]);
            this.flags = Convert.ToInt32(par[6]);
            this.timeOn = Convert.ToInt32(par[7]);
            this.timeOff = Convert.ToInt32(par[8]);
        }
    }

    class tobj_type3 : tobj
    {
        public tobj_type3(string[] par)
        {
            this.id = Convert.ToInt32(par[0]);
            this.modelName = par[1];
            this.txdName = par[2];
            this.meshCount = Convert.ToInt32(par[3]);
            this.drawDistance1 = Convert.ToInt32(par[4]);
            this.drawDistance2 = Convert.ToInt32(par[5]);
            this.drawDistance3 = Convert.ToInt32(par[6]);
            this.flags = Convert.ToInt32(par[7]);
            this.timeOn = Convert.ToInt32(par[8]);
            this.timeOff = Convert.ToInt32(par[9]);
        }
    }

    class tobj_type4 : tobj
    {
        public tobj_type4(string[] par)
        {
            this.id = Convert.ToInt32(par[0]);
            this.modelName = par[1];
            this.txdName = par[2];
            this.drawDistance1 = Convert.ToInt32(par[3]);
            this.flags = Convert.ToInt32(par[4]);
            this.timeOn = Convert.ToInt32(par[5]);
            this.timeOff = Convert.ToInt32(par[6]);
        }
    }
}
