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
        private VehicleFactory vehicleFactory = new VehicleFactory();


        public void AddingNewCar()
        {
            Console.WriteLine("Please insert the license plate");
            string licensePLate = Console.ReadLine();
            Vehicle vehicle = garage.GetVehicleByLicense(licensePLate);
            if (vehicle == null)
            {
                Console.WriteLine("Create new vehicle in the system");
                printCarTypeChoosenRequest();
                try
                {
                    vehicle = vehicleFactory.CreateVehicleByType(int.Parse(Console.ReadLine()), licensePLate);
                    garage.AddNewVehicle(vehicle);
                    Console.WriteLine("The vehicle added successfully");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Insert invlalid parameters {e.Message}");
                }
            }
            else
            {
                Console.WriteLine("Change vehicle status to In-Repair status");
                vehicle.Status = eVehicleStatus.InRepair;
            }
        }

        private static void printCarTypeChoosenRequest()
        {
            Console.WriteLine("Please Insert the vehicle Type:");
            Console.WriteLine("1. Diesel Bike");
            Console.WriteLine("2. Electric Bike");
            Console.WriteLine("3. Diesel Car");
            Console.WriteLine("4. Electric Car");
            Console.WriteLine("5. Truck");
        }

        public void ShowGrageCar()
        {
            List<Vehicle> vehicles = garage.GetAllVehicles();
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }
        public void ChangeCarStatus()
        {
            Console.Write("Please insert the Licence plate for the car: ");
            string licencePlate = Console.ReadLine();
            Console.WriteLine("Please choose one of the next status");
            Console.WriteLine("1. In-Repair");
            Console.WriteLine("2. Repaired");
            Console.WriteLine("3. Paid");
            eVehicleStatus o_status;
            bool isValid = Enum.TryParse(Console.ReadLine(), out o_status); //TODO handle enum error!!!
            if(isValid)
            {
                garage.UpdateVehicleStatus(licencePlate, o_status);
                Console.WriteLine("Update the vehicle status successfuly");
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invliad user vehicle status");
            }

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

    }
}
