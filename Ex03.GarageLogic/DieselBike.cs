using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eBikeLicense
    {
        A1,
        A2,
        AA,
        B1
    }
    public class DieselBike : DieselVehicle
    {
        private eBikeLicense m_License;
        private int m_EngineSize;


    }
}
