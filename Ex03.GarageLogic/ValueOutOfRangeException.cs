using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float m_MaxValue;
        private readonly float m_MinValue;

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) : 
            base(string.Format("Value must be between {0} and {1}",i_MinValue,i_MaxValue))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MaxValue;
        }


    }
}
