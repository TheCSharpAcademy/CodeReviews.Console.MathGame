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

                        int score = gameEngine.RunGame(gameChoice);
                        GameRecord gc = new GameRecord { PlayerName = playerName, GameDate = currentDate, Score = score };
                        GameRepository.AddNewGameRecord(gc);
                    }
                    return true;
                case "2":
                    ShowPreviousGames();
                    return true;
                case "3":
                    ShowAbout();
                    return true;
                case "4":
                    return false;
                default: 
                    MessageHelper.ShowErrorMessage("Invalid choice. Please enter a valid one.");
                    return true;
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
            Console.Clear();
            GameRepository.PrintAllGameRecords();
            Console.WriteLine();
            Console.WriteLine("Press any key to back to main menu.");
            Console.ReadKey();
        }

        private static void ShowAbout()
        {
            Console.Clear();
            Console.WriteLine("Created by Alvaro Mosconi");
            Console.WriteLine("Github: @alvaromosconi");
            Console.WriteLine();
            Console.WriteLine("Press any key to back to main menu.");
            Console.ReadKey();
        }

    }
}