using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car
    {
        public const int k_NumOfWheels = 5;
        private const float k_MaxPSI = 33f;

        private readonly eNumOfCarDoors r_NumOfDoors;
        private readonly eCarColor r_Color;

        public Car(eCarColor i_Color, eNumOfCarDoors i_NumOfDoors)
        {
            r_NumOfDoors = i_NumOfDoors;
            r_Color = i_Color;
        }

        public eCarColor Color
        {
            get
            {
                return r_Color;
            }
        }
        public eNumOfCarDoors NumOfDoors
        {
            get
            {
                return r_NumOfDoors;
            }
        }

        public static float MaxPSI
        {
            get
            {
                return k_MaxPSI;
            }
        }

        public static int NumOfWheels
        {
            get
            {
                return k_NumOfWheels;
            }
        }
    }
}
