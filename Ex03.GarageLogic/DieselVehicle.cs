﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class DieselVehicle : Vehicle
    {
        private readonly float r_MaxFuelLiters;
        private readonly eFuelType r_FuelType;

        private float m_FuelLitersLeft;

        public float MaxFuelLiters
        {
            get
            {
                return r_MaxFuelLiters;
            }
        }

        public float FuelLitersLeft
        {
            get
            {
                return m_FuelLitersLeft;
            }

            set
            {
                m_FuelLitersLeft = value;
            }
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public DieselVehicle(
            string i_Model,
            string i_LicensePlate,
            List<Wheel> i_Wheels,
            Customer i_Owner,
            eVehicleStatus i_VehicleStatus,
            float i_FuelLitersLeft,
            float i_MaxFuelLiters,
            eFuelType i_FuelType) : base(i_Model, i_LicensePlate, i_FuelLitersLeft / i_MaxFuelLiters, i_Wheels, i_Owner, i_VehicleStatus)
        {
            m_FuelLitersLeft = i_FuelLitersLeft;
            r_MaxFuelLiters = i_MaxFuelLiters;
            r_FuelType = i_FuelType;
        }



        public void Fuel(float i_FuelLitersToAdd, eFuelType i_FuelType)
        {
            if (!isFuelTypeValid(i_FuelType))
            {
                // TODO: adjust exception output
                throw new ArgumentException();
            }

            if (m_FuelLitersLeft + i_FuelLitersToAdd > r_MaxFuelLiters)
            {
                throw new ValueOutOfRangeException(0, MaxFuelLiters);
            }
            else
            {
                m_FuelLitersLeft += i_FuelLitersToAdd;
                EnergyLeft = m_FuelLitersLeft / MaxFuelLiters;
            }
        }

        private bool isFuelTypeValid(eFuelType i_FuelType)
        {
            return i_FuelType == r_FuelType;
        }

        public string FuelTypeToString()
        {
            string fuelType;
            switch (r_FuelType)
            {
                case eFuelType.Soler:
                    fuelType = "Soler";
                    break;
                case eFuelType.Octan95:
                    fuelType = "Octan 95";
                    break;
                case eFuelType.Octan96:
                    fuelType = "Octan 96";
                    break;
                case eFuelType.Octan98:
                    fuelType = "Octan 98";
                    break;
                default:
                    fuelType = String.Empty;
                    break;
            }

            return fuelType;
        }
    }
}
