using B23_Ex03_Ronen_319047718_Ido_315942193;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        private string m_LicensePlate;

        // Creates a vehicle from given type with given license plate
        public Vehicle CreateVehicleByType(eVehicleType i_VehicleType, string i_LicensePLate)
        {
            Vehicle vehicle;
            m_LicensePlate = i_LicensePLate;
            switch (i_VehicleType)
            {
                case eVehicleType.DieselMotorcycle:
                    vehicle = createDieselMotorcycle();
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicle = createElectricMotorcycle();
                    break;
                case eVehicleType.DieselCar:
                    vehicle = createDieselCar();
                    break;
                case eVehicleType.ElectricCar:
                    vehicle = createElectricCar();
                    break;
                case eVehicleType.Truck:
                    vehicle = createTruck();
                    break;
                default:
                    throw new ArgumentException("Invalid choice. Please try again.");
            }
            return vehicle;
        }

        // Creates a truck by user input
        private Vehicle createTruck()
        {
            return getVehicleFromUserByType(eVehicleType.Truck);
        }

        // Creates an electric motorcycle by user input
        private Vehicle createElectricMotorcycle()
        {
            return getVehicleFromUserByType(eVehicleType.ElectricMotorcycle);
        }

        // Creates a Diesel car by user input
        private Vehicle createDieselMotorcycle()
        {
            return getVehicleFromUserByType(eVehicleType.DieselMotorcycle);
        }

        // Creates an electric car by user input

        private Vehicle createElectricCar()
        {
            return getVehicleFromUserByType(eVehicleType.ElectricCar);
        }

        //Create a Diesel car by uswer input
        private Vehicle createDieselCar()
        {
            return getVehicleFromUserByType(eVehicleType.DieselCar);
        }

        // Receives vehicle type from user and builds a vehicle based on said type and user input
        private Vehicle getVehicleFromUserByType(eVehicleType i_Type)
        {
            Vehicle vehicle;
            string model = getVehicleModelFromUser();
            List<Wheel> wheels = getWheelsFromUserByType(i_Type);
            Customer owner = getOwnerFromUser();
            eVehicleStatus vehicleStatus = eVehicleStatus.InRepair;
            if (isDieselVehicle(i_Type))
            {
                float powerLeft = getPowerLeftFromUser(i_Type);
                if (isTruckType(i_Type))
                {
                    bool transportingHazardousMaterial = getTransportingHazardousMaterial();
                    float cargoSize = getCargoSizeFromUser();
                    vehicle = new Truck(model, m_LicensePlate, wheels, owner, eVehicleStatus.InRepair, powerLeft, transportingHazardousMaterial, cargoSize);
                }
                else if (isCarType(i_Type))
                {
                    eCarColor color = getColorFromUser();
                    eNumOfCarDoors numOfDoors = getNumOfDoorsFromUser();
                    vehicle = new DieselCar(model, m_LicensePlate, wheels, owner, vehicleStatus, powerLeft, color, numOfDoors);
                }
                else
                {
                    eMotorcycleLicense motorcycleLicense = getMotorcycleLicense();
                    int engineSize = getEngineSizeFromUser();
                    vehicle = new DieselMotorcycle(model, m_LicensePlate, wheels, owner, eVehicleStatus.InRepair, powerLeft, motorcycleLicense, engineSize);
                }
            }
            else if (isElectricVehicle(i_Type))
            {
                float powerLeft = getPowerLeftFromUser(i_Type);
                if (isCarType(i_Type))
                {
                    eCarColor color = getColorFromUser();
                    eNumOfCarDoors numOfDoors = getNumOfDoorsFromUser();
                    vehicle = new ElectricCar(model, m_LicensePlate, wheels, owner, vehicleStatus, powerLeft, color, numOfDoors);
                }
                else
                {
                    eMotorcycleLicense motorcycleLicense = getMotorcycleLicense();
                    int engineSize = getEngineSizeFromUser();
                    vehicle = new ElectricMotorcycle(model, m_LicensePlate, wheels, owner, eVehicleStatus.InRepair, powerLeft, motorcycleLicense, engineSize);
                }
            }
            else
            {
                throw new ArgumentException("Invalid car type");
            }
            return vehicle;
        }

        //Get number of doors from user input
        private static eNumOfCarDoors getNumOfDoorsFromUser()
        {
            Console.Write("Number of doors: ");
            if (Enum.TryParse(Console.ReadLine(), out eNumOfCarDoors numOfDoors))
            {
                if (!Enum.IsDefined(typeof(eNumOfCarDoors), numOfDoors))
                {
                    throw new ArgumentException("Invalid number of doors");
                }
            }
            else
            {
                throw new FormatException(Display.InvalidEnumParameter());
            }

            return numOfDoors;
        }

        //Validate the type is car
        private static bool isCarType(eVehicleType i_Type)
        {
            return i_Type == eVehicleType.ElectricCar || i_Type == eVehicleType.DieselCar;
        }

        //Validate the type is motorcycle
        private static bool isMotorcycleType(eVehicleType i_Type)
        {
            return i_Type == eVehicleType.ElectricMotorcycle || i_Type == eVehicleType.DieselMotorcycle;
        }

        //Validate the type is Truck
        private static bool isTruckType(eVehicleType i_Type)
        {
            return i_Type == eVehicleType.Truck;
        }

        //Validate is the type is electric vehicle
        private static bool isElectricVehicle(eVehicleType i_Type)
        {
            return i_Type == eVehicleType.ElectricMotorcycle || i_Type == eVehicleType.ElectricCar;
        }

        //Get engine size from user
        private static int getEngineSizeFromUser()
        {
            Console.Write("Engine size: ");
            int engineSize = int.Parse(Console.ReadLine());
            return engineSize;
        }

        //Get cargo size from user
        private static float getCargoSizeFromUser()
        {
            Console.Write("Cargo size: ");
            float cargoSize = float.Parse(Console.ReadLine());
            return cargoSize;
        }

        //Get Power left for electric and diesel vehicles
        private static float getPowerLeftFromUser(eVehicleType i_VehicleType)
        {
            float powerLeft;
            if (isDieselVehicle(i_VehicleType))
            {
                powerLeft = getFuelLitersLeft(i_VehicleType);
            }
            else
            {
                powerLeft = getChargeHoursLeft(i_VehicleType);
            }
            return powerLeft;
        }

        //Get full litters left by type
        private static float getFuelLitersLeft(eVehicleType i_VehicleType)
        {
            Console.Write("Fuel liters left: ");
            if (float.TryParse(Console.ReadLine(), out float fuelLitersLeft))
            {
                float maxPowerUnit;
                if (isCarType(i_VehicleType))
                {
                    maxPowerUnit = DieselCar.k_MaxFuelLiters;
                }
                else if (isTruckType(i_VehicleType))
                {
                    maxPowerUnit = Truck.k_MaxFuelLiters;
                }
                else
                {
                    maxPowerUnit = DieselMotorcycle.k_MaxFuelLiters;
                }

                if (fuelLitersLeft < 0 || fuelLitersLeft > maxPowerUnit)
                {
                    throw new ArgumentException("Got invalid fuel left");
                }
            }
            else
            {
                throw new FormatException("Input must be in numbers");
            }

            return fuelLitersLeft;
        }

        // Prompts user to input charge hours left, parses it and returns the float
        private static float getChargeHoursLeft(eVehicleType i_VehicleType)
        {
            Console.Write("Charge hours left: ");
            if (float.TryParse(Console.ReadLine(), out float chargeHoursLeft))
            {
                float maxPowerUnit;
                if (isCarType(i_VehicleType))
                {
                    maxPowerUnit = ElectricCar.k_MaxChargeHours;
                }
                else
                {
                    maxPowerUnit = ElectricMotorcycle.k_MaxChargeHours;
                }
                if (chargeHoursLeft < 0 || chargeHoursLeft > maxPowerUnit)
                {
                    throw new ArgumentException("Charge can't be more than max battery capacity or negative");
                }
            }
            else
            {
                throw new FormatException("Input must be in numbers");
            }

            return chargeHoursLeft;
        }

        //Validate the vehicle with diesel engine
        private static bool isDieselVehicle(eVehicleType i_Type)
        {
            return i_Type == eVehicleType.DieselCar || i_Type == eVehicleType.DieselMotorcycle || i_Type == eVehicleType.Truck;
        }

        //Get vhicle model from user
        private static string getVehicleModelFromUser()
        {
            Console.Write("Vehicle Model: ");
            string model = Console.ReadLine();
            return model;
        }

        //Get motorcycle liccense from user
        private eMotorcycleLicense getMotorcycleLicense()
        {
            Display.MotorcycleLicense();

            if (Enum.TryParse(Console.ReadLine(), out eMotorcycleLicense motorcycleLicense))
            {
                if (!Enum.IsDefined(typeof(eMotorcycleLicense), motorcycleLicense))
                {
                    throw new ArgumentException("Motorcycle license not listed on the menu");
                }
            }
            else
            {
                throw new FormatException(Display.InvalidEnumParameter());
            }

            return motorcycleLicense;
        }

        //Validate if the truck transporting hazardous material
        private bool getTransportingHazardousMaterial()
        {
            bool hazardousMaterial;
            Display.TransportingHazardousMaterial();
            if (Enum.TryParse(Console.ReadLine(), out eTransportingHazardousMaterial transportingHazardousMaterial))
            {
                if (!Enum.IsDefined(typeof(eTransportingHazardousMaterial), transportingHazardousMaterial))
                {
                    throw new ArgumentException("Transporting Hazardous Material not listed on the menu");
                }
            }
            else
            {
                throw new FormatException(Display.InvalidEnumParameter());
            }
            if (transportingHazardousMaterial == eTransportingHazardousMaterial.Yes)
            {
                hazardousMaterial = true;
            }
            else if (transportingHazardousMaterial == eTransportingHazardousMaterial.No)
            {
                hazardousMaterial = false;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invliad transporting hazardous material option");
            }
            return hazardousMaterial;
        }

        //Get Color car from user
        private eCarColor getColorFromUser()
        {
            Display.ColorMenu();

            if (Enum.TryParse(Console.ReadLine(), out eCarColor carColor))
            {
                if (!Enum.IsDefined(typeof(eCarColor), carColor))
                {
                    throw new ArgumentException("Car color not listed on the menu");
                }
            }
            else
            {
                throw new FormatException(Display.InvalidEnumParameter());
            }

            return carColor;
        }

        //Create an owner from user
        private Customer getOwnerFromUser()
        {
            Console.Write("Owner name: ");
            string ownerName = Console.ReadLine();
            Console.Write("Owner phone number: ");
            string ownerPhone = Console.ReadLine();
            return new Customer(ownerName, ownerPhone);
        }

        //Get wheels from user
        private List<Wheel> getWheelsFromUserByType(eVehicleType i_VehicleType)
        {
            List<Wheel> userWheels;
            if (isCarType(i_VehicleType))
            {
                userWheels = createNewWheel(CarProperties.NumOfWheels, CarProperties.MaxPSI);
            }
            else if (isMotorcycleType(i_VehicleType))
            {
                userWheels = createNewWheel(MotorcycleProperties.NumOfWheels, MotorcycleProperties.MaxPSI);
            }
            else
            {
                userWheels = createNewWheel(TruckProperties.NumOfWheels, TruckProperties.MaxPSI);
            }
            return userWheels;
        }

        //Create new wheels from user
        private List<Wheel> createNewWheel(int i_NumOfWheels, float i_MaxPsi)
        {
            List<Wheel> wheels = new List<Wheel>();
            Display.AutoWheelsRequest();
            int.TryParse(Console.ReadLine(), out int userChoosenInsertMethod);
            if (userChoosenInsertMethod == 1)
            {
                Wheel userWheel = createWheelFromUser(i_MaxPsi);
                for (int i = 1; i <= i_NumOfWheels; i++)
                {
                    wheels.Add(userWheel);
                }
            }
            else if (userChoosenInsertMethod == 2)
            {
                for (int i = 1; i <= i_NumOfWheels; i++)
                {
                    Console.WriteLine($"Please insert the next parameter for the #{i} wheel");
                    wheels.Add(createWheelFromUser(i_MaxPsi));
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid wheels mode selection");
            }
            return wheels;
        }

        //Create new wheels from user
        private Wheel createWheelFromUser(float i_MaxPsi)
        {
            Console.Write("Wheel manufacturer: ");
            string userManufaturer = Console.ReadLine();
            Console.Write("Current wheel PSI: ");
            float userCurrentPSI = float.Parse(Console.ReadLine());
            if (!isValidCurrentPSI(userCurrentPSI, i_MaxPsi))
            {
                throw new ArgumentException("Current PSI cannot be more than MaxPSI");
            }
            return new Wheel(i_MaxPsi, userManufaturer, userCurrentPSI);
        }

        //Validate the given PSI wheel is valid
        private bool isValidCurrentPSI(float userCurrentPSI, float i_MaxPsi)
        {
            return userCurrentPSI <= i_MaxPsi && userCurrentPSI >= 0;
        }
    }
}
