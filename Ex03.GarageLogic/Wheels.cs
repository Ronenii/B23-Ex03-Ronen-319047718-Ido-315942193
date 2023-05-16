using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Wheels
    {
        private readonly float r_MaxPSI;
        private string m_Manufacturer;
        private float m_PSI;

        public float PSI
        {
            get
            {
                return m_PSI;
            }

            set
            {
                m_PSI = value;
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

        }
    }
}
