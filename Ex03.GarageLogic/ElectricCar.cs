using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar: ElectricVehicle
    {
        private const float k_MaxChargeHours = 5.2f;

        private readonly CarProperties r_CarProperties;

        public ElectricCar(
            string i_Model,
            string i_LicensePlate,
            List<Wheel> i_Wheels,
            Customer i_Owner,
            eVehicleStatus i_VehicleStatus,
            float i_ChargeHoursLeft,
            eCarColor i_Color,
            eNumOfCarDoors i_NumOfDoors)
            : base(
                i_Model,
                i_LicensePlate,
                i_Wheels,
                i_Owner,
                i_VehicleStatus,
                i_ChargeHoursLeft,
                k_MaxChargeHours)
        {
            r_CarProperties = new CarProperties(i_Color, i_NumOfDoors);
        }

        public eCarColor CarColor
        {
            get
            {
                return r_CarProperties.Color;
            }
        }

        public eNumOfCarDoors NumOfCarDoors
        {
            get
            {
                return r_CarProperties.NumOfDoors;
            }
        }

        public CarProperties CarProperties
        {
            get
            {
                return r_CarProperties;
            }
        }
    }
}
