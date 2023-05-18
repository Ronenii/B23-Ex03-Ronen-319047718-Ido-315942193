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
        private const float k_MaxChargeHours = 5.2f;

        private readonly Car r_Car;

        public ElectricCar(
            string i_Model,
            string i_LicensePlate,
            float i_EnergyLeft,
            string i_WheelManufacturer,
            float i_CurrentPSI,
            int i_NumOfWheels,
            float i_ChargeHoursLeft,
            eCarColor i_Color,
            eNumOfCarDoors i_NumOfDoors)
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
            r_Car = new Car(i_Color, i_NumOfDoors);
        }

        public eCarColor CarColor
        {
            get
            {
                return r_Car.Color;
            }
        }

        public eNumOfCarDoors NumOfCarDoors
        {
            get
            {
                return r_Car.NumOfDoors;
            }
        }
    }
}
