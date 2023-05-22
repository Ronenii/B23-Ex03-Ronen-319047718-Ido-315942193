using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex03_Ronen_319047718_Ido_315942193
{
    public class GarageHandleManager
    {
        private Garage garage = new Ex03.GarageLogic.Garage();

        public void AddingNewCar()
        {
            Console.WriteLine("Please insert the license plate");
            string licensePLate = Console.ReadLine();
            Vehicle vehicle = garage.GetVehicleByLicense(licensePLate);
            if (vehicle == null)
            {
                vehicle = CreateRelevantVehicle();
                garage.AddNewVehicle(vehicle);
            }
            else
            {
                vehicle.Status = eVehicleStatus.InRepair;
            }
        }

        private static void printCarTypeChoosenRequest()
        {
            Console.WriteLine("Please Insert the vehicle Type\n1. Diesel Bike\n2. Electric Bike\n3. Diesel Car\n 4. Electric Car\n5. Truck");
        }

        public void ShowGrageCar()
        {
            List<Vehicle> vehicles = garage.GetAllVehicles();
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
        public void ChangeCarStatus()
        {
            Console.Write("Please insert the Licence plate for the car: ");
            string licencePlate = Console.ReadLine();
            Console.WriteLine("Please choose on of the next status:\n 1. Ready\n2. Repair\n 3. Total loss");
            string userStatusInput = Console.ReadLine();
            isUserStatusVehicleIsValid(userStatusInput, out eVehicleStatus o_status);
            garage.UpdateVehicleStatus(licencePlate, o_status);

        }

        public void InflateWheel()
        {
            Console.Write("Please insert the Licence plate for the car: ");
            string licencePlate = Console.ReadLine();
            Vehicle vehicle = garage.GetVehicleByLicense(licencePlate);
            if (vehicle != null)
            {
                vehicle.InflateAllWheelsToMax();
            }
            else
            {
                Console.WriteLine("Could not find the vehicle");
            }

        }
        public void FillFuel()
        {
            Console.WriteLine("FillFuel logic");
        }
        public void ChargeElctonicCar()
        {
            Console.WriteLine("ChargeElctonicCar logic");
        }
        public void PresentCar()
        {
            Console.WriteLine("PresentCar logic");
        }

        private void isUserStatusVehicleIsValid(string userStatusInput, out eVehicleStatus o_status)
        {
            throw new NotImplementedException();
        }

        private Vehicle CreateRelevantVehicle()
        {
            printCarTypeChoosenRequest();
            throw new NotImplementedException();
        }
    }
}
