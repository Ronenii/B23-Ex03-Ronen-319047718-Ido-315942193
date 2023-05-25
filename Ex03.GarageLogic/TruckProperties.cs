using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class TruckProperties
    {
        private const int k_NumOfWheels = 14;
        private const float k_MaxPSI = 26f;

        private readonly bool r_IsTransportingHazardousMaterial;
        private readonly float r_CargoSize;

        public TruckProperties(bool i_IsTransportingHazardousMaterial, float i_CargoSize)
        {
            r_IsTransportingHazardousMaterial = i_IsTransportingHazardousMaterial;
            r_CargoSize = i_CargoSize;
        }

        public static int NumOfWheels
        {
            get
            {
                return k_NumOfWheels;
            }
        }

        public static float MaxPSI
        {
            get
            {
                return k_MaxPSI;
            }
        }

        public bool IsTransportingHazardousMaterial
        {
            get
            {
                return r_IsTransportingHazardousMaterial;
            }
        }

        public float CargoSize
        {
            get
            {
                return r_CargoSize;
            }
        }
    }
}
