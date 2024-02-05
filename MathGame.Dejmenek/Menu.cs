namespace MathGame.Dejmenek
{
    internal class Menu
    {
        private readonly static GamesHistory gamesHistory = new();
        public bool Exit = false;
        public MenuOptions Choice { get; set; }

        public Menu() { }

        public static void ShowMenu() {
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("1. Show your history of games");
            Console.WriteLine("2. Play game");
            Console.WriteLine("3. Exit");
        }

        public void SelectMenuOption() {
            string? userInput = Console.ReadLine();
            Choice = ValidateSelectMenuOption(userInput);

            switch (Choice)
            {
                case MenuOptions.ShowGamesHistory:
                    gamesHistory.Show();
                    break;
                case MenuOptions.PlayGame:
                    Game game = new();
                    game.Start();
                    gamesHistory.AddGame(game);
                    break;
                case MenuOptions.Exit:
                    Exit = true;
                    break;
            }
        }

        public static MenuOptions ValidateSelectMenuOption(string? input) {
            MenuOptions selectedOption;
            while (!Enum.TryParse(input, out selectedOption) || !Enum.IsDefined(typeof(MenuOptions), selectedOption)) {
                Console.WriteLine($"Invalid choice. Please enter a number between 1 and {Enum.GetValues(typeof(MenuOptions)).Length}.");
                input = Console.ReadLine();
            }

            return selectedOption;
        }
    }
}
