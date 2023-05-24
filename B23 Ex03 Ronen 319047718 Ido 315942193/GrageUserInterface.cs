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

        public void Run()
        {
            string errorMessage = null;
            eUserAction userAction;
            do
            {
                Display.PrintWelcomeMessage();
                Display.PrintMenu();
                userAction = getUserAction();
                try
                {
                    handleRequestByAction(userAction);
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                    Display.PrintErrorMessage(errorMessage);
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
                    Display.PrintGoodbye();
                    break;
            }
        }

        private eUserAction getUserAction()
        {
            eUserAction userAction;
            string userActionStr = Console.ReadLine();
            if (!eUserAction.TryParse(userActionStr, out userAction))
            {
                throw new ArgumentException("No such menu option");
            }
            return userAction;
        }

        private bool validateUserActionInput(string i_UserInput, out int o_UserInputInteger)
        {
            bool isValid = true;
            int.TryParse(i_UserInput, out o_UserInputInteger);
            if (!(o_UserInputInteger > 0 && o_UserInputInteger <= 8))
            {
                Console.WriteLine("Invalid Input");
                isValid = false;
            }
            return isValid;
        }
    }
}
