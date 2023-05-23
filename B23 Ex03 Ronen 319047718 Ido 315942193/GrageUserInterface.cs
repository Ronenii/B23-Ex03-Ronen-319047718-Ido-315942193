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
            int userInput;
            string errorMessage = null;
            Action.eAction action;
            do
            {
                printWelcomeMessage();
                printMenu();
                printErrorMessage(errorMessage); 
                userInput = getUserChoice();
                action = Action.ConvertIntgerToeAction(userInput);
                try
                {
                    errorMessage = null;
                    handleRequestByAction(action);
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                }
                Console.Clear();
            }
            while(action != Action.eAction.Exit);
        }

        private void handleRequestByAction(Action.eAction i_Action)
        {
            GarageHandleManager garageHandleManager = new GarageHandleManager();
            switch (i_Action)
            {
                case Action.eAction.NewCar:
                    garageHandleManager.AddingNewCar();
                    Console.ReadKey();
                    break;
                case Action.eAction.ShowGarageCar:
                    garageHandleManager.ShowGrageCar();
                    Console.ReadKey();
                    break;
                case Action.eAction.ChangeCarStatus:
                    garageHandleManager.ChangeCarStatus();
                    Console.ReadKey();
                    break;
                case Action.eAction.InflateWheel:
                    garageHandleManager.InflateWheel();
                    Console.ReadKey();
                    break;
                case Action.eAction.FillFuel:
                    garageHandleManager.FuelVehicle();
                    Console.ReadKey();
                    break;
                case Action.eAction.ChargeElectronicCar:
                    garageHandleManager.ChargeVehicle();
                    Console.ReadKey();
                    break;
                case Action.eAction.PresentCar:
                    garageHandleManager.PresentCar();
                    break;
                case Action.eAction.Exit:
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        private int getUserChoice()
        {
            int o_UserInputInteger;
            string userInput;
            do
            {
                userInput = Console.ReadLine();
            }
            while (!validateUserActionInput(userInput, out o_UserInputInteger));
            return o_UserInputInteger;
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
            Console.WriteLine("8. Exit");
        }

        private bool validateUserActionInput(string i_UserInput, out int o_UserInputInteger)
        {
            bool isValid = true;
            int.TryParse(i_UserInput, out o_UserInputInteger);
            if (!(o_UserInputInteger > 0 && o_UserInputInteger <= 7))
            {
                Console.WriteLine("Invalid Input");
                isValid = false;
            }
            return isValid;
        }

        private void printErrorMessage(string i_ErrorMessage)
        {
            if(i_ErrorMessage != null)
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
