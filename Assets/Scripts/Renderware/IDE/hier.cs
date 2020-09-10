using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class hier
    {
        public int id;
        public string modelName;
        public string txdName;

        public static hier Create(string[] pars)
        {
            hier hier = new hier();

            hier.id = Convert.ToInt32(pars[0]);
            hier.modelName = pars[1];
            hier.txdName = pars[2];

            return hier;
        }
    }
}
