﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private List<Vehicle> m_AllVehicles = new List<Vehicle>();

        public void AddNewVehicle(Vehicle vehicle)
        {
            m_AllVehicles.Add(vehicle);
        }

        public Vehicle GetVehicleByLicense(string i_LicencePlate)
        {
            return m_AllVehicles.FirstOrDefault(vehicle => vehicle.LicensePlate == i_LicencePlate);
        }

        public void UpdateVehicleStatus(string i_LicensePlate, eVehicleStatus i_Status)
        {
            Vehicle vehicle = GetVehicleByLicense(i_LicensePlate);
            if (vehicle == null)
            {
                throw new ArgumentNullException("Could not find the given license plate in the system");
            }

            vehicle.Status = i_Status;
        }

        public List<Vehicle> GetAllVehicles()
        {
            return m_AllVehicles;
        }
    }
}
