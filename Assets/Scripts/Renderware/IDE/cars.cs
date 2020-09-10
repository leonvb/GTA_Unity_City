using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    enum CARS_TYPE
    {
        III_car,
        III_boat,
        III_train,
        III_heli,
        III_plane,

        VC_car,
        VC_boat,
        VC_heli,
        VC_plane,
        VC_bike,

        SA_vehicle
    }

    class cars
    {
        public int id;
        public string modelName;
        public string txdName;
        public string type;
        public string handlingId;
        public string gameName;
        public string anims; // VC
        public string vehicleClass;
        public int frq;
        public int lvl;
        public string comprules; // Read as hex

        // Car and Bike
        public int wheelModelId;
        public float wheelScale;

        // Plane
        public int lod;

        // Bike
        public int steeringAngle;

        public static cars Create(string[] pars, GTA_VERSION version)
        {
            string type = pars[3];

            if (version == GTA_VERSION.GTA3_4)
            {
                // Check III classes
                switch (type)
                {
                    case ("car"):
                        return new III_car(pars);

                    case ("boat"):
                        return new III_boat(pars);

                    case ("train"):
                        return new III_train(pars);

                    case ("heli"):
                        return new III_heli(pars);

                    case ("plane"):
                        return new III_plane(pars);
                } // end III switch
            } // endif
            else if (version == GTA_VERSION.VCPC)
            {
                // Check VC classes
                switch (type)
                {
                    case ("car"):
                        return new VC_car(pars);

                    case ("boat"):
                        return new VC_boat(pars);

                    case ("heli"):
                        return new VC_heli(pars);

                    case ("plane"):
                        return new VC_plane(pars);

                    case ("bike"):
                        return new VC_bike(pars);
                } // end VC switch
            } // end elseif

            return null;
        }
    }

    #region III
    // This region is for the GTA III classes
    class III_car : cars
    {
        public III_car(string[] pars)
        {
            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.txdName = pars[2];
            this.type = pars[3];
            this.handlingId = pars[4];
            this.gameName = pars[5];
            this.vehicleClass = pars[6];
            this.frq = Convert.ToInt32(pars[7]);
            this.lvl = Convert.ToInt32(pars[8]);
            this.comprules = pars[9];

            this.wheelModelId = Convert.ToInt32(pars[10]);
            this.wheelScale = Convert.ToSingle(pars[11]);
        }
    }

    class III_boat : cars
    {
        public III_boat(string[] pars)
        {
            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.txdName = pars[2];
            this.type = pars[3];
            this.handlingId = pars[4];
            this.gameName = pars[5];
            this.vehicleClass = pars[6];
            this.frq = Convert.ToInt32(pars[7]);
            this.lvl = Convert.ToInt32(pars[8]);
            this.comprules = pars[9];
        }
    }

    class III_train : cars
    {
        public III_train(string[] pars)
        {
            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.txdName = pars[2];
            this.type = pars[3];
            this.handlingId = pars[4];
            this.gameName = pars[5];
            this.vehicleClass = pars[6];
            this.frq = Convert.ToInt32(pars[7]);
            this.lvl = Convert.ToInt32(pars[8]);
            this.comprules = pars[9];
        }
    }

    class III_heli : cars
    {
        public III_heli(string[] pars)
        {
            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.txdName = pars[2];
            this.type = pars[3];
            this.handlingId = pars[4];
            this.gameName = pars[5];
            this.vehicleClass = pars[6];
            this.frq = Convert.ToInt32(pars[7]);
            this.lvl = Convert.ToInt32(pars[8]);
            this.comprules = pars[9];
        }
    }

    class III_plane : cars
    {
        public III_plane(string[] pars)
        {
            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.txdName = pars[2];
            this.type = pars[3];
            this.handlingId = pars[4];
            this.gameName = pars[5];
            this.vehicleClass = pars[6];
            this.frq = Convert.ToInt32(pars[7]);
            this.lvl = Convert.ToInt32(pars[8]);
            this.comprules = pars[9];

            this.lod = Convert.ToInt32(pars[10]);
        }
    }
    #endregion

    #region VC
    // This region is for the Vice City classes
    class VC_car : cars
    {
        public VC_car(string[] pars)
        {
            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.txdName = pars[2];
            this.type = pars[3];
            this.handlingId = pars[4];
            this.gameName = pars[5];
            this.anims = pars[6];
            this.vehicleClass = pars[7];
            this.frq = Convert.ToInt32(pars[8]);
            this.lvl = Convert.ToInt32(pars[9]);
            this.comprules = pars[10];

            this.wheelModelId = Convert.ToInt32(pars[11]);
            this.wheelScale = Convert.ToSingle(pars[12]);
        }
    }

    class VC_boat : cars
    {
        public VC_boat(string[] pars)
        {
            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.txdName = pars[2];
            this.type = pars[3];
            this.handlingId = pars[4];
            this.gameName = pars[5];
            this.anims = pars[6];
            this.vehicleClass = pars[7];
            this.frq = Convert.ToInt32(pars[8]);
            this.lvl = Convert.ToInt32(pars[9]);
            this.comprules = pars[10];
        }
    }

    class VC_heli : cars
    {
        public VC_heli(string[] pars){
            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.txdName = pars[2];
            this.type = pars[3];
            this.handlingId = pars[4];
            this.gameName = pars[5];
            this.anims = pars[6];
            this.vehicleClass = pars[7];
            this.frq = Convert.ToInt32(pars[8]);
            this.lvl = Convert.ToInt32(pars[9]);
            this.comprules = pars[10];
        }
    }

    class VC_plane : cars
    {
        public VC_plane(string[] pars)
        {
            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.txdName = pars[2];
            this.type = pars[3];
            this.handlingId = pars[4];
            this.gameName = pars[5];
            this.anims = pars[6];
            this.vehicleClass = pars[7];
            this.frq = Convert.ToInt32(pars[8]);
            this.lvl = Convert.ToInt32(pars[9]);
            this.comprules = pars[10];

            this.lod = Convert.ToInt32(pars[11]);
        }
    }

    class VC_bike : cars
    {
        public VC_bike(string[] pars)
        {
            this.id = Convert.ToInt32(pars[0]);
            this.modelName = pars[1];
            this.txdName = pars[2];
            this.type = pars[3];
            this.handlingId = pars[4];
            this.gameName = pars[5];
            this.anims = pars[6];
            this.vehicleClass = pars[7];
            this.frq = Convert.ToInt32(pars[8]);
            this.lvl = Convert.ToInt32(pars[9]);
            this.comprules = pars[10];

            this.steeringAngle = Convert.ToInt32(pars[11]);
            this.wheelScale = Convert.ToSingle(pars[12]);
        }
    }
    #endregion

    #region SA
    // This region is for the San Andreas classes
    #endregion
       
}
