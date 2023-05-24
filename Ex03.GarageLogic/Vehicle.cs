using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Soler = 1,
        Octan95,
        Octan96,
        Octan98
    }

    public enum eCarColor
    {
        White = 1,
        Black = 2,
        Yellow = 3,
        Red = 4
    }

    public enum eMotorcycleLicense
    {
        A1 = 1,
        A2 = 2,
        AA = 3,
        B1 = 4
    }
    public enum eNumOfCarDoors
    {
        Two = 2,
        Three,
        Four,
        Five
    }

    public enum eVehicleStatus
    {
        InRepair=1,
        Repaired=2,
        Paid=3
    }

    public enum eVehicleType
    {
        DieselCar,
        ElectricCar,
        DieselBike,
        ElectricBike,
        Truck
    }

    public abstract class Vehicle
    {
        private readonly string r_Model;
        private readonly string r_LicensePlate;
        private readonly Customer r_Owner;

        private float m_EnergyLeft;
        private List<Wheel> m_Wheels;
        private eVehicleStatus m_VehicleStatus;

        public Vehicle(string i_Model, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, Customer i_Owner, eVehicleStatus i_VehicleStatus)
        {
            r_Model = i_Model;
            r_LicensePlate = i_LicensePlate;
            r_Owner = i_Owner;
            m_EnergyLeft = i_EnergyLeft;
            m_Wheels = i_Wheels;
            m_VehicleStatus = i_VehicleStatus;
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

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        protected List<Wheel> initializeWheels(
            int i_NumOfWheels,
            float i_MaxPSI,
            float i_CurrentPSI,
            string i_Manufacturer)
        {
            List<Wheel> wheels = new List<Wheel>();
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                wheels.Add(new Wheel(i_MaxPSI, i_Manufacturer, i_CurrentPSI));
            }

            return wheels;
        }

        public string OwnerPhoneNum
        {
            get
            {
                return r_Owner.OwnerPhoneNum;
            }
        }

        public string OwnerName
        {
            get
            {
                return r_Owner.OwnerName;
            }
        }

        public eVehicleStatus Status
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public void InflateAllWheelsToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.Inflate(wheel.MaxPSI - wheel.CurrentPSI);
            }
        }

        public string VehicleStatusToString()
        {
            string vehicleStatus;
            switch (m_VehicleStatus)
            {
                case eVehicleStatus.InRepair:
                    vehicleStatus = "In repair";
                    break;
                case eVehicleStatus.Paid:
                    vehicleStatus = "Paid";
                    break;
                case eVehicleStatus.Repaired:
                    vehicleStatus = "Repaired";
                    break;
                default:
                    vehicleStatus =  String.Empty;
                    break;
            }

            return vehicleStatus;
        }
    }
}
