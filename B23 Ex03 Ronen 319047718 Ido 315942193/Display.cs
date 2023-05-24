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
            Console.WriteLine("Please enter one of the folowing options");
            Console.WriteLine("1. Insert a new vehicle");
            Console.WriteLine("2. Show all vehicles in the garage");
            Console.WriteLine("3. Change vehicle status");
            Console.WriteLine("4. Inflate vehicle Wheel");
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
            Console.WriteLine("Please choose one of the next status");
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

        public static void VehicleDetails(Vehicle i_Vehicle)
        {
            Console.Clear();
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
            Console.WriteLine($"Number Of Doors:     {i_Car.NumOfDoors.ToString()}");
            Console.WriteLine($"Color:               {i_Car.CarColorToString()}\n");
        }

        public static void BikeDetails(MotorcycleProperties i_Bike)
        {
            Console.WriteLine("             BIKE INFO ");
            Console.WriteLine($"License:              {i_Bike.LicenseToString()}");
            Console.WriteLine($"Engine Size:          {i_Bike.EngineSize}cc\n");
        }

        public static void TruckDetails(Truck i_Truck)
        {
            Console.WriteLine("             TRUCK INFO ");
            Console.WriteLine($"Hazardous Material:   {i_Truck.IsTransportingHazardousMaterialToString()}");
            Console.WriteLine($"Cargo Size:          {i_Truck.CargoSize}m^3\n");
        }

        public static void ChooseCarTypePrompt()
        {
            Console.WriteLine("Please Insert the vehicle Type:");
            Console.WriteLine("1. Diesel Bike");
            Console.WriteLine("2. Electric Bike");
            Console.WriteLine("3. Diesel Car");
            Console.WriteLine("4. Electric Car");
            Console.WriteLine("5. Truck");
        }
    }
}
