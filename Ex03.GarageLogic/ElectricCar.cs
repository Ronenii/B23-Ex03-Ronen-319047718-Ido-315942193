using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar: ElectricVehicle
    {
        private const float k_MaxChargeHours = 5.2f;

        private readonly Car r_Car;

        public ElectricCar(
            string i_Model,
            string i_LicensePlate,
            float i_EnergyLeft,
            List<Wheel> i_Wheels,
            Customer i_Owner,
            eVehicleStatus i_VehicleStatus,
            float i_ChargeHoursLeft,
            eCarColor i_Color,
            eNumOfCarDoors i_NumOfDoors)
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

        public Car CarProperties
        {
            get
            {
                return r_Car;
            }
        }
    }
}
