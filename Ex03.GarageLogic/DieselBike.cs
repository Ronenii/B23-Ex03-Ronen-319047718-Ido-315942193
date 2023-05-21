using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class DieselBike : DieselVehicle
    {
        private const int k_NumOfWheels = 2;
        private const float k_MaxPSI = 31f;
        private const eFuelType k_FuelType = eFuelType.Octan98;
        private const float k_MaxFuelLiters = 6.4f;

        private readonly Bike r_Bike;

        public DieselBike(
            string i_Model,
            string i_LicensePlate,
            float i_EnergyLeft,
            string i_WheelManufacturer,
            float i_CurrentPSI,
            int i_NumOfWheels,
            float i_FuelLitersLeft,
            eBikeLicense i_License,
            int i_EngineSize)
            : base(
                i_Model,
                i_LicensePlate,
                i_EnergyLeft,
                k_MaxPSI,
                i_WheelManufacturer,
                i_CurrentPSI,
                k_NumOfWheels,
                i_FuelLitersLeft,
                k_MaxFuelLiters,
                k_FuelType)
        {
            r_Bike = new Bike(i_License, i_EngineSize);
        }

        public int EngineSize
        {
            get
            {
                return r_Bike.EngineSize;
            }
        }

        public eBikeLicense License
        {
            get
            {
                return r_Bike.License;
            }
        }

        public override void PrintVehicleDescription()
        {
            base.PrintVehicleDescription()
            Console.WriteLine(); ;
        }

    }
}
