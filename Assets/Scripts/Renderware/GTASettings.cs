using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GTAImgEditor
{
    class GTASettings
    {
        public static GTA_VERSION version = GTA_VERSION.VCPC;
        public static string gta_path = @"C:\Program Files (x86)\Steam\steamapps\common\Grand Theft Auto Vice City";
        public static string gta_dat_path;

        public static string GTA3IMG = @"models\gta3.img";

        private static string III_dat = @"data\gta3.dat";
        private static string VC_dat = @"data\gta_vc.dat";
        private static string SA_dat = @"data\gta.dat";

        static GTASettings()
        {
            // Create the path for the required GTA .dat file
            switch (version)
            {
                case GTA_VERSION.GTA3_1:
                case GTA_VERSION.GTA3_2:
                case GTA_VERSION.GTA3_3:
                case GTA_VERSION.GTA3_4:
                    gta_dat_path = Path.Combine(gta_path, III_dat);
                    break;
                case GTA_VERSION.VCPC:
                    gta_dat_path = Path.Combine(gta_path, VC_dat);
                    break;
                case GTA_VERSION.SA:
                    gta_dat_path = Path.Combine(gta_path, SA_dat);
                    break;
                default:
                    throw new Exception("Invalid GTA version. Unable to find gta.dat file");
            }

        }
    }
}
