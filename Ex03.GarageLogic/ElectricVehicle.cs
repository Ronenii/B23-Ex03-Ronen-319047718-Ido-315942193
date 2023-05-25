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
                return ChargeHoursLeft;
            }

            set
            {
                ChargeHoursLeft = value;
            }
        }

        public void ChargeBattery(float i_HoursToCharge)
        {
            if (i_HoursToCharge + m_ChargeHoursLeft > MaxChargeHours)
            {
                throw new ValueOutOfRangeException(0, MaxChargeHours);
            }
            else
            {
                m_ChargeHoursLeft += i_HoursToCharge;
                EnergyLeft = m_ChargeHoursLeft / MaxChargeHours;
            }
        }

        public string ChargeTimeToString()
        {
            int hours = Convert.ToInt32(m_ChargeHoursLeft);
            int minutes = Convert.ToInt32((m_ChargeHoursLeft - hours) * 60);

            string time = string.Format("{0}:{1:D2}", hours, minutes);
            return time;
        }

        public bool isBatteryFull()
        {
            return m_ChargeHoursLeft >= MaxChargeHours;
        }
    }
}
