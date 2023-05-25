﻿using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;

namespace B23_Ex03_Ronen_319047718_Ido_315942193
{
    public class GarageManager
    {
        private const string formatErrorMessage = "Input must be in numbers";
        private Garage garage = new Garage();
        private VehicleFactory vehicleFactory = new VehicleFactory();

        // Adding new vehicle by user input
        public void AddingNewVehicle()
        {
            Console.WriteLine("Please insert the license plate");
            string licensePLate = Console.ReadLine();
            Vehicle vehicle = garage.GetVehicleByLicense(licensePLate);
            if (vehicle == null)
            {
                Console.WriteLine("Create new vehicle in the system");
                Display.ChooseCarTypePrompt();
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

        //Show all licence plate in the garage
        public void ShowGrageCar()
        {
            List<Vehicle> vehicles;
            Display.FilteringStatus();
            string filteringUser = Console.ReadLine();
            vehicles = getFilterGarageVehicle(filteringUser);
            for (int i = 1; i <= vehicles.Count; i++)
            {
                Console.WriteLine($"{i}. {vehicles[i - 1].LicensePlate}");
            }
        }

        private List<Vehicle> getFilterGarageVehicle(string i_FilteringUser)
        {
            List<Vehicle> vehicles;
            if (i_FilteringUser == "1")
            {
                vehicles = getFilterVehiclesByStatus(eVehicleStatus.InRepair);
            }
            else if (i_FilteringUser == "2")
            {
                vehicles = getFilterVehiclesByStatus(eVehicleStatus.Repaired);

            }
            else if (i_FilteringUser == "3")
            {
                vehicles = getFilterVehiclesByStatus(eVehicleStatus.Paid);
            }
            else if (i_FilteringUser == "4")
            {
                vehicles = garage.GetAllVehicles();
            }
            else
            {
                throw new ArgumentException("Invalid filtering status option");
            }

            return vehicles;
        }

        private List<Vehicle> getFilterVehiclesByStatus(eVehicleStatus i_VehicleStatus)
        {
            return garage.GetAllVehicles().Where(vehicle => vehicle.Status == i_VehicleStatus).ToList();
        }

        //Update the status of the vehicle by user input
        public void ChangeCarStatus()
        {
            eVehicleStatus vehicleStatus;
            Console.Write("Please insert the Licence plate for the car: ");
            string licensePlate = Console.ReadLine();
            vehicleStatus = getVehicleStatusFromUser();
            garage.UpdateVehicleStatus(licensePlate, vehicleStatus);
            Console.WriteLine($"The vehicle with the license plate: {licensePlate} updated successfully to \"{vehicleStatus}\" ");
        }

        private eVehicleStatus getVehicleStatusFromUser()
        {
            eVehicleStatus vehicleStatus;
            Display.StatusChoosePrompt();
            string vehicleStatusStr = Console.ReadLine();
            if (eVehicleStatus.TryParse(vehicleStatusStr, out vehicleStatus))
            {
                if (!Enum.IsDefined(typeof(eVehicleStatus), vehicleStatus))
                {
                    throw new ArgumentException("Vehicle status not listed on the menu");
                }
            }
            else
            {
                throw new FormatException(formatErrorMessage);
            }
            return vehicleStatus;
        }

        //Inflate Wheel to max by vehicle type
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

        // Responsible for handling user input and executing fueling logic and validations.
        public void FuelVehicle()
        {
            eFuelType fuelType;
            float litersToAdd;
            Vehicle vehicleToFuel;

            vehicleToFuel = FindVehicleInGarage();
            if (vehicleToFuel is DieselVehicle dieselVehicle)
            {
                if (dieselVehicle.isTankFull())
                {
                    throw new InvalidOperationException("Tank full");
                }
                fuelType = getFuelTypeFromUser();
                litersToAdd = getLitersToAddFromUser();
                dieselVehicle.Fuel(litersToAdd, fuelType);
            }
            else
            {
                throw new ArgumentException("Can't fuel an electric car");
            }
        }

        // Prompts user to input liters to fuel and validates the input format wise
        private float getLitersToAddFromUser()
        {
            float litersToAdd;
            Console.Write("Liters to add: ");
            string litersToAddStr = Console.ReadLine();

            if (!float.TryParse(litersToAddStr, out litersToAdd))
            {
                throw new FormatException(formatErrorMessage);
            }

            return litersToAdd;
        }

        // Prompts the user to input fuel type and validates the input
        private eFuelType getFuelTypeFromUser()
        {
            eFuelType fuelType;
            Display.ChooseFuelPrompt();
            string fuelTypeStr = Console.ReadLine();
            if (eFuelType.TryParse(fuelTypeStr, out fuelType))
            {
                if (!Enum.IsDefined(typeof(eFuelType), fuelType))
                {
                    throw new ArgumentException("Fuel not listed on the menu");
                }
            }
            else
            {
                throw new FormatException(formatErrorMessage);
            }

            return fuelType;
        }

        // Propts the user to enter a license plate number and returns a vehicle 
        // with the corresponding license plate in the garage.
        // If vehicle not found throws an exception.
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

        // Responsible for handling user input and executing charging logic and validations.
        public void ChargeVehicle()
        {
            int minutesToCharge;
            Vehicle vehicleToCharge;

            vehicleToCharge = FindVehicleInGarage();
            if (vehicleToCharge is ElectricVehicle electricVehicle)
            {
                if (electricVehicle.isBatteryFull())
                {
                    throw new InvalidOperationException("Battery full");
                }
                minutesToCharge = getMinutesToChargeFromUser();
                (vehicleToCharge as ElectricVehicle).ChargeBattery(minutesToCharge);
            }
            else
            {
                throw new ArgumentException("Can't charge a fuel powered vehicle");
            }
        }

        // Prompts user to input number of minutes to charge and validates the input format wise
        private int getMinutesToChargeFromUser()
        {
            int minutesToCharge;
            Console.Write("Minutes to charge: ");
            string minutesToChargeStr = Console.ReadLine();

            if (!int.TryParse(minutesToChargeStr, out minutesToCharge))
            {
                throw new FormatException(formatErrorMessage);
            }
            return minutesToCharge;
        }

        // Prints out the requested vehicle by license plate
        public void PresentCar()
        {
            Vehicle vehicleToPresent;
            vehicleToPresent = FindVehicleInGarage();

            Display.VehicleDetails(vehicleToPresent);
            Display.WheelDetails(vehicleToPresent);
            if (vehicleToPresent is DieselVehicle dieselVehicle)
            {
                printDieselVehicleDetails(dieselVehicle);
            }
            else if (vehicleToPresent is ElectricVehicle electricVehicle)
            {
                printElectricVehicleDetails(electricVehicle);
            }
        }

        // Prints the relevant details for diesel vehicles
        private void printDieselVehicleDetails(DieselVehicle i_DieselVehicle)
        {
            Display.FuelDetails(i_DieselVehicle);
            if (i_DieselVehicle is DieselCar dieselCar)
            {
                Display.CarDetails(dieselCar.CarProperties);
            }
            else if (i_DieselVehicle is DieselMotorcycle dieselMotorcycle)
            {
                Display.MotorcycleDetails(dieselMotorcycle.MotorcycleProperties);
            }
            else if (i_DieselVehicle is Truck truck)
            {
                Display.TruckDetails(truck);
            }
        }

        // Prints the relevant details for electric vehicles
        private void printElectricVehicleDetails(ElectricVehicle i_ElectricVehicle)
        {
            Display.BatteryDetails(i_ElectricVehicle);
            if (i_ElectricVehicle is ElectricCar electricCar)
            {
                Display.CarDetails(electricCar.CarProperties);
            }
            else if (i_ElectricVehicle is ElectricMotorcycle electricMotorcycle)
            {
                Display.MotorcycleDetails(electricMotorcycle.MotorcycleProperties);
            }
        }
    }
}
