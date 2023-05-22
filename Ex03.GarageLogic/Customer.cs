using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Customer
    {
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNum;

        public Customer(string i_OwnerName, string i_OwnerPhoneNum)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNum = i_OwnerPhoneNum;
        }

        public string OwnerName
        {
            get
            {
                return r_OwnerName;
            }
        }

        public string OwnerPhoneNum
        {
            get
            {
                return r_OwnerPhoneNum;
            }
        }
    }
}
