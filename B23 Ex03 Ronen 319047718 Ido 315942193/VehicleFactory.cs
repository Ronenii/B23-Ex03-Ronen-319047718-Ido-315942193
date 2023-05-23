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
            Console.Write("Please insert the model: ");
            string model = Console.ReadLine();
            List<Wheel> wheels = getWheelsFromUserByType(i_Type);
            Customer owner = getOwnerFromUser();
            eVehicleStatus vehicleStatus = eVehicleStatus.InRepair;
            if (i_Type == eVehicleType.DieselCar || i_Type == eVehicleType.DieselBike || i_Type == eVehicleType.Truck)
            {
                Console.Write("Please insert the fuel left: ");
                float powerLeft = float.Parse(Console.ReadLine());
                if (i_Type == eVehicleType.Truck)
                {
                    bool transportingHazardousMaterial = getTransportingHazardousMaterial();
                    Console.Write("Please insert cargo size: ");
                    float cargoSize = float.Parse(Console.ReadLine());
                    vehicle = new Truck(model, m_LicensePlate, wheels, owner, eVehicleStatus.InRepair, powerLeft, transportingHazardousMaterial, cargoSize);
                }
                else if (i_Type == eVehicleType.DieselCar)
                {
                    eCarColor color = getColorFromUser();
                    Enum.TryParse(Console.ReadLine(), out eNumOfCarDoors numOfDoors);
                    vehicle = new DieselCar(model, m_LicensePlate, wheels, owner, vehicleStatus, powerLeft, color, numOfDoors);
                }
                else
                {
                    eBikeLicense bikeLicense = getBikeLicense();      //////// Let me know if u have a soluation for it :(
                    Console.Write("Please insert the Engine size: ");
                    int engineSize = int.Parse(Console.ReadLine());   //////// it's duplicate rows from lines line 105 (only here)
                    vehicle = new DieselBike(model, m_LicensePlate, wheels, owner, eVehicleStatus.InRepair, powerLeft, bikeLicense, engineSize);
                }
            }
            else if (i_Type == eVehicleType.ElectricBike || i_Type == eVehicleType.ElectricCar)
            {
                Console.Write("Please insert the electric left");
                float powerLeft = float.Parse(Console.ReadLine());
                if (i_Type == eVehicleType.ElectricCar)
                {
                    eCarColor color = getColorFromUser();
                    Enum.TryParse(Console.ReadLine(), out eNumOfCarDoors numOfDoors);
                    vehicle = new ElectricCar(model, m_LicensePlate, wheels, owner, vehicleStatus, powerLeft, color, numOfDoors);
                }
                else
                {
                    eBikeLicense bikeLicense = getBikeLicense();
                    int engineSize = int.Parse(Console.ReadLine());
                    vehicle = new ElectricBike(model, m_LicensePlate, wheels, owner, eVehicleStatus.InRepair, powerLeft, bikeLicense, engineSize);
                }
            }
            else
            {
                throw new ArgumentException("Invalid car type");
            }
            return vehicle;
        }

        private eBikeLicense getBikeLicense()
        {
            Console.WriteLine("Please insert the bike license type\n1. A1\n2. A2\n3. AA\n4. B1");
            Enum.TryParse(Console.ReadLine(), out eBikeLicense o_bikeLicense);
            return o_bikeLicense;
        }

        private bool getTransportingHazardousMaterial()
        {
            bool hazardousMaterial;
            Console.WriteLine("Is transporting hazardous material? ");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2 No ");
            string transportingHazardousMaterialStr = Console.ReadLine();
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
                throw new ArgumentOutOfRangeException("Invliad transporting hazardous material option");
            }
            return hazardousMaterial;
        }

        private eCarColor getColorFromUser()
        {
            Console.WriteLine("Please insert the bike license type\n1. White\n2. Black\n3. Yellow\n4. Red");
            Enum.TryParse(Console.ReadLine(), out eCarColor o_carColor);
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
            if (i_VehicleType == eVehicleType.DieselCar || i_VehicleType == eVehicleType.ElectricCar)
            {
                userWheels = createNewWheel(Car.k_NumOfWheels);
            }
            else if (i_VehicleType == eVehicleType.DieselBike || i_VehicleType == eVehicleType.ElectricBike)
            {
                userWheels = createNewWheel(Bike.k_NumOfWheels);
            }
            else
            {
                userWheels = createNewWheel(Truck.k_NumOfWheels);
            }
            return userWheels;
        }

        private List<Wheel> createNewWheel(int i_NumOfWheels)
        {
            List<Wheel> wheels = new List<Wheel>();
            Console.WriteLine("Do you want auto wheel enterence?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            int.TryParse(Console.ReadLine(), out int o_UserChoosenInsertMethod);
            if (o_UserChoosenInsertMethod == 1)
            {
                Wheel userWheel = createWheelFromUser();
                for (int i = 1; i <= i_NumOfWheels; i++)
                {
                    wheels.Add(userWheel);
                }
            }
            else if (o_UserChoosenInsertMethod == 2)
            {
                for (int i = 1; i <= i_NumOfWheels; i++)
                {
                    Console.WriteLine($"Please insert the next parameter for the #{i} wheel");
                    wheels.Add(createWheelFromUser());
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid wheels mode selection");
            }
            return wheels;
        }

        private Wheel createWheelFromUser()
        {
            Console.Write("Please insert the max PSI: ");
            float userMaxPSI = float.Parse(Console.ReadLine());
            Console.Write("Please insert the manufaturer: ");
            string userManufaturer = Console.ReadLine();
            Console.Write("Please insert the current PSI: ");
            float userCurrentPSI = float.Parse(Console.ReadLine());
            return new Wheel(userMaxPSI, userManufaturer, userCurrentPSI);
        }
    }
}
