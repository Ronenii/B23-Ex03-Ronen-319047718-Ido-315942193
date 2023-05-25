using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        private string m_LicensePlate;
        public Vehicle CreateVehicleByType(int i_VehicleType, string i_LicensePLate)
        {
            Vehicle vehicle;
            m_LicensePlate = i_LicensePLate;
            switch (i_VehicleType)
            {
                case 1:
                    vehicle = CreateDieselBike();
                    break;
                case 2:
                    vehicle = CreateElectricBike();
                    break;
                case 3:
                    vehicle = CreateDieselCar();
                    break;
                case 4:
                    vehicle = CreateElectricCar();
                    break;
                case 5:
                    vehicle = CreateTruck();
                    break;
                default:
                    throw new ArgumentException("Invalid choice. Please try again.");
            }
            return vehicle;
        }

        private Vehicle CreateTruck()
        {
            return getCarFromUserByType(eVehicleType.Truck);
        }

        private Vehicle CreateElectricBike()
        {
            return getCarFromUserByType(eVehicleType.ElectricBike);
        }

        private Vehicle CreateDieselBike()
        {
            return getCarFromUserByType(eVehicleType.DieselBike);
        }

        private Vehicle CreateElectricCar()
        {
            return getCarFromUserByType(eVehicleType.ElectricCar);
        }

        private Vehicle CreateDieselCar()
        {
            return getCarFromUserByType(eVehicleType.DieselCar);
        }

        private Vehicle getCarFromUserByType(eVehicleType i_Type)
        {
            Vehicle vehicle;
            Console.Write("Please insert the model: "); // TODO: move this and the row below to a 2 liner func "getModelFromUser
            string model = Console.ReadLine(); 
            List<Wheel> wheels = getWheelsFromUserByType(i_Type);
            Customer owner = getOwnerFromUser();
            eVehicleStatus vehicleStatus = eVehicleStatus.InRepair;
            if (i_Type == eVehicleType.DieselCar || i_Type == eVehicleType.DieselBike || i_Type == eVehicleType.Truck) // TODO: make a method called "bool isDieselVehicle"
            {
                Console.Write("Please insert the fuel left: "); // TODO: move this and the row below to a func "getFuelLeftFromUser"
                float powerLeft = float.Parse(Console.ReadLine());
                if (i_Type == eVehicleType.Truck) // TODO: make method called "bool isTruck"
                {
                    bool transportingHazardousMaterial = getTransportingHazardousMaterial();
                    Console.Write("Please insert cargo size: "); // TODO: move this and the row below to a func "getCargoSizeFromUser", validate that the input is a float. throw exceptions if not.
                    float cargoSize = float.Parse(Console.ReadLine());
                    vehicle = new Truck(model, m_LicensePlate, wheels, owner, eVehicleStatus.InRepair, powerLeft, transportingHazardousMaterial, cargoSize);
                }
                else if (i_Type == eVehicleType.DieselCar) // TODO: make method called "bool isBike"
                {
                    eCarColor color = getColorFromUser();
                    Enum.TryParse(Console.ReadLine(), out eNumOfCarDoors numOfDoors); // TODO: if num of doors is invalid what will happen? this needs to be in a func "getNumOfDoorsFromUser" with exceptions for both argument and format
                    vehicle = new DieselCar(model, m_LicensePlate, wheels, owner, vehicleStatus, powerLeft, color, numOfDoors);
                }
                else
                {
                    eMotorcycleLicense motorcycleLicense = getBikeLicense();      //////// Let me know if u have a soluation for it :( 
                    Console.Write("Please insert the Engine size: "); // TODO: move this and the line below to a func getEngineSizeFromUser and add exceptions
                    int engineSize = int.Parse(Console.ReadLine());   //////// it's duplicate rows from lines line 105 (only here)
                    vehicle = new DieselMotorcycle(model, m_LicensePlate, wheels, owner, eVehicleStatus.InRepair, powerLeft, motorcycleLicense, engineSize);
                }
            }
            else if (i_Type == eVehicleType.ElectricBike || i_Type == eVehicleType.ElectricCar) // TODO: make a method called "bool isElectricVehicle"
            {
                Console.Write("Please insert the electric left");
                float powerLeft = float.Parse(Console.ReadLine());
                if (i_Type == eVehicleType.ElectricCar) // TODO: make method called "bool isCar"
                {
                    eCarColor color = getColorFromUser();
                    Enum.TryParse(Console.ReadLine(), out eNumOfCarDoors numOfDoors); // TODO: if num of doors is invalid what will happen? this needs to be in a func "getNumOfDoorsFromUser" with exceptions for both argument and format
                    vehicle = new ElectricCar(model, m_LicensePlate, wheels, owner, vehicleStatus, powerLeft, color, numOfDoors);
                }
                else
                {
                    eMotorcycleLicense motorcycleLicense = getBikeLicense();
                    int engineSize = int.Parse(Console.ReadLine()); // TODO: move this and the line below to a func getEngineSizeFromUser and add validation, throw an exception if didnt work
                    vehicle = new ElectricMotorcycle(model, m_LicensePlate, wheels, owner, eVehicleStatus.InRepair, powerLeft, motorcycleLicense, engineSize);
                }
            }
            else
            {
                throw new ArgumentException("Invalid car type");
            }
            return vehicle;
        }

        private eMotorcycleLicense getBikeLicense()
        {
            Console.WriteLine("Please insert the bike license type\n1. A1\n2. A2\n3. AA\n4. B1");
            Enum.TryParse(Console.ReadLine(), out eMotorcycleLicense o_bikeLicense); //TODO: no need to add o_ to variables defined within a func, throw an exception if tryparse didn't work
            return o_bikeLicense;
        }

        private bool getTransportingHazardousMaterial()
        {
            bool hazardousMaterial;
            Console.WriteLine("Is transporting hazardous material? "); // TODO: move to display class
            Console.WriteLine("1. Yes");
            Console.WriteLine("2 No ");
            string transportingHazardousMaterialStr = Console.ReadLine(); // TODO: enum maybe?
            if (transportingHazardousMaterialStr == "1")
            {
                hazardousMaterial = true;
            }
            else if (transportingHazardousMaterialStr == "2")
            {
                hazardousMaterial = false;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invliad transporting hazardous material option"); //TODO: add formatting exception also, if user tries to input a string and not a number
            }
            return hazardousMaterial;
        }

        private eCarColor getColorFromUser()
        {
            Console.WriteLine("Please insert the bike license type\n1. White\n2. Black\n3. Yellow\n4. Red");
            Enum.TryParse(Console.ReadLine(), out eCarColor o_carColor); //TODO: no need to add o_ to variables defined within a func, throw exceptions if input is invalid
            return o_carColor;
        }

        private Customer getOwnerFromUser()
        {
            Console.Write("Please insert the owner name: ");
            string ownerName = Console.ReadLine();
            Console.Write("Please insert the owner phone: ");
            string ownerPhone = Console.ReadLine();
            return new Customer(ownerName, ownerPhone);
        }

        private List<Wheel> getWheelsFromUserByType(eVehicleType i_VehicleType)
        {
            List<Wheel> userWheels;
            if (i_VehicleType == eVehicleType.DieselCar || i_VehicleType == eVehicleType.ElectricCar) // TODO: Make a func "bool isCar"
            {
                userWheels = createNewWheel(CarProperties.NumOfWheels);
            }
            else if (i_VehicleType == eVehicleType.DieselBike || i_VehicleType == eVehicleType.ElectricBike) // TODO: Make a func "bool isBike"
            {
                userWheels = createNewWheel(MotorcycleProperties.NumOfWheels);
            }
            else
            {
                userWheels = createNewWheel(TruckProperties.NumOfWheels);
            }
            return userWheels;
        }

        private List<Wheel> createNewWheel(int i_NumOfWheels)
        {
            List<Wheel> wheels = new List<Wheel>();
            Console.WriteLine("Do you want auto wheel enterence?"); // TODO: Change to "Auto wheel input:", move to Display class
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            int.TryParse(Console.ReadLine(), out int o_UserChoosenInsertMethod);
            if (o_UserChoosenInsertMethod == 1) // TODO: Enum Maybe?
            {
                Wheel userWheel = createWheelFromUser();
                for (int i = 1; i <= i_NumOfWheels; i++) // TODO: We have a method in vehicle called initialize wheels which does this. maybe we can use it here?
                {
                    wheels.Add(userWheel);
                }
            }
            else if (o_UserChoosenInsertMethod == 2)
            {
                for (int i = 1; i <= i_NumOfWheels; i++)
                {
                    Console.WriteLine($"Please insert the next parameter for the #{i} wheel"); // TODO: no need for "please insert..." just do "Wheel #{wheel_num}"
                    wheels.Add(createWheelFromUser());
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid wheels mode selection"); // TODO: add an exception for formatting as well, when user inputs words and not numbers
            }
            return wheels;
        }

        private Wheel createWheelFromUser()
        {
            Console.Write("Please insert the max PSI: ");          //TODO: No need for this 
            float userMaxPSI = float.Parse(Console.ReadLine());
            Console.Write("Please insert the manufaturer: ");
            string userManufaturer = Console.ReadLine(); 
            Console.Write("Please insert the current PSI: ");
            float userCurrentPSI = float.Parse(Console.ReadLine()); // TODO: Need to validate that PSI inputed by use is not more than MaxPSI
            return new Wheel(userMaxPSI, userManufaturer, userCurrentPSI); // TODO: Each vehicle properties class holds its own MaxPSI you can get e.g: TruckProperties.MaxPSI
        }
    }
}
