using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class DieselCar: DieselVehicle
    {
        private const eFuelType k_FuelType = eFuelType.Octan95;
        private const float k_MaxFuelLiters = 46f;

        private readonly Car r_Car;

        public DieselCar(
            string i_Model,
            string i_LicensePlate,
            List<Wheel> i_Wheels,
            Customer i_Owner,
            eVehicleStatus i_VehicleStatus,
        float i_FuelLitersLeft,
              eCarColor i_Color,
            eNumOfCarDoors i_NumOfDoors)
            : base(i_Model,
                i_LicensePlate,
                i_Wheels,
                i_Owner,
                i_VehicleStatus,
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

        public override void PrintVehicleDescription()
        {
            Console.WriteLine($"Licence Plate: {LicensePlate}");
        }
    }
}
