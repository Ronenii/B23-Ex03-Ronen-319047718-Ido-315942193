using System;
using Ex03.GarageLogic;

namespace B23_Ex03_Ronen_319047718_Ido_315942193
{
    class Display
    {
        public static void ErrorMessage(string i_ErrorMessage)
        {
            if (i_ErrorMessage != null)
            {
                Console.WriteLine($"ERROR: **{i_ErrorMessage}**");
            }
        }

        public static void WelcomeMessage()
        {
            string welcomeText = @"                                                                                    
 _ _ _     _                      _          _   _                                  
| | | |___| |___ ___ _____ ___   | |_ ___   | |_| |_ ___    ___ ___ ___ ___ ___ ___ 
| | | | -_| |  _| . |     | -_|  |  _| . |  |  _|   | -_|  | . | .'|  _| .'| . | -_|
|_____|___|_|___|___|_|_|_|___|  |_| |___|  |_| |_|_|___|  |_  |__,|_| |__,|_  |___|
                                                           |___|           |___|     ";

            Console.WriteLine(welcomeText);
        }

        public static void Menu()
        {
            Console.WriteLine("**       ACTIONS       **");
            Console.WriteLine("1. Insert a new vehicle");
            Console.WriteLine("2. Show vehicles in the garage");
            Console.WriteLine("3. Change vehicle status");
            Console.WriteLine("4. Inflate vehicle wheel");
            Console.WriteLine("5. Refuel a vehicle");
            Console.WriteLine("6. Charge a vehicle");
            Console.WriteLine("7. Present a vehicle");
            Console.WriteLine("8. Exit");
        }

        public static void Goodbye()
        {
            Console.Clear();
            Console.WriteLine("Goodbye!");
        }

        public static void ActionEndingPrompt()
        {
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
            Console.Clear();
        }

        public static void StatusChoosePrompt()
        {
            Console.WriteLine("Vehicle status");
            vehicleStatuses();
        }

        private static void vehicleStatuses()
        {
            Console.WriteLine("1. In-Repair");
            Console.WriteLine("2. Repaired");
            Console.WriteLine("3. Paid");
        }

        public static void ChooseFuelPrompt()
        {
            Console.WriteLine("1. Soler");
            Console.WriteLine("2. Octan 95");
            Console.WriteLine("3. Octan 96");
            Console.WriteLine("4. Octan 98");
            Console.Write("Choose fuel type: ");
        }

        public static void FilteringStatus()
        {
            Console.WriteLine("Vehicle status: ");
            Display.vehicleStatuses();
            Console.WriteLine("4. All");
        }

        public static void VehicleDetails(Vehicle i_Vehicle)
        {
            Console.WriteLine("         *** VEHICLE INFO ***\n");
            Console.WriteLine("             GENERAL INFO");
            Console.WriteLine($"License Plate:       {i_Vehicle.LicensePlate}");
            Console.WriteLine($"Model:               {i_Vehicle.Model}");
            Console.WriteLine($"Owner:               {i_Vehicle.OwnerName}");
            Console.WriteLine($"Status:              {i_Vehicle.VehicleStatusToString()}\n");
        }

        public static void WheelDetails(Vehicle i_Vehicle)
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

        public static void FuelDetails(DieselVehicle i_DieselVehicle)
        {
            Console.WriteLine("             FUEL INFO ");
            Console.WriteLine($"Octan:               {i_DieselVehicle.FuelTypeToString()}");
            Console.WriteLine($"Liters Left:         {i_DieselVehicle.FuelLitersLeft}L");
            printPowerPercentage(i_DieselVehicle);
        }

        public static void BatteryDetails(ElectricVehicle i_ElectricVehicle)
        {
            Console.WriteLine("             BATTERY INFO ");
            Console.WriteLine($"Charge Left:         {i_ElectricVehicle.ChargeTimeToString()} hours");
            printPowerPercentage(i_ElectricVehicle);
        }

        private static void printPowerPercentage(Vehicle i_Vehicle)
        {
            float percentage = i_Vehicle.EnergyLeft * 100;
            Console.WriteLine($"In Percents:         {percentage.ToString("0")}%\n");
        }

        public static void CarDetails(CarProperties i_Car)
        {
            Console.WriteLine("             CAR INFO ");
            Console.WriteLine($"Number Of Doors:     {i_Car.NumOfDoors}");
            Console.WriteLine($"Color:               {i_Car.Color}\n");
        }

        public static void MotorcycleDetails(MotorcycleProperties i_Motorcycle)
        {
            Console.WriteLine("             MOTORCYCLE INFO ");
            Console.WriteLine($"License:              {i_Motorcycle.LicenseToString()}");
            Console.WriteLine($"Engine Size:          {i_Motorcycle.EngineSize}cc\n");
        }

        public static void MotorcycleLicense()
        {
            Console.WriteLine("License type:");
            Console.WriteLine("1. A1");
            Console.WriteLine("2. A2");
            Console.WriteLine("3. AA");
            Console.WriteLine("4. B1");

        }

        public static void TransportingHazardousMaterial()
        {
            Console.WriteLine("Are you transporting hazardous material?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No ");
        }
        public static void TruckDetails(Truck i_Truck)
        {
            Console.WriteLine("             TRUCK INFO ");
            Console.WriteLine($"Hazardous Material:   {i_Truck.TruckProperties.IsTransportingHazardousMaterialToString()}");
            Console.WriteLine($"Cargo Size:          {i_Truck.CargoSize}m^3\n");
        }

        public static void ChooseCarTypePrompt()
        {
            Console.WriteLine("Vehicle type:");
            Console.WriteLine("1. Diesel Motorcycle");
            Console.WriteLine("2. Electric Motorcycle");
            Console.WriteLine("3. Diesel Car");
            Console.WriteLine("4. Electric Car");
            Console.WriteLine("5. Truck");
        }

        public static void ColorMenu()
        {
            Console.WriteLine("Car color:");
            Console.WriteLine("1. White");
            Console.WriteLine("2. Black");
            Console.WriteLine("3. Yellow");
            Console.WriteLine("4. Red");
        }

        public static void AutoWheelsRequest()
        {
            Console.WriteLine("Do you want auto wheel entrance?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
        }

        public static string InvalidEnumParameter()
        {
            return "Input must be a numbers";
        }
    }
}
