using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : DieselVehicle
    {
        private const int k_NumOfWheels = 14;
        private const float k_MaxPSI = 26f;
        private const eFuelType k_FuelType = eFuelType.Soler;
        private const float k_MaxFuelLiters = 135f;

        private readonly bool r_IsTransportingHazardousMaterial;
        private readonly float r_CargoSize;

        public Truck(
            string i_Model,
            string i_LicensePlate,
            float i_EnergyLeft,
            List<Wheel> i_Wheels,
            Customer i_Owner,
            eVehicleStatus i_VehicleStatus,
            float i_FuelLitersLeft,
            bool i_IsTransportingHazardousMaterial,
            float i_CargoSize)
            : base(i_Model,
                i_LicensePlate,
                i_EnergyLeft,
                i_Wheels,
                i_Owner,
                i_VehicleStatus,
                i_FuelLitersLeft,
                k_MaxFuelLiters, 
                k_FuelType)
        {
            r_IsTransportingHazardousMaterial = i_IsTransportingHazardousMaterial;
            r_CargoSize = i_CargoSize;
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
                return CargoSize;
            }
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

        public override void PrintVehicleDescription()
        {
            throw new NotImplementedException();
        }
    }
}
