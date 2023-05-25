using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eTransportingHazardousMaterial
    {
        Yes = 1,
        No = 2
    }
    public class Truck : DieselVehicle
    {
        private const eFuelType k_FuelType = eFuelType.Soler;
        public static readonly float k_MaxFuelLiters = 135f;

        private readonly TruckProperties r_truckProperties;

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
            r_truckProperties = new TruckProperties(i_IsTransportingHazardousMaterial, i_CargoSize);
        }

        public bool IsTransportingHazardousMaterial
        {
            get
            {
                return r_truckProperties.IsTransportingHazardousMaterial;
            }
        }

        public float CargoSize
        {
            get
            {
                return r_truckProperties.CargoSize;
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

        public TruckProperties TruckProperties
        {
            get
            {
                return r_truckProperties;
            }
        }
    }
}
