using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    static class Line
    {
        public static string[] Split(string line)
        {
            string[] pars = line.Split(',');

            for (int i = 0; i < pars.Count(); i++)
            {
                pars[i] = pars[i].Trim();
            }

            return pars;
        }
    }
}
