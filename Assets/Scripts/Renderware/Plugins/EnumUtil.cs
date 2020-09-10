using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    public static class EnumUtil
    {
        public static IEnumerable<T> GetValues<T>()
        {
            //return Enum.GetValues(typeof(T)).Cast<T>();
            return (T[])Enum.GetValues(typeof(T));
        }
    }
}
