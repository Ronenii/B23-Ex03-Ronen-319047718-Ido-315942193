using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private List<Vehicle> AllVehicles;

        public void AddNewVehicle(Vehicle vehicle)
        {
            AllVehicles.Add(vehicle);
        }

        public Vehicle GetVehicleByLicense(string i_LicencePlate)
        {
            Vehicle returnVehicle = null;
            foreach (Vehicle vehicle in AllVehicles)
            {
                if (vehicle.LicensePlate == i_LicencePlate)
                {
                    returnVehicle = vehicle;
                }
            }
            return returnVehicle;
        }

        public void UpdateVehicleStatus(string i_LicensePlate, eVehicleStatus i_Status)
        {
            Vehicle vehicle = GetVehicleByLicense(i_LicensePlate);
            if(vehicle == null)
            {
                throw new Exception();
            }
            vehicle.Status = i_Status;
        }

        public void DisplayVehicleDetails(string i_LicensePlate)
        {
           Vehicle vehicle = GetVehicleByLicense(i_LicensePlate);
            vehicle.PrintVehicleDescription();
        }
        public List<Vehicle> GetAllVehicles()
        {
            return AllVehicles;
        }

        // TODO: add garage logic
    }
}
