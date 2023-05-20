using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex03_Ronen_319047718_Ido_315942193
{
    public class GarageHandleManager
    {
        private Ex03.GarageLogic.LogicInterface logicInterface = new Ex03.GarageLogic.LogicInterface();

        public void AddingNewCar()
        {
            Console.WriteLine("Please insert the license plate");
            String licensePLate = Console.ReadLine();
            logicInterface.AddNewCar(licensePLate);

        }
        public void ShowGrageCar()
        {
            Console.WriteLine("ShowGrageCar logic");
        }
        public void ChangeCarStatus()
        {
            Console.WriteLine("ChangeCarStatus logic");
        }
        public void InflateWheel()
        {
            Console.WriteLine("InflateWheel logic");
        }
        public void FillFuel()
        {
            Console.WriteLine("FillFuel logic");
        }
        public void ChargeElctonicCar()
        {
            Console.WriteLine("ChargeElctonicCar logic");
        }
        public void PresentCar()
        {
            Console.WriteLine("PresentCar logic");
        }
    }
}
