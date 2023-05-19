using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class DieselCar: DieselVehicle
    {
        private const int k_NumOfWheels = 5;
        private const float k_MaxPSI = 33f;
        private const eFuelType k_FuelType = eFuelType.Octan95;
        private const float k_MaxFuelLiters = 46f;

        private readonly Car r_Car;

        public DieselCar(
            string i_Model,
            string i_LicensePlate,
            float i_EnergyLeft,
            string i_WheelManufacturer,
            float i_CurrentPSI,
            int i_NumOfWheels,
            float i_FuelLitersLeft,
            eCarColor i_Color,
            eNumOfCarDoors i_NumOfDoors)
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
            r_Car = new Car(i_Color, i_NumOfDoors);
        }

        public eCarColor Color
        {
            get
            {
                return r_Car.Color;
            }
        }

        public eNumOfCarDoors NumOfDoors
        {
            get
            {
                return r_Car.NumOfDoors;
            }
        }
    }
}
