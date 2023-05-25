using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class DieselMotorcycle : DieselVehicle
    {
        private const eFuelType k_FuelType = eFuelType.Octan98;
        public static readonly float k_MaxFuelLiters = 6.4f;

        private readonly MotorcycleProperties r_MotorcycleProperties;

        public DieselMotorcycle(
            string i_Model,
            string i_LicensePlate,
            List<Wheel> i_Wheels,
            Customer i_Owner,
            eVehicleStatus i_VehicleStatus,
            float i_FuelLitersLeft,
            eMotorcycleLicense i_License,
            int i_EngineSize)
            : base(i_Model, i_LicensePlate, i_Wheels, i_Owner, i_VehicleStatus, i_FuelLitersLeft, k_MaxFuelLiters, k_FuelType)
        {
            r_MotorcycleProperties = new MotorcycleProperties(i_License, i_EngineSize);
        }

        public int EngineSize
        {
            get
            {
                return r_MotorcycleProperties.EngineSize;
            }
        }

        public eMotorcycleLicense License
        {
            get
            {
                return r_MotorcycleProperties.License;
            }
        }

        public MotorcycleProperties MotorcycleProperties
        {
            get
            {
                return r_MotorcycleProperties;
            }
        }
    }
}
