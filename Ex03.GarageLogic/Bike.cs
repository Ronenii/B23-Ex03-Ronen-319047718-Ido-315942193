using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Bike
    {
        public const int k_NumOfWheels = 2;
        private const float k_MaxPSI = 31f;

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

        public static float MaxPSI
        {
            get
            {
                return k_MaxPSI;
            }
        }

        public static int NumOfWheels
        {
            get
            {
                return k_NumOfWheels;
            }
        }



        public string LicenseToString()
        {
            string license;
            switch (r_License)
            {
                case eBikeLicense.A1:
                    license = "A1";
                    break;
                case eBikeLicense.A2:
                    license = "A2";
                    break;
                case eBikeLicense.AA:
                    license = "AA";
                    break;
                case eBikeLicense.B1:
                    license = "B1";
                    break;
                default:
                    license = string.Empty;
                    break;
            }

            return license;
        }
    }
}
