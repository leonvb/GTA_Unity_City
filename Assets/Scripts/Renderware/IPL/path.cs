using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GTAImgEditor
{
    class path
    {
        public string groupType;
        public int id;
        public string modelName;
        public List<path_node> nodes;

        private string[] pars;

        public path(string[] pars, ref StreamReader file)
        {
            this.pars = pars;

            if (pars.Count() == 3)
                path1(ref file);
            else if (pars.Count() == 2)
                path2(ref file);
        }

        private void path1(ref StreamReader file)
        {
            this.groupType = pars[0];
            this.id = Convert.ToInt32(pars[1]);
            this.modelName = pars[3];

            read_nodes(ref file);
        }

        private void path2(ref StreamReader file)
        {
            this.groupType = pars[0];
            this.id = Convert.ToInt32(pars[1]);
            this.modelName = string.Empty;

            read_nodes(ref file);
        }

        private void read_nodes(ref StreamReader file)
        {
            for (int i = 0; i < 12; i++)
            {
                string line = file.ReadLine();
                if (line == "end") break;
                string[] nodePars = Line.Split(line);
                this.nodes.Add(new path_node(nodePars));
            }
        }
    }

    class path_node
    {
        public int nodeType;
        public int nextNode;
        public int isCrossRoad;
        public float x, y, z;
        public float median;
        public int leftLanes;
        public int rightLanes;

        public int speedLimit;
        public int flags;
        public float spawnRate;

        private string[] pars;

        public path_node(string[] pars)
        {
            this.pars = pars;

            if (pars.Count() == 9)
                path_node1();
            else // if pars count == 12
                path_node2();
        }

        private void path_node1()
        {
            this.nodeType = Convert.ToInt32(pars[0]);
            this.nextNode = Convert.ToInt32(pars[1]);
            this.isCrossRoad = Convert.ToInt32(pars[2]);

            this.x = Convert.ToSingle(pars[3]);
            this.y = Convert.ToSingle(pars[4]);
            this.z = Convert.ToSingle(pars[5]);

            this.median = Convert.ToSingle(pars[6]);

            this.leftLanes = Convert.ToInt32(pars[7]);
            this.rightLanes = Convert.ToInt32(pars[8]);

            this.speedLimit = 0;
            this.flags = 0;
            this.spawnRate = 0;
        }

        private void path_node2()
        {
            this.nodeType = Convert.ToInt32(pars[0]);
            this.nextNode = Convert.ToInt32(pars[1]);
            this.isCrossRoad = Convert.ToInt32(pars[2]);

            this.x = Convert.ToSingle(pars[3]);
            this.y = Convert.ToSingle(pars[4]);
            this.z = Convert.ToSingle(pars[5]);

            this.median = Convert.ToSingle(pars[6]);

            this.leftLanes = Convert.ToInt32(pars[7]);
            this.rightLanes = Convert.ToInt32(pars[8]);

            this.speedLimit = Convert.ToInt32(pars[9]);
            this.flags = Convert.ToInt32(pars[10]);
            this.spawnRate = Convert.ToSingle(pars[11]);
        }
    }   
}
