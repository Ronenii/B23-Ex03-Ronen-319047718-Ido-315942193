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
    public abstract class DieselVehicle: Vehicle
    {
        private float m_FuelLitersLeft;
        private float m_MaxFuelLiters;
        
        // TODO: Add Constructor like in Electric Vehicle
        public void Fuel(float i_FuelLitersToAdd)
        {
            if (m_FuelLitersLeft + i_FuelLitersToAdd > m_MaxFuelLiters)
            {
                // TODO: Adjust the exception after writing the exception class
                throw new ValueOutOfRangeException();
            }
            else
            {
                m_FuelLitersLeft += i_FuelLitersToAdd;
            }
        }
    }
}
