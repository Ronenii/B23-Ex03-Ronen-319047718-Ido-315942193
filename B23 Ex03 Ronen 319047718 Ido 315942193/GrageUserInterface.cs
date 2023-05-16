using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex03_Ronen_319047718_Ido_315942193
{
    public class GrageUserInterface
    {
        public void Run()
        {
            printWelcomeMessage();
            printMenu();
            int userInput = getUserChoice();
            Action.eAction action = Action.ConvertIntgerToeAction(userInput);
            handleRequestByAction(action);
            Console.ReadKey();
        }

        private void handleRequestByAction(Action.eAction i_Action)
        {
            GarageHandleManager garageHandleManager = new GarageHandleManager();
            switch (i_Action)
            {
                case Action.eAction.NewCar:
                    garageHandleManager.AddingNewCar();
                    break;
                case Action.eAction.ShowGrageCar:
                    garageHandleManager.ShowGrageCar();
                    break;
                case Action.eAction.ChangeCarStatus:
                    garageHandleManager.ChangeCarStatus();
                    break;
                case Action.eAction.InflateWheel:
                    garageHandleManager.InflateWheel();
                    break;
                case Action.eAction.FillFuel:
                    garageHandleManager.FillFuel();
                    break;
                case Action.eAction.ChargeElctonicCar:
                    garageHandleManager.ChargeElctonicCar();
                    break;
                case Action.eAction.PresentCar:
                    garageHandleManager.PresentCar();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        private int getUserChoice()
        {
            int o_userInputInteger;
            string userInput;
            do
            {
                userInput = Console.ReadLine();
            }
            while (!validateUserActionInput(userInput, out o_userInputInteger));
            return o_userInputInteger;
        }

        private void printMenu()
        {
            Console.WriteLine("Please enter one of the folowing options");
            Console.WriteLine("1. Insert new car");
            Console.WriteLine("2. Show all cars in the grage");
            Console.WriteLine("3. Change car status");
            Console.WriteLine("4. Inflate car Wheel");
            Console.WriteLine("5. Refuel a car");
            Console.WriteLine("6. Charge electronic car");
            Console.WriteLine("7. Present car by a license plate");
        }

        private bool validateUserActionInput(string i_UserInput, out int o_userInputInteger)
        {
            bool isValid = true;
            int.TryParse(i_UserInput, out o_userInputInteger);
            if (!(o_userInputInteger > 0 && o_userInputInteger <= 7))
            {
                Console.WriteLine("Invalid Input");
                isValid = false;
            }
            return isValid;
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
