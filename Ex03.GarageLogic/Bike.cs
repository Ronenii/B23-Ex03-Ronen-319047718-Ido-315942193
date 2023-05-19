using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Bike
    {
        private readonly eBikeLicense r_License;
        private readonly int r_EngineSize;

        public Bike(eBikeLicense i_License, int i_EngineSize)
        {
            r_License = i_License;
            r_EngineSize = i_EngineSize;
        }

        public eBikeLicense License
        {
            get
            {
                return r_License;
            }
        }

        public int EngineSize
        {
            get
            {
                return r_EngineSize;
            }
        }
    }
}
