using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GTAImgEditor
{
    enum IDE_SECTION
    {
        obj,
        tobj,
        hier,
        cars,
        peds,
        path,
        _2dfx,
        weap,
        anim,
        txdp,
        hand
    }

    class IDE
    {
        public List<objs> obj_list;
        public List<string> obj_index_lookup;

        public List<tobj> tobj_list;
        public List<string> tobj_index_lookup;

        public List<hier> hier_list;
        public List<cars> cars_list;
        public List<int> peds_list;
        public List<int> path_list;
        public List<fx2d> _2dfx_list;
        public List<int> weap_list;
        public List<int> txdp_list;
        public List<int> hand_list;

        IDE_SECTION readState;

        private string path;

        public IDE() 
        {
            obj_list = new List<objs>();
            obj_index_lookup = new List<string>();

            tobj_list = new List<tobj>();
            tobj_index_lookup = new List<string>();
        }

        public IDE(string _path)
        {
            obj_list = new List<objs>();
            obj_index_lookup = new List<string>();

            tobj_list = new List<tobj>();
            tobj_index_lookup = new List<string>();

            hier_list = new List<hier>();
            cars_list = new List<cars>();
            _2dfx_list = new List<fx2d>();

            path = Path.Combine(GTASettings.gta_path, _path);

            string line;
            StreamReader file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                if (line.Trim()[0] == '#' || line.Count() == 0) // If comment or empty line
                    continue;

                if (IsSectionHeading(line)) // If is a Section Heading word or "end"
                    continue;

                // Temporary: if check while sections are incomplete
                if (readState == IDE_SECTION.obj || readState == IDE_SECTION.tobj)
                {
                    string[] pars = Line.Split(line);
                    AddSectionLine(pars);
                }
            } 
        }

        public void Join(IDE ide)
        {
            this.obj_list.AddRange(ide.obj_list);
            this.tobj_list.AddRange(ide.tobj_list);
        }


        private bool IsSectionHeading(string line)
        {
            switch (line)
            {
                case ("objs"):
                    readState = IDE_SECTION.obj;
                    return true;

                case ("tobj"):
                    readState = IDE_SECTION.tobj;
                    return true;

                case ("hier"):
                    readState = IDE_SECTION.hier;
                    return true;

                case ("cars"):
                    readState = IDE_SECTION.cars;
                    return true;

                case ("peds"):
                    readState = IDE_SECTION.peds;
                    return true;

                case ("path"):
                    readState = IDE_SECTION.path;
                    return true;

                case ("2dfx"):
                    readState = IDE_SECTION._2dfx;
                    return true;

                case ("weap"):
                    readState = IDE_SECTION.weap;
                    return true;

                case ("txdp"):
                    readState = IDE_SECTION.txdp;
                    return true;

                case ("hand"):
                    readState = IDE_SECTION.hand;
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
                case (IDE_SECTION.obj):
                    obj_list.Add(objs.Create(pars));
                    obj_index_lookup.Add(pars[1]);
                    break;

                case (IDE_SECTION.tobj):
                    tobj_list.Add(tobj.Create(pars));
                    tobj_index_lookup.Add(pars[1]);
                    break;

                case (IDE_SECTION.hier):
                    hier_list.Add(hier.Create(pars));
                    break;

                case (IDE_SECTION.cars):
                    cars_list.Add(cars.Create(pars, GTASettings.version));
                    break;

                case (IDE_SECTION.peds):
                    break;

                case (IDE_SECTION.path):
                    break;

                case (IDE_SECTION._2dfx):
                    // Create 2dfx
                    break;

                case (IDE_SECTION.weap):
                    break;

                case (IDE_SECTION.txdp):
                    break;

                case (IDE_SECTION.hand):
                    break;
            }
        }
    }
}
