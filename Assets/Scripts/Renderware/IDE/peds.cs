using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    enum III_CARGROUP
    {
        none = 0x00,
        poorfamily = 0x01,
        richfamily = 0x02,
        executive = 0x04,
        worker = 0x08,
        special = 0x10,
        big = 0x20,
        taxi = 0x40
    }

    enum VC_CARGROUP
    {
        none = 0x000,
        normal = 0x001,
        poorfamily = 0x002,
        richfamily = 0x004,
        executive = 0x008,
        worker = 0x010,
        big = 0x020,
        taxi = 0x040,
        mopen = 0x080,
        motorbike = 0x100,
        leisureboat = 0x200,
        workerboat = 0x400
    }

    class peds
    {
        public int id;
        public string modelName;
        public string txdName;
        public string defPedType;
        public string behaviour;
        public string animGroup;
        public string carsCanDriveMask; // Read as hex

        public string animFile;
        public int radio1;
        public int radio2;

        public static peds Create(string[] pars)
        {
            if (pars.Count() == 7)
            {
                // Create III ped
                return new III_ped(pars);
            }
            else if (pars.Count() == 10)
            {
                // Create VC ped
                return new VC_ped(pars);
            }

            return null;
        }
    }

    class III_ped : peds
    {
        public III_ped(string[] pars)
        {
            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.txdName = pars[2];
            this.defPedType = pars[3];
            this.behaviour = pars[4];
            this.animGroup = pars[5];
            this.carsCanDriveMask = pars[6];
        }
    }

    class VC_ped : peds
    {
        public VC_ped(string[] pars)
        {
            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.txdName = pars[2];
            this.defPedType = pars[3];
            this.behaviour = pars[4];
            this.animGroup = pars[5];
            this.carsCanDriveMask = pars[6];
            this.animFile = pars[7];
            this.radio1 = Convert.ToInt32(pars[8]);
            this.radio2 = Convert.ToInt32(pars[9]);
        }
    }

}
