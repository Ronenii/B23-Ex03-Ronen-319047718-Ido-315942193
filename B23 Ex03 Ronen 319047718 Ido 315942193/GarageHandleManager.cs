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
        private VehicleFactory vehicleFactory = new VehicleFactory();

        public GarageHandleManager()
        {
            List<Wheel> bikeWheels = new List<Wheel>();
            for (int i = 0; i < 2; i++)
            {
                bikeWheels.Add(new Wheel(MotorcycleProperties.MaxPSI, "Michelin", 28));
            }

            List<Wheel> carWheels = new List<Wheel>();
            for (int i = 0; i < 5; i++)
            {
                carWheels.Add(new Wheel(CarProperties.MaxPSI, "Bordeux", 15));
            }

            List<Wheel> truckWheels = new List<Wheel>();
            for (int i = 0; i < 14; i++)
            {
                truckWheels.Add(new Wheel(Truck.MaxPSI, "Calgary", 28));
            }

            Customer idoBi = new Customer("Ido Biton", "0500001234");
            Customer RonenGe = new Customer("Ronen Gelmanovich", "0540001234");
            DieselMotorcycle db = new DieselMotorcycle(
                "Kawasaki",
                "1231",
                bikeWheels,
                idoBi,
                eVehicleStatus.InRepair,
                4.2f,
                eMotorcycleLicense.A1,
                250);
            ElectricMotorcycle eb = new ElectricMotorcycle(
                "Tesla",
                "1232",
                bikeWheels,
                RonenGe,
                eVehicleStatus.Paid,
                1.1f,
                eMotorcycleLicense.B1,
                500);
            DieselCar dc = new DieselCar(
                "Mazeratti",
                "1233",
                carWheels,
                idoBi,
                eVehicleStatus.Repaired,
                13.2f,
                eCarColor.Yellow,
                eNumOfCarDoors.Three);

            ElectricCar ec = new ElectricCar(
                "Ioniq 5",
                "1234",
                carWheels,
                RonenGe,
                eVehicleStatus.InRepair,
                4.3f,
                eCarColor.Black,
                eNumOfCarDoors.Five);

            Truck t = new Truck("DAF", "1235", truckWheels, idoBi, eVehicleStatus.Paid, 28.3f, true, 5000);

            garage.AddNewVehicle(db);
            garage.AddNewVehicle(t);
            garage.AddNewVehicle(ec);
            garage.AddNewVehicle(eb);
            garage.AddNewVehicle(dc);

        }
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
            string licensePlate = Console.ReadLine();
            printSuportedStatus();
            string userStatusInput = Console.ReadLine();
            if (isUserStatusVehicleIsValid(userStatusInput, out eVehicleStatus o_status))
            {
                garage.UpdateVehicleStatus(licensePlate, o_status);
                Console.WriteLine($"The vehicle with the license plate: {licensePlate} updated successfully");
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid vehicle status");
            }

        }

        private static void printSuportedStatus()
        {
            Console.WriteLine("Please choose one of the next status");
            Console.WriteLine("1. In-Repair");
            Console.WriteLine("2. Repaired");
            Console.WriteLine("3. Paid");
        }

        public void InflateWheel()
        {
            Console.Write("Please insert the Licence plate for the car: ");
            string licensePlate = Console.ReadLine();
            Vehicle vehicle = garage.GetVehicleByLicense(licensePlate);
            if (vehicle != null)
            {
                vehicle.InflateAllWheelsToMax();
                Console.WriteLine("The wheels inflate to max");
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
            Vehicle vehicleToPresent;
            vehicleToPresent = FindVehicleInGarage();

            printVehicleDetails(vehicleToPresent);
            printWheelDetails(vehicleToPresent);
            if (vehicleToPresent is DieselVehicle dieselVehicle)
            {
                printDieselVehicleDetails(dieselVehicle);
            }
            else if (vehicleToPresent is ElectricVehicle electricVehicle)
            {
                printElectricVehicleDetails(electricVehicle);
            }
        }

        private void printDieselVehicleDetails(DieselVehicle i_DieselVehicle)
        {
            printFuelDetails(i_DieselVehicle);
            if (i_DieselVehicle is DieselCar dieselCar)
            {
                printCarDetails(dieselCar.CarProperties);
            }
            else if (i_DieselVehicle is DieselMotorcycle dieselMotorcycle)
            {
                printBikeDetails(dieselMotorcycle.MotorcycleProperties);
            }
            else if (i_DieselVehicle is Truck truck)
            {
                printTrunkDetails(truck);
            }
        }

        private void printElectricVehicleDetails(ElectricVehicle i_ElectricVehicle)
        {
            printBatteryDetails(i_ElectricVehicle);
            if (i_ElectricVehicle is ElectricCar electricCar)
            {
                printCarDetails(electricCar.CarProperties);
            }
            else if (i_ElectricVehicle is ElectricMotorcycle electricMotorcycle)
            {
                printBikeDetails(electricMotorcycle.MotorcycleProperties);
            }
        }

        private void printVehicleDetails(Vehicle i_Vehicle)
        {
            Console.Clear();
            Console.WriteLine("         *** VEHICLE INFO ***\n");
            Console.WriteLine("             GENERAL INFO");
            Console.WriteLine($"License Plate:       {i_Vehicle.LicensePlate}");
            Console.WriteLine($"Model:               {i_Vehicle.Model}");
            Console.WriteLine($"Owner:               {i_Vehicle.OwnerName}");
            Console.WriteLine($"Status:              {i_Vehicle.VehicleStatusToString()}\n");
        }

        private void printWheelDetails(Vehicle i_Vehicle)
        {
            int wheelNo = 1;
            Console.WriteLine("             WHEEL INFO");
            foreach (Wheel w in i_Vehicle.Wheels)
            {
                Console.WriteLine($"#{wheelNo++}");
                Console.WriteLine($"Wheel Manufacturer:  {w.Manufacturer}");
                Console.WriteLine($"Wheel PSI:           {w.CurrentPSI}\n");
            }
        }

        private void printFuelDetails(DieselVehicle i_DieselVehicle)
        {
            Console.WriteLine("             FUEL INFO ");
            Console.WriteLine($"Octan:               {i_DieselVehicle.FuelTypeToString()}");
            Console.WriteLine($"Liters Left:         {i_DieselVehicle.FuelLitersLeft}L");
            printPowerPercentage(i_DieselVehicle);
        }

        private void printBatteryDetails(ElectricVehicle i_ElectricVehicle)
        {
            Console.WriteLine("             BATTERY INFO ");
            Console.WriteLine($"Charge Left:         {i_ElectricVehicle.ChargeTimeToString()} h:mm");
            printPowerPercentage(i_ElectricVehicle);
        }

        private void printPowerPercentage(Vehicle i_Vehicle)
        {
            float percentage = i_Vehicle.EnergyLeft * 100;
            Console.WriteLine($"In Percents:         {percentage.ToString("0")}%\n");
        }

        private void printCarDetails(CarProperties i_Car)
        {
            Console.WriteLine("             CAR INFO ");
            Console.WriteLine($"Number Of Doors:     {i_Car.NumOfDoors.ToString()}");
            Console.WriteLine($"Color:               {i_Car.CarColorToString()}\n");
        }

        private void printBikeDetails(MotorcycleProperties i_Bike)
        {
            Console.WriteLine("             BIKE INFO ");
            Console.WriteLine($"License:              {i_Bike.LicenseToString()}");
            Console.WriteLine($"Engine Size:          {i_Bike.EngineSize}cc\n");
        }

        private void printTrunkDetails(Truck i_Truck)
        {
            Console.WriteLine("             TRUCK INFO ");
            Console.WriteLine($"Hazardous Material:   {i_Truck.IsTransportingHazardousMaterialToString()}");
            Console.WriteLine($"Cargo Size:          {i_Truck.CargoSize}m^3\n");
        }

        private bool isUserStatusVehicleIsValid(string userStatusInput, out eVehicleStatus o_status)
        {
            return eVehicleType.TryParse(userStatusInput, out o_status);
        }

    }
}
