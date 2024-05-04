namespace IbraheemKarim.MathGame
{
    internal class Menu
    {
        private GameEngine _gameEngine;

        public Menu(GameEngine gameEngine)
        {
            this._gameEngine = gameEngine;
        }
        public void StartMenu(string name)
        {
            this.ShowGreetings(name);

            while (true)
            {
                ActionType action = this.GetDesiredAction();
                this.ProcessActionType(action);
            }
        }
        private void ShowGreetings(string name)
        {
            var dateAndTime = DateTime.Now;
            Console.Clear();
            Console.WriteLine($"Hello {name}. It's {dateAndTime}. This is your math's game.\nIt's great that you're working on improving yourself\n");
            Console.WriteLine("You can press any key to continue");
            Console.ReadKey();
        }
        private ActionType GetDesiredAction()
        {
            bool firstIteration = true;
            do
            {
                Console.Clear();

                if (!firstIteration)
                    Console.WriteLine("Invalid input!! \n");

                Console.WriteLine(@$"
Choose one of the options below:
1 - Start playing the game
2 - View previous games history
3 - Quit the Game");
                Console.WriteLine("---------------------------------------------");

                if (int.TryParse(Console.ReadLine(), out int selection))
                {
                    if (selection < 4 && selection > 0)
                        return (ActionType)selection;
                }

                firstIteration = false;
            } while (true);

        }
        private void ProcessActionType(ActionType action)
        {
                switch (action)
                {
                    case ActionType.PlayTheGame:
                        _gameEngine.StartGame();
                        break;
                    case ActionType.ViewPreviousGames:
                        GamesHistory.PrintHistory();
                        break;
                    case ActionType.QuitTheProgram:
                        Console.Clear();
                        Console.WriteLine("\nGoodbye!");
                        Environment.Exit(0);
                        break;
                }
        }
    }
}
