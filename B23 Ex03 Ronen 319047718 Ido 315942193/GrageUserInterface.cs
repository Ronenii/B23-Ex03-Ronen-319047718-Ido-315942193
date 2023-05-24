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

        private GarageManager garageHandleManager = new GarageManager();

        // Main Program loop
        public void Run()
        {
            string errorMessage = null;
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
                    errorMessage = e.Message;
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
                    garageHandleManager.AddingNewCar();
                    break;
                case eUserAction.ShowGarageCar:
                    garageHandleManager.ShowGrageCar();
                    break;
                case eUserAction.ChangeCarStatus:
                    garageHandleManager.ChangeCarStatus();
                    break;
                case eUserAction.InflateWheel:
                    garageHandleManager.InflateWheel();
                    break;
                case eUserAction.FillFuel:
                    garageHandleManager.FuelVehicle();
                    break;
                case eUserAction.ChargeElectronicCar:
                    garageHandleManager.ChargeVehicle();
                    break;
                case eUserAction.PresentCar:
                    garageHandleManager.PresentCar();
                    break;
                case eUserAction.Exit:
                    Display.Goodbye();
                    break;
            }
        }

        // Prompts the user to input an action and validates it
        private eUserAction getUserAction()
        {
            eUserAction userAction;
            string userActionStr = Console.ReadLine();
            if (!(eUserAction.TryParse(userActionStr, out userAction) && Enum.IsDefined(typeof(eUserAction), userAction)))
            {
                throw new ArgumentException("No such menu option");
            }
            return userAction;
        }
    }
}
