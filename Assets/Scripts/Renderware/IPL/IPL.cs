using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GTAImgEditor
{
    enum IPL_SECTION
    {
        inst,
        zone,
        cull,
        pick,
        path,
        occl,
        mult,
        grge,
        enex,
        cars,
        jump,
        tcyc,
        auzo,
        mzon
    }

    class IPL
    {
        public List<inst> inst_list;
        public List<zon> zon_list;
        public List<cull> cull_list;
        public List<occl> occl_list;
        public List<path> path_list;

        private IPL_SECTION readState;
        private StreamReader file;
        private string path;

        public IPL()
        {
            inst_list = new List<inst>();
            zon_list = new List<zon>();
            cull_list = new List<cull>();
            occl_list = new List<occl>();
            path_list = new List<path>();
        }

        public IPL(string _path)
        {
            inst_list = new List<inst>();
            zon_list = new List<zon>();
            cull_list = new List<cull>();
            occl_list = new List<occl>();
            path_list = new List<path>();

            path = Path.Combine(GTASettings.gta_path, _path);

            string line;
            file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                if (line.Count() == 0 || line.Trim()[0] == '#') // If comment or empty line
                    continue;

                if (IsSectionHeading(line)) // If is Section Heading word or "end"
                    continue;

                string[] pars = Line.Split(line);
                AddSectionLine(pars);
            }
        }

        public void Join(IPL ipl)
        {
            this.inst_list.AddRange(ipl.inst_list);
            this.zon_list.AddRange(ipl.zon_list);
            this.cull_list.AddRange(ipl.cull_list);
            this.occl_list.AddRange(ipl.occl_list);
            this.path_list.AddRange(ipl.path_list);
        }

        private bool IsSectionHeading(string line)
        {
            switch (line)
            {
                case ("inst"):
                    readState = IPL_SECTION.inst;
                    return true;

                case ("zone"):
                    readState = IPL_SECTION.zone;
                    return true;

                case ("cull"):
                    readState = IPL_SECTION.cull;
                    return true;

                case ("pick"):
                    readState = IPL_SECTION.pick;
                    return true;

                case ("path"):
                    readState = IPL_SECTION.path;
                    return true;

                case ("occl"):
                    readState = IPL_SECTION.occl;
                    return true;

                case ("mult"):
                    readState = IPL_SECTION.mult;
                    return true;

                case ("grge"):
                    readState = IPL_SECTION.grge;
                    return true;

                case ("enex"):
                    readState = IPL_SECTION.enex;
                    return true;

                case ("cars"):
                    readState = IPL_SECTION.cars;
                    return true;

                case ("jump"):
                    readState = IPL_SECTION.jump;
                    return true;

                case ("tcyc"):
                    readState = IPL_SECTION.tcyc;
                    return true;

                case ("auzo"):
                    readState = IPL_SECTION.auzo;
                    return true;

                case ("mzon"):
                    readState = IPL_SECTION.mzon;
                    return true;

                case ("end"):
                    return true;

                default:
                    return false;
            }
        }

        private void AddSectionLine(string[] pars)
        {
            switch (readState)
            {
                case (IPL_SECTION.inst):
                    inst_list.Add(new inst(pars));
                    break;

                case (IPL_SECTION.zone):
                    zon_list.Add(new zon(pars));
                    break;

                case (IPL_SECTION.cull):
                    cull_list.Add(new cull(pars));
                    break;

                case (IPL_SECTION.occl):
                    occl_list.Add(new occl(pars));
                    break;

                case (IPL_SECTION.path):
                    path_list.Add(new path(pars, ref file));
                    break;
            }
        }
    }
}
