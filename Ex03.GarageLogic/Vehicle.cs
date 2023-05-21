using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98
    }

    public enum eCarColor
    {
        White,
        Black,
        Yellow,
        Red
    }

    public enum eBikeLicense
    {
        A1,
        A2,
        AA,
        B1
    }
    public enum eNumOfCarDoors
    {
        Two = 2,
        Three,
        Four,
        Five
    }

    public enum eVehicaleStatus
    {
        Ready = 1,
        Reapir = 2,
        Total_Loss = 3
    }

    public abstract class Vehicle
    {
        private readonly string r_Model;
        private readonly string r_LicensePlate;
        private float m_EnergyLeft;
        private eVehicaleStatus m_vehicaleStatus;

        private List<Wheel> m_Wheels;

        public Vehicle(string i_Model, string i_LicensePlate, float i_EnergyLeft, float i_MaxPSI, string i_WheelManufacturer, float i_CurrentPSI, int i_NumOfWheels, List<Wheel> i_Wheels, eVehicaleStatus i_VehicaleStatus)
        {
            r_Model = i_Model;
            r_LicensePlate = i_LicensePlate;
            m_EnergyLeft = i_EnergyLeft;
            m_Wheels = i_Wheels;
            m_vehicaleStatus = i_VehicaleStatus;

            // TODO: We are not using the given wheel properties, need to figure out what were gonna do with that...
        }
        public string Model
        {
            get
            {
                return r_Model;
            }
        }

        public float EnergyLeft
        {
            get
            {
                return m_EnergyLeft;
            }

            set
            {
                m_EnergyLeft = value;
            }
        }

        public string LicensePlate
        {
            get
            {
                return r_LicensePlate;
            }
        }

        public eVehicaleStatus Status
        {
            get
            {
                return m_vehicaleStatus;
            }

            set
            {
                m_vehicaleStatus = value;
            }
        }

        public void InflateAllWheelsToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.Inflate(wheel.MaxPSI - wheel.CurrentPSI);
            }
        }

        public abstract void PrintVehicleDescription();
    }
}
