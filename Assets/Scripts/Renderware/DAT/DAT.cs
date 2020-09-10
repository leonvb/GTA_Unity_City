using System.Collections.Generic;
using System.IO;

namespace GTAImgEditor
{
    class DAT
    {
        public Dictionary<string, string> IDE_paths;
        public Dictionary<string, string> IPL_paths;
        public Dictionary<string, string> COLFILE_paths;
        public List<string> SPLASH_paths;
        public List<string> MAPZONE_paths;
        public List<string> TEXDICTION_paths;
        public List<string> MODELFILE_paths;
        public List<string> HIERFILE_paths;
        public Dictionary<string, string> ZON_paths;

        public DAT(string path)
        {
            IDE_paths = new Dictionary<string, string>();
            IPL_paths = new Dictionary<string, string>();
            COLFILE_paths = new Dictionary<string, string>();
            SPLASH_paths = new List<string>();
            MAPZONE_paths = new List<string>();
            TEXDICTION_paths = new List<string>();
            MODELFILE_paths = new List<string>();
            HIERFILE_paths = new List<string>();
            ZON_paths = new Dictionary<string, string>();

            string line;
            StreamReader file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                if (line == string.Empty) continue;
                if (line[0] == '#') continue;

                string[] split = line.Split(' ');

                switch (split[0])
                {
                    case ("IDE"):
                        IDE_paths.Add(Path.GetFileName(split[1]), split[1]);
                        break;

                    case ("IPL"):
                        if (Path.GetExtension(split[1]) == ".ZON")
                            ZON_paths.Add(Path.GetFileName(split[1]), split[1]);
                        else
                            IPL_paths.Add(Path.GetFileName(split[1]), split[1]);
                        break;

                    case ("SPLASH"):
                        SPLASH_paths.Add(split[1]);
                        break;

                    case ("MAPZONE"): // GTA III
                        MAPZONE_paths.Add(split[1]);
                        break;

                    case ("COLFILE"):
                        COLFILE_paths.Add(Path.GetFileName(split[2]), split[2]);
                        break;

                    case ("TEXDICTION"):
                        TEXDICTION_paths.Add(split[1]);
                        break;

                    case ("MODELFILE"):
                        MODELFILE_paths.Add(split[1]);
                        break;

                    case ("HIERFILE"):
                        HIERFILE_paths.Add(split[1]);
                        break;

                    default:
                        break;
                }

            } // Switch end

            file.Close();
        }
    }
}
