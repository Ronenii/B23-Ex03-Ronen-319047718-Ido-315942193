using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class DieselBike : DieselVehicle
    {
        private const eFuelType k_FuelType = eFuelType.Octan98;
        private const float k_MaxFuelLiters = 6.4f;

        private readonly Bike r_Bike;

        public DieselBike(
            string i_Model,
            string i_LicensePlate,
            List<Wheel> i_Wheels,
            Customer i_Owner,
            eVehicleStatus i_VehicleStatus,
            float i_FuelLitersLeft,
            eBikeLicense i_License,
            int i_EngineSize)
            : base(i_Model, i_LicensePlate, i_Wheels, i_Owner, i_VehicleStatus, i_FuelLitersLeft, k_MaxFuelLiters, k_FuelType)
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
            throw new NotImplementedException();
        }
    }
}
