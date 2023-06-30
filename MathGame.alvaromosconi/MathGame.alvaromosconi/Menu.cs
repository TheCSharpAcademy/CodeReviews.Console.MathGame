using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.alvaromosconi
{ 
    internal class Menu
    {
        private string playerName;
        private DateTime currentDate;
        private GameEngine gameEngine;
        public Menu(
            string playerName,
            DateTime currentDate,
            GameEngine gameEngine)
        {
            this.playerName = playerName;
            this.currentDate = currentDate;
            this.gameEngine = gameEngine;

            DisplayMenu();
        }

        void DisplayMenu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                ShowMainMenuOptions();
                string choice = GetUserChoice();
                keepRunning = ProcessMainMenuUserChoice(choice);
            }
        }

        private void ShowMainMenuOptions()
        {
            Console.Clear();
            Console.WriteLine("----- Calculator Game Menu -----");
            Console.WriteLine("1. Choose Game");
            Console.WriteLine("2. Previous Games");
            Console.WriteLine("3. About");
            Console.WriteLine("4. Exit");
            Console.WriteLine("---------------------------------");
            Console.Write("Enter your choice (1-4): ");
        }

        private string GetUserChoice()
        {
            return Console.ReadLine();
        }

        private bool ProcessMainMenuUserChoice(string mainMenuChoice)
        {
            switch (mainMenuChoice)
            {
                case "1":
                    {
                        string gameChoice = String.Empty;
                        bool validChoice = false;
                        do
                        {
                            ShowGameOptions();
                            gameChoice = GetUserChoice();
                            validChoice = IsAValidGameOption(gameChoice);

                            if (!validChoice)
                                MessageHelper.ShowErrorMessage("Invalid choice. Please enter a valid one.");
                        
                        } while (!validChoice);

                        gameEngine.RunGame(gameChoice);
                    }
                    return true;
                case "2":
                    ShowPreviousGames();
                    return true;
                case "3":
                    return true;
                case "4":
                    return true;
                case "5":
                    return false;
                default: 
                    MessageHelper.ShowErrorMessage("Invalid choice. Please enter a valid one.");
                    return false;
            }
        }

        private static void ShowGameOptions()
        {
            Console.Clear();
            Console.WriteLine("----- Game Options -----");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. For back to main menu");
            Console.WriteLine("---------------------------------");
            Console.Write("Enter your choice (1-5): ");
        }

        private bool IsAValidGameOption(string gameChoice)
        {
            return gameChoice == "1" || 
                   gameChoice == "2" || 
                   gameChoice == "3" || 
                   gameChoice == "4" || 
                   gameChoice == "5";
        }

        private static void ShowPreviousGames()
        {
            // Code to display previous games
        }

        private static void ShowAbout()
        {
            // Code to display information about the game
        }

    }
}