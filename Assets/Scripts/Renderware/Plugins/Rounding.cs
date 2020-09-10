using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    public static class Rounding
    {
        public static float RoundToThree(float value)
        {
            double m = value;
            m = Math.Truncate(m * 1000) / 1000;
            return (float)m;
        }
    }
}
