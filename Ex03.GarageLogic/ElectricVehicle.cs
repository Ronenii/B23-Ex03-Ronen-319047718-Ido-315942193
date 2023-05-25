using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        private readonly float r_MaxChargeHours;
        private float m_ChargeHoursLeft;

        public ElectricVehicle(
            string i_Model,
            string i_LicensePlate,
            List<Wheel> i_Wheels,
            Customer i_Owner,
            eVehicleStatus i_VehicleStatus,
            float i_ChargeHoursLeft,
            float i_MaxChargeHours) : base(i_Model, i_LicensePlate, i_ChargeHoursLeft / i_MaxChargeHours, i_Wheels, i_Owner, i_VehicleStatus)
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
                return m_ChargeHoursLeft;
            }

            set
            {
                m_ChargeHoursLeft = value;
            }
        }

        // Adds given charge minutes to the vehicle, throws exceptions if too much minutes
        // or if given amount out of range
        public void ChargeBattery(int i_MinutesToCharge)
        {
            float hoursToCharge = i_MinutesToCharge / 60f;
            if (!(isHoursToChargeNotTooMuch(hoursToCharge) && isHoursToChargeValid(hoursToCharge)))
            {
                throw new ValueOutOfRangeException(0, floatHoursToMinutes(MaxChargeHours - m_ChargeHoursLeft) - 1);
            }
            else
            {
                m_ChargeHoursLeft += hoursToCharge;
                EnergyLeft = m_ChargeHoursLeft / MaxChargeHours;
            }
        }

        public bool IsBatteryFull()
        {
            return m_ChargeHoursLeft >= r_MaxChargeHours;
        }

        // Converts hours represented as float to minutes in int
        private int floatHoursToMinutes(float i_FloatHours)
        {
            int hours = Convert.ToInt32(i_FloatHours);
            int minutes = Convert.ToInt32((i_FloatHours - hours) * 60);

            return hours * 60 + minutes;
        }

        private bool isHoursToChargeValid(float i_HoursToCharge)
        {
            return i_HoursToCharge >= 0 && i_HoursToCharge <= r_MaxChargeHours;
        }

        private bool isHoursToChargeNotTooMuch(float i_HoursToCharge)
        {
            return m_ChargeHoursLeft + i_HoursToCharge <= r_MaxChargeHours;
        }

        // Converts the charge time to string and prsents it in said format H:MM
        public string ChargeTimeToString()
        {
            int hours = Convert.ToInt32(m_ChargeHoursLeft);
            int minutes = Convert.ToInt32((m_ChargeHoursLeft - hours) * 60);

            string time = string.Format("{0}:{1:D2}", hours, minutes);
            return time;
        }
    }
}
