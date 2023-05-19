using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Car
    {
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
    }
}
