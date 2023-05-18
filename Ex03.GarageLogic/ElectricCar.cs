using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricCar: ElectricVehicle
    {
        private const int k_NumOfWheels = 5;
        private const float k_MaxPSI = 33f;
        private const float k_MaxChargeHours = 2.6f;

        private readonly eCarColor r_CarColor;
        private readonly eNumOfCarDoors r_NumOfCarDoors;

        public ElectricCar(
            string i_Model,
            string i_LicensePlate,
            float i_EnergyLeft,
            string i_WheelManufacturer,
            float i_CurrentPSI,
            int i_NumOfWheels,
            float i_ChargeHoursLeft,
            eCarColor i_CarColor,
            eNumOfCarDoors i_NumOfCarDoors)
            : base(
                i_Model,
                i_LicensePlate,
                i_EnergyLeft,
                k_MaxPSI,
                i_WheelManufacturer,
                i_CurrentPSI,
                k_NumOfWheels,
                i_ChargeHoursLeft,
                k_MaxChargeHours)
        {
            r_CarColor = i_CarColor;
            r_NumOfCarDoors = i_NumOfCarDoors;
        }

        public eCarColor CarColor
        {
            get
            {
                return r_CarColor;
            }
        }

        public eNumOfCarDoors NumOfCarDoors
        {
            get
            {
                return r_NumOfCarDoors;
            }
        }
    }
}
