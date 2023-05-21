using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricBike : ElectricVehicle
    {
        private const float k_MaxChargeHours = 2.6f;

        private readonly Bike r_Bike;

        public ElectricBike(
            string i_Model,
            string i_LicensePlate,
            float i_EnergyLeft,
            List<Wheel> i_Wheels,
            Customer i_Owner,
            eVehicleStatus i_VehicleStatus,
            float i_ChargeHoursLeft,
            eBikeLicense i_License,
            int i_EngineSize)
            : base(
                i_Model,
                i_LicensePlate,
                i_EnergyLeft,
                i_Wheels,
                i_Owner,
                i_VehicleStatus,
                i_ChargeHoursLeft,
                k_MaxChargeHours)
        {
            r_Bike = new Bike(i_License, i_EngineSize);
        }

        public eBikeLicense License
        {
            get
            {
                return r_Bike.License;
            }
        }

        public int EngineSize
        {
            get
            {
                return r_Bike.EngineSize;
            }
        }
    }
}
