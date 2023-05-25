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
        public Vehicle CreateVehicleByType(int i_VehicleType, string i_LicensePLate)
        {
            Vehicle vehicle;
            m_LicensePlate = i_LicensePLate;
            switch (i_VehicleType)
            {
                case 1:
                    vehicle = CreateDieselMotorcycle();
                    break;
                case 2:
                    vehicle = CreateElectricMotorcycle();
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
            return getVehicleFromUserByType(eVehicleType.Truck);
        }

        private Vehicle CreateElectricMotorcycle()
        {
            return getVehicleFromUserByType(eVehicleType.ElectricMotorcycle);
        }

        private Vehicle CreateDieselMotorcycle()
        {
            return getVehicleFromUserByType(eVehicleType.DieselMotorcycle);
        }

        private Vehicle CreateElectricCar()
        {
            return getVehicleFromUserByType(eVehicleType.ElectricCar);
        }

        private Vehicle CreateDieselCar()
        {
            return getVehicleFromUserByType(eVehicleType.DieselCar);
        }

        private Vehicle getVehicleFromUserByType(eVehicleType i_Type)
        {
            Vehicle vehicle;
            string model = getModelFromUser();
            List<Wheel> wheels = getWheelsFromUserByType(i_Type);
            Customer owner = getOwnerFromUser();
            eVehicleStatus vehicleStatus = eVehicleStatus.InRepair;
            if (isDieselVehicle(i_Type))
            {
                float powerLeft = getPowerLeftFromUser(i_Type);
                if (isTruckType(i_Type))
                {
                    bool transportingHazardousMaterial = getTransportingHazardousMaterial();
                    float cargoSize = getCargoFromUser();
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

        private static eNumOfCarDoors getNumOfDoorsFromUser()
        {
            if (Enum.TryParse(Console.ReadLine(), out eNumOfCarDoors numOfDoors))
            {
                if (!Enum.IsDefined(typeof(eNumOfCarDoors), numOfDoors))
                {
                    throw new ArgumentException("number of doors not listed on the menu");
                }
            }
            else
            {
                throw new FormatException(Display.InvalidEnumParameter());
            }

            return numOfDoors;
        }

        private static bool isCarType(eVehicleType i_Type)
        {
            return i_Type == eVehicleType.ElectricCar || i_Type == eVehicleType.DieselCar;
        }
        private static bool isMotorcycleType(eVehicleType i_Type)
        {
            return i_Type == eVehicleType.ElectricMotorcycle || i_Type == eVehicleType.DieselMotorcycle;
        }
        private static bool isTruckType(eVehicleType i_Type)
        {
            return i_Type == eVehicleType.Truck;
        }

        private static bool isElectricVehicle(eVehicleType i_Type)
        {
            return i_Type == eVehicleType.ElectricMotorcycle || i_Type == eVehicleType.ElectricCar;
        }

        private static int getEngineSizeFromUser()
        {
            Console.Write("Please insert the Engine size: ");
            int engineSize = int.Parse(Console.ReadLine());
            return engineSize;
        }

        private static float getCargoFromUser()
        {
            Console.Write("Please insert cargo size: ");
            float cargoSize = float.Parse(Console.ReadLine());
            return cargoSize;
        }

        private static float getPowerLeftFromUser(eVehicleType i_Type)
        {
            float maxLittersToFill;
            if (isDieselVehicle(i_Type))
            {
                Console.Write("Please insert the fuel left: ");
            }
            else
            {
                Console.Write("Please insert the electric left");
            }
            bool isValid = float.TryParse(Console.ReadLine(), out float powerLeft);
            if (isValid)
            {
                if (isCarType(i_Type))
                {
                    maxLittersToFill = CarProperties.MaxPSI;
                }
                else if (isTruckType(i_Type))
                {
                    maxLittersToFill = TruckProperties.MaxPSI;
                }
                else
                {
                    maxLittersToFill = MotorcycleProperties.MaxPSI;
                }

                if (powerLeft < 0 || powerLeft > maxLittersToFill)
                {
                    throw new ArgumentException("Got invalid fuel left");
                }

            }
            return powerLeft;
        }

        private static bool isDieselVehicle(eVehicleType i_Type)
        {
            return i_Type == eVehicleType.DieselCar || i_Type == eVehicleType.DieselMotorcycle || i_Type == eVehicleType.Truck;
        }

        private static string getModelFromUser()
        {
            Console.Write("Please insert the model: ");
            string model = Console.ReadLine();
            return model;
        }

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

        private Wheel createWheelFromUser(float i_MaxPsi)
        {
            Console.Write("Please insert the manufaturer: ");
            string userManufaturer = Console.ReadLine();
            Console.Write("Please insert the current PSI: ");
            float userCurrentPSI = float.Parse(Console.ReadLine());
            if (!isValidCurrentPSI(userCurrentPSI, i_MaxPsi))
            {
                throw new ArgumentException("Current PSI cannot be more than MaxPSI");
            }
            return new Wheel(i_MaxPsi, userManufaturer, userCurrentPSI);
        }

        private bool isValidCurrentPSI(float userCurrentPSI, float i_MaxPsi)
        {
            return userCurrentPSI <= i_MaxPsi && userCurrentPSI >= 0;
        }
    }
}
