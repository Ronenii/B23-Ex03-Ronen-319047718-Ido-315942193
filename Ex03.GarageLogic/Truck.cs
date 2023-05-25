using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : DieselVehicle
    {
        private const eFuelType k_FuelType = eFuelType.Soler;
        private const float k_MaxFuelLiters = 135f;

        private TruckProperties r_TruckProperties;

        public Truck(
            string i_Model,
            string i_LicensePlate,
            List<Wheel> i_Wheels,
            Customer i_Owner,
            eVehicleStatus i_VehicleStatus,
            float i_FuelLitersLeft,
            bool i_IsTransportingHazardousMaterial,
            float i_CargoSize)
            : base(i_Model,
                i_LicensePlate,
                i_Wheels,
                i_Owner,
                i_VehicleStatus,
                i_FuelLitersLeft,
                k_MaxFuelLiters, 
                k_FuelType)
        {
            r_TruckProperties = new TruckProperties(i_IsTransportingHazardousMaterial, i_CargoSize);
        }

        public bool IsTransportingHazardousMaterial
        {
            get
            {
                return r_TruckProperties.IsTransportingHazardousMaterial;
            }
        }

        public float CargoSize
        {
            get
            {
                return r_TruckProperties.CargoSize;
            }
        }

        public int NumOfWheels
        {
            get
            {
                return TruckProperties.NumOfWheels;
            }
        }

        public float MaxPSI
        {
            get
            {
                return TruckProperties.MaxPSI;
            }
        }

        public string IsTransportingHazardousMaterialToString()
        {
            string yesOrNo = string.Empty;
            if (IsTransportingHazardousMaterial)
            {
                yesOrNo = "Yes";
            }
            else
            {
                yesOrNo = "No";
            }

            return yesOrNo;
        }
    }
}
