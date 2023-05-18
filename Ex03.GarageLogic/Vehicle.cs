using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eEngineType
    {
        Diesel,
        Electric
    }
    public abstract class Vehicle
    {
        private readonly string r_Model;
        private readonly string r_LicensePlate;
        private float m_EnergyLeft;

        private List<Wheel> m_Wheels;

        public Vehicle(string i_Model, string i_LicensePlate, float i_EnergyLeft ,float i_MaxPSI, string i_WheelManufacturer,float i_CurrentPsi , int i_NumOfWheels)
        {
            r_Model = i_Model;
            r_LicensePlate = i_LicensePlate;
            m_EnergyLeft = i_EnergyLeft;
            createAllWheels(i_NumOfWheels, i_CurrentPsi, i_WheelManufacturer, i_MaxPSI);
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

        // Adds the given amount of wheels to this vehicle's wheels list
        private void createAllWheels(int i_NumOfWheels, float i_PSI, string i_WheelManufacturer, float i_MaxPSI)
        {
            for(int i = 0; i < i_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_MaxPSI,i_WheelManufacturer,i_PSI));
            }
        }

        public void InflateAllWheelsToMax(float i_PSI)
        {
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.Inflate(wheel.MaxPSI - wheel.CurrentPSI);
            }
        }
    }

}
