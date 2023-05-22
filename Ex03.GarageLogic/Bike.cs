﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Bike
    {
        private const int k_NumOfWheels = 2;
        private const float k_MaxPSI = 31f;

        private readonly eBikeLicense r_License;
        private readonly int r_EngineSize;

        public Bike(eBikeLicense i_License, int i_EngineSize)
        {
            r_License = i_License;
            r_EngineSize = i_EngineSize;
        }

        public eBikeLicense License
        {
            get
            {
                return r_License;
            }
        }

        public int EngineSize
        {
            get
            {
                return r_EngineSize;
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
