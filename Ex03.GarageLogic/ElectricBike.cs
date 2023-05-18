﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricBike: ElectricVehicle
    {
        private const int k_NumOfWheels = 2;
        private const float k_MaxPSI = 31f;
        private const float k_MaxChargeHours = 2.6f;

        private readonly eBikeLicense r_License;
        private readonly int r_EngineSize;

        public ElectricBike(
            string i_Model,
            string i_LicensePlate,
            float i_EnergyLeft,
            string i_WheelManufacturer,
            float i_CurrentPSI,
            int i_NumOfWheels,
            float i_ChargeHoursLeft,
            eBikeLicense i_License, 
            int i_EngineSize)
            : base(
                i_Model,
                i_LicensePlate,
                i_EnergyLeft,
                k_MaxPSI,
                i_WheelManufacturer,
                i_CurrentPSI,
                k_NumOfWheels,
                i_ChargeHoursLeft,
                k_MaxChargeHours)
        {
            r_License = i_License;
            r_EngineSize = i_EngineSize;
        }

        public eBikeLicense License
        {
            get
            {
                return r_License;
            }
        }

        public int EngineSize
        {
            get
            {
                return r_EngineSize;
            }
        }
    }
}