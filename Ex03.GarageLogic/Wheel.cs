using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private readonly float r_MaxPSI;
        private string m_Manufacturer;
        private float m_CurrentPSI;


        public Wheel(float i_MaxPSI, string i_Manufaturer, float i_CurrentPsi)
        {
            r_MaxPSI = i_MaxPSI;
            m_Manufacturer = i_Manufaturer;
            m_CurrentPSI = i_CurrentPsi;
        }
        public float CurrentPSI
        {
            get
            {
                return m_CurrentPSI;
            }

            set
            {
                m_CurrentPSI = value;
            }
        }

        public float MaxPSI
        {
            get
            {
                return r_MaxPSI;
            }
        }

        public string Manufacturer
        {
            get
            {
                return m_Manufacturer;
            }

            set
            {
                m_Manufacturer = value;
            }
        }

        public void Inflate(float i_PSItoAdd)
        {
            if(i_PSItoAdd + m_CurrentPSI > r_MaxPSI)
            {
                // TODO: Adjust the exception after writing the exception class
                throw new ValueOutOfRangeException();
            }
            else
            {
                m_CurrentPSI += i_PSItoAdd;
            }
        }
    }
}
