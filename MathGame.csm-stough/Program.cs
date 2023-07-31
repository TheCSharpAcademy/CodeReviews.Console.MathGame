namespace MathGame
{
    class Driver
    {
        static void Main(string[] args)
        {
            Menu gameMenu = new Menu("Choose a math game");
            GameHistory.Init();

            gameMenu.AddOption("A", "Addition game", () => { new AdditionGame().RunGame(); });
            gameMenu.AddOption("S", "Subtraction game", () => { new SubtractionGame().RunGame(); });
            gameMenu.AddOption("M", "Multiplication game", () => { new MultiplicationGame().RunGame(); });
            gameMenu.AddOption("D", "Division game", () => { new DivisionGame().RunGame(); });
            gameMenu.AddOption("R", "Random game", () => { new RandomGame().RunGame(); });
            gameMenu.AddOption("H", "View games history", () => { Console.Clear(); GameHistory.ShowHistory(); });
            gameMenu.AddOption("O", "Change game options", () => { GameSettings.ApplySettings(); });
            gameMenu.AddOption("Q", "Quit program", () => { Environment.Exit(0); });

            while(true)
            {

                Console.Clear();

                Console.WriteLine($"Current difficulty is {GameSettings.GetDifficulty().name}, and current game length is {GameSettings.GetRoundsLength()} round(s).");
                Console.WriteLine("-----------------------------------------------------------------\n");

                Console.WriteLine(gameMenu.GetMenuText());

                gameMenu.SelectOption(Console.ReadLine());
            }
        }
    }
}
