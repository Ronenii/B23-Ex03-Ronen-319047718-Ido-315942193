using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;

namespace B23_Ex03_Ronen_319047718_Ido_315942193
{
    public class GarageHandleManager
    {
        private Garage garage = new Ex03.GarageLogic.Garage();

        public void AddingNewCar()
        {
            int integerCarType;
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
            string licensePlate = Console.ReadLine();
            Console.WriteLine("Please choose on of the next status:\n 1. Ready\n2. Repair\n 3. Total loss");
            string userStatusInput = Console.ReadLine();
            isUserStatusVehicleIsValid(userStatusInput, out eVehicleStatus o_status);
            garage.UpdateVehicleStatus(licensePlate, o_status);

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

        public void FuelVehicle()
        {
            eFuelType fuelType;
            float litersToAdd;
            Vehicle vehicleToFuel;

            vehicleToFuel = FindVehicleInGarage();
            if (vehicleToFuel is ElectricVehicle)
            {
                throw new ArgumentException("Can't fuel an electric car");
            }

            fuelType = getFuelTypeFromUser();
            litersToAdd = getLitersToAddFromUser();
            (vehicleToFuel as DieselVehicle).Fuel(litersToAdd, fuelType);
        }

        private float getLitersToAddFromUser()
        {
            float litersToAdd;
            Console.Write("Liters to add: ");
            string litersToAddStr = Console.ReadLine();

            if (!float.TryParse(litersToAddStr, out litersToAdd))
            {
                throw new FormatException("Input must be in numbers");
            }

            return litersToAdd;
        }

        private eFuelType getFuelTypeFromUser()
        {
            eFuelType fuelType;
            Console.WriteLine("1. Soler");
            Console.WriteLine("2. Octan 95");
            Console.WriteLine("3. Octan 96");
            Console.WriteLine("4. Octan 98");
            Console.Write("Choose fuel type: ");
            string fuelTypeStr = Console.ReadLine();
            if (!eFuelType.TryParse(fuelTypeStr, out fuelType))
            {
                throw new ArgumentException("Invalid fuel type");
            }

            return fuelType;
        }

        private Vehicle FindVehicleInGarage()
        {
            Console.Write("Vehicle license plate: ");
            string licensePlate = Console.ReadLine();
            Vehicle vehicleToFind = garage.GetVehicleByLicense(licensePlate);

            if (vehicleToFind == null)
            {
                throw new InstanceNotFoundException("No vehicle with matching license plate");
            }

            return vehicleToFind;
        }

        public void ChargeVehicle()
        {
            float hoursToCharge;
            Vehicle vehicleToCharge;

            vehicleToCharge = FindVehicleInGarage();
            if (vehicleToCharge is DieselVehicle)
            {
                throw new ArgumentException("Can't charge a fuel powered vehicle");
            }

            hoursToCharge = getHoursToChargeFromUser();
            (vehicleToCharge as ElectricVehicle).ChargeBattery(hoursToCharge);
        }

        private float getHoursToChargeFromUser()
        {
            float hoursToCharge;
            Console.Write("Liters to add: ");
            string hoursToChargeStr = Console.ReadLine();

            if (!float.TryParse(hoursToChargeStr, out hoursToCharge))
            {
                throw new FormatException("Input must be in numbers");
            }
            return hoursToCharge;
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
