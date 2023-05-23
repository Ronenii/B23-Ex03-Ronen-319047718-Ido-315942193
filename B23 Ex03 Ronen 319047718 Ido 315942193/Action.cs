using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex03_Ronen_319047718_Ido_315942193
{
    public class Action
    {
        public enum eAction
        {
            NewCar,
            ShowGrageCar,
            ChangeCarStatus,
            InflateWheel,
            FillFuel,
            ChargeElctonicCar,
            PresentCar,
            Exit,
            Error
        }

        public static eAction ConvertIntgerToAction(int i_IntegerAction)
        {
            eAction action;
            if (i_IntegerAction == 1)
                action = eAction.NewCar;
            else if (i_IntegerAction == 2)
                action = eAction.ShowGrageCar;
            else if (i_IntegerAction == 3)
                action = eAction.ChangeCarStatus;
            else if (i_IntegerAction == 4)
                action = eAction.InflateWheel;
            else if (i_IntegerAction == 5)
                action = eAction.FillFuel;
            else if (i_IntegerAction == 6)
                action = eAction.ChangeCarStatus;
            else if (i_IntegerAction == 7)
                action = eAction.PresentCar;
            else if (i_IntegerAction == 8)
                action = eAction.Exit;
            else
                action = eAction.Error;
            return action;
        }

    }
}
