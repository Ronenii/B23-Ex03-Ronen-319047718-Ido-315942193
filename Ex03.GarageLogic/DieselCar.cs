using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eCarColor
    {
        White,
        Black,
        Yellow,
        Red
    }

    public enum eNumOfCarDoors
    {
        Two =2,
        Three,
        Four,
        Five
    }

    class DieselCar: DieselVehicle
    {
        private const int k_NumOfWheels = 5;
        private const float k_MaxPSI = 33f;
        private const eFuelType k_FuelType = eFuelType.Octan95;
        private const float k_MaxFuelLiters = 46f;

        private readonly eNumOfCarDoors r_NumOfCarDoors;
        private readonly eCarColor r_CarColor;

        public DieselCar(
            string i_Model,
            string i_LicensePlate,
            float i_EnergyLeft,
            string i_WheelManufacturer,
            float i_CurrentPSI,
            int i_NumOfWheels,
            float i_FuelLitersLeft,
            eCarColor i_CarColor,
            eNumOfCarDoors i_NumOfCarDoors)
            : base(i_Model,
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
            r_NumOfCarDoors = i_NumOfCarDoors;
            r_CarColor = i_CarColor;
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
