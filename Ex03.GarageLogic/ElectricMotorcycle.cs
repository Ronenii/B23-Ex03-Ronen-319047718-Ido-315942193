using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        private const float k_MaxChargeHours = 2.6f;

        private readonly MotorcycleProperties r_MotorcycleProperties;

        public ElectricMotorcycle(
            string i_Model,
            string i_LicensePlate,
            List<Wheel> i_Wheels,
            Customer i_Owner,
            eVehicleStatus i_VehicleStatus,
            float i_ChargeHoursLeft,
            eMotorcycleLicense i_License,
            int i_EngineSize)
            : base(
                i_Model,
                i_LicensePlate,
                i_Wheels,
                i_Owner,
                i_VehicleStatus,
                i_ChargeHoursLeft,
                k_MaxChargeHours)
        {
            r_MotorcycleProperties = new MotorcycleProperties(i_License, i_EngineSize);
        }

        public eMotorcycleLicense License
        {
            get
            {
                return r_MotorcycleProperties.License;
            }
        }

        public int EngineSize
        {
            get
            {
                return r_MotorcycleProperties.EngineSize;
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
