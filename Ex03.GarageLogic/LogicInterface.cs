using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class LogicInterface
    {
        private List<Vehicle> AllCars;

        public bool isCarAlreadyExist(String licencePlate)
        {
            bool isCarExist = false;
            foreach (Vehicle vehicle in AllCars)
            {
                if (vehicle.LicensePlate == licencePlate)
                {
                    isCarExist = true;
                }
            }
            return isCarExist;
        }
        public void AddNewCar()
        {

        }
    }
}
