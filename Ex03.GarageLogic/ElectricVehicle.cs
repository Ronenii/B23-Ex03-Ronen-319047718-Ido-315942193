﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle: Vehicle
    {
        private readonly float r_MaxChargeHours;
        private float m_ChargeHoursLeft;

        public ElectricVehicle(
            string i_Model,
            string i_LicensePlate,
            float i_EnergyLeft,
            float i_MaxPSI,
            string i_WheelManufacturer,
            float i_CurrentPSI,
            int i_NumOfWheels,
            float i_ChargeHoursLeft,
            float i_MaxChargeHours): base(i_Model,i_LicensePlate,i_EnergyLeft,i_MaxPSI,i_WheelManufacturer,i_CurrentPSI,i_NumOfWheels)
        {
            m_ChargeHoursLeft = i_ChargeHoursLeft;
            r_MaxChargeHours = i_MaxChargeHours;
        }

        public float MaxChargeHours
        {
            get
            {
                return r_MaxChargeHours;
            }
        }

        public float ChargeHoursLeft
        {
            get
            {
                return ChargeHoursLeft;
            }

            set
            {
                ChargeHoursLeft = value;
            }
        }

        public void ChargeBattery(float i_HoursToCharge)
        {
            if(i_HoursToCharge + m_ChargeHoursLeft > m_ChargeHoursLeft)
            {
                // TODO: Adjust the exception after writing the exception class
                throw new ValueOutOfRangeException();
            }
            else
            {
                m_ChargeHoursLeft += i_HoursToCharge;
                EnergyLeft = m_ChargeHoursLeft / MaxChargeHours;
            }
        }

    }
}