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

        private GarageHandleManager garageHandleManager = new GarageHandleManager();

        public void Run()
        {
            string errorMessage = null;
            eUserAction userAction;
            do
            {
                printWelcomeMessage();
                printMenu();
                userAction = getUserAction();
                try
                {
                    handleRequestByAction(userAction);
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                    printErrorMessage(errorMessage);
                }
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                Console.Clear();
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
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    break;
            }
        }

        private eUserAction getUserAction()
        {
            eUserAction userAction;
            string userActionStr = Console.ReadLine();
            if(!eUserAction.TryParse(userActionStr, out userAction))
            {
                throw new ArgumentException("No such menu option");
            }
            return userAction;
        }

        private void printMenu()
        {
            Console.WriteLine("Please enter one of the folowing options");
            Console.WriteLine("1. Insert a new vehicle");
            Console.WriteLine("2. Show all vehicles in the garage");
            Console.WriteLine("3. Change vehicle status");
            Console.WriteLine("4. Inflate vehicle Wheel");
            Console.WriteLine("5. Refuel a vehicle");
            Console.WriteLine("6. Charge a vehicle");
            Console.WriteLine("7. Present a vehicle");
            Console.WriteLine("8. Exit");
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

        private void printErrorMessage(string i_ErrorMessage)
        {
            if (i_ErrorMessage != null)
            {
                Console.WriteLine($"ERROR: **{i_ErrorMessage}**");
            }
        }

        private void printWelcomeMessage()
        {
            string welcomeText = @"                                                                                    
 _ _ _     _                      _          _   _                                  
| | | |___| |___ ___ _____ ___   | |_ ___   | |_| |_ ___    ___ ___ ___ ___ ___ ___ 
| | | | -_| |  _| . |     | -_|  |  _| . |  |  _|   | -_|  | . | .'|  _| .'| . | -_|
|_____|___|_|___|___|_|_|_|___|  |_| |___|  |_| |_|_|___|  |_  |__,|_| |__,|_  |___|
                                                           |___|           |___|     ";

            Console.WriteLine(welcomeText);
        }
    }
}
