using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly float r_MaxPSI;
        private readonly string r_Manufacturer;
        private float m_CurrentPSI;

        public Wheel(float i_MaxPSI, string i_Manufaturer, float i_CurrentPsi)
        {
            r_MaxPSI = i_MaxPSI;
            r_Manufacturer = i_Manufaturer;
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
                return r_Manufacturer;
            }
        }

        public void Inflate(float i_PSItoAdd)
        {
            if(i_PSItoAdd < 0 || i_PSItoAdd > r_MaxPSI)
            {
                throw new ValueOutOfRangeException(0, MaxPSI);
            }
            if (i_PSItoAdd + m_CurrentPSI > r_MaxPSI)
            {
                throw new ValueOutOfRangeException(0, r_MaxPSI - CurrentPSI);
            }
            else
            {
                m_CurrentPSI += i_PSItoAdd;
            }
        }
    }
}
