namespace GonzaLorenzo.MathGame;

internal class Menu
{
    internal void GameMenu(string name)
    {
        GameEngine engine = new();

        bool isGameOn = true;

        do
        {
            Console.Clear();

            Console.WriteLine(@$"Hello {name.Trim()}. What game would you like to play today? Choose from the options below:
            1 - Addition
            2 - Substraction
            3 - Multiplication
            4 - Division
            5 - Random
            6 - View games history.
            7 - Exit the program");

            string gameSelected = Console.ReadLine();

            while (string.IsNullOrEmpty(gameSelected) || !int.TryParse(gameSelected, out _))
            {
                Console.WriteLine("Invalid input. Please choose the game you would like to play.");
                gameSelected = Console.ReadLine();               
            } 

            switch (gameSelected)
            {
                case "1":
                    engine.SetGameMode(GameMode.Addition);
                    break;

                case "2":
                    engine.SetGameMode(GameMode.Substraction);
                    break;

                case "3":
                    engine.SetGameMode(GameMode.Multiplication);
                    break;

                case "4":
                    engine.SetGameMode(GameMode.Division);
                    break;

                case "5":
                    engine.SetGameMode(GameMode.Random);
                    break;

                case "6":
                    Helpers.ViewGamesHistory();
                    break;

                case "7":
                    isGameOn = false;
                    break;
            }
        } while (isGameOn);
    }
}
