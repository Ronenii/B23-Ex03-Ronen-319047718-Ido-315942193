using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex03_Ronen_319047718_Ido_315942193
{
    public class GrageUserInterface
    {
        public enum eUserAction
        {
            NewCar = 1,
            ShowGarageCar,
            ChangeCarStatus,
            InflateWheel,
            FillFuel,
            ChargeElectronicCar,
            PresentCar,
            Exit,
            Error
        }

        private readonly GarageManager r_garageHandleManager = new GarageManager();

        // Main Program loop
        public void Run()
        {
            eUserAction userAction;
            do
            {
                Display.WelcomeMessage();
                Display.Menu();
                try
                {
                    userAction = getUserAction();
                    handleRequestByAction(userAction);
                }
                catch (Exception e)
                {
                    userAction = eUserAction.Error;
                    string errorMessage = e.Message;
                    Display.ErrorMessage(errorMessage);
                }
                Display.ActionEndingPrompt();
            }
            while (userAction != eUserAction.Exit);
        }

        private void handleRequestByAction(eUserAction i_Action)
        {
            switch (i_Action)
            {
                case eUserAction.NewCar:
                    r_garageHandleManager.AddingNewVehicle();
                    break;
                case eUserAction.ShowGarageCar:
                    r_garageHandleManager.ShowGrageCar();
                    break;
                case eUserAction.ChangeCarStatus:
                    r_garageHandleManager.ChangeCarStatus();
                    break;
                case eUserAction.InflateWheel:
                    r_garageHandleManager.InflateWheel();
                    break;
                case eUserAction.FillFuel:
                    r_garageHandleManager.FuelVehicle();
                    break;
                case eUserAction.ChargeElectronicCar:
                    r_garageHandleManager.ChargeVehicle();
                    break;
                case eUserAction.PresentCar:
                    r_garageHandleManager.PresentCar();
                    break;
                case eUserAction.Exit:
                    Display.Goodbye();
                    break;
            }
        }

        // Prompts the user to input an action and validates it
        private eUserAction getUserAction()
        {
            string userActionStr = Console.ReadLine();
            if (Enum.TryParse(userActionStr, out eUserAction userAction))
            {
                if (!Enum.IsDefined(typeof(eUserAction), userAction))
                {
                    throw new ArgumentException("No such menu option");
                }
            }
            else
            {
                throw new FormatException("Input must be in numbers");
            }
            return userAction;
        }
    }
}
