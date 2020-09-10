using System;
using System.Linq;

namespace GTAImgEditor
{
    enum OBJS_TYPE
    {
        type1 = 6,
        type2 = 7,
        type3 = 8,
        type4 = 5
    }

    class objs
    {
        public int id;
        public string modelName;
        public string txdName;
        public int meshCount;
        public float drawDistance1;
        public float drawDistance2;
        public float drawDistance3;
        public int flags;

        public ArchiveFile dff;


        public static objs Create(string[] pars)
        {
            switch (pars.Count())
            {
                case ((int)OBJS_TYPE.type1):
                    return new obj_type1(pars);

                case ((int)OBJS_TYPE.type2):
                    return new obj_type2(pars);

                case ((int)OBJS_TYPE.type3):
                    return new obj_type3(pars);

                case ((int)OBJS_TYPE.type4):
                    return new obj_type4(pars);

                default:
                    return null;
            }
        }
    }

    class obj_type1 : objs
    {
        public obj_type1(string[] pars)
        {
            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.txdName = pars[2];
            this.meshCount = Convert.ToInt32(pars[3]);
            this.drawDistance1 = Convert.ToSingle(pars[4]);
            this.flags = Convert.ToInt32(pars[5]);
        }
    }

    class obj_type2 : objs
    {
        public obj_type2(string[] pars)
        {
            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.txdName = pars[2];
            this.meshCount = Convert.ToInt32(pars[3]);
            this.drawDistance1 = Convert.ToSingle(pars[4]);
            this.drawDistance2 = Convert.ToSingle(pars[5]);
            this.flags = Convert.ToInt32(pars[6]);
        }
    }

    class obj_type3 : objs
    {
        public obj_type3(string[] pars)
        {
            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.txdName = pars[2];
            this.meshCount = Convert.ToInt32(pars[3]);
            this.drawDistance1 = Convert.ToSingle(pars[4]);
            this.drawDistance2 = Convert.ToSingle(pars[5]);
            this.drawDistance3 = Convert.ToSingle(pars[6]);
            this.flags = Convert.ToInt32(pars[7]);
        }
    }

    class obj_type4 : objs
    {
        public obj_type4(string[] pars)
        {
            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.txdName = pars[2];
            this.drawDistance1 = Convert.ToInt32(pars[3]);
            this.flags = Convert.ToInt32(pars[4]);
        }
    }
}
