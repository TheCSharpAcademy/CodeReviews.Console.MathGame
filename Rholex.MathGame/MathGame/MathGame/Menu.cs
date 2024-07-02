using MathGame.Model;

namespace MathGame
{
    internal class Menu
    {
        GameEngine gameEngine = new GameEngine();
        GameDifficulty difficulty = new GameDifficulty();

        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();

            bool isGameOn = true;
            
            int rounds;

            do
            {
                Console.Clear();
                Console.WriteLine($"Hello {name.ToUpper()}! Welcome to the Math Game. It is {date.ToString("dd MMM yyyy hh:mm tt PHT")}.");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine($@"
What game would you like to play today? Choose from the options below:
A - Addition
S - Subtraction
M - Multiplication
D - Divison
Q - Quit Game
R - Show History
");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.Write("Select Game: ");
                string gameSelected = Console.ReadLine().ToLower().Trim();
                
                switch(gameSelected)
                {
                    case "a":
                        difficulty = GetDifficulty();
                        rounds = GetRounds();
                        gameEngine.AdditionGame("Addition Game", difficulty, rounds);
                        break;
                    case "s":
                        difficulty = GetDifficulty();
                        rounds = GetRounds();
                        gameEngine.SubtractionGame("Subtraction Game", difficulty, rounds);
                        break;
                    case "m":
                        difficulty = GetDifficulty();
                        rounds = GetRounds();
                        gameEngine.MultiplicationGame("Multiplication Game", difficulty, rounds);
                        break;
                    case "d":
                        difficulty = GetDifficulty();
                        rounds = GetRounds();
                        gameEngine.DivisionGame("Division Game", difficulty, rounds);
                        break;
                    case "r":
                        Helpers.PrintRecords();
                        break;
                    case "q":
                        QuitGame();
                        isGameOn = false;
                        break;
                }
            }
            while (isGameOn);
        }
        private void QuitGame()
        {
            Console.Clear();
            Console.WriteLine("Thank you for playing! Good bye!");
            Environment.Exit(0);
        }
        internal GameDifficulty GetDifficulty()
        {
            Console.Clear();
            GameDifficulty result = new GameDifficulty();

            bool isRoundsOn = true;
            do
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine($@"Please select a difficulty level:
1. Easy 
2. Medium
3. Hard");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.Write("Select Difficulty: ");
                
                string difficultyInput = Console.ReadLine().ToLower().Trim();
                isRoundsOn = true;

                switch (difficultyInput)
                {
                    case "1":
                        result = GameDifficulty.Easy;
                        isRoundsOn = false;
                        break;
                    case "2":
                        result = GameDifficulty.Medium;
                        isRoundsOn = false;
                        break;
                    case "3":
                        result = GameDifficulty.Hard;
                        isRoundsOn = false;
                        break;
                }

            }
            while (isRoundsOn);
            return result;
        }

        internal int GetRounds()
        {
            Console.Clear();

            int roundsInput;
            Console.WriteLine("How many rounds would you like to play?");
            Console.Write("Input Rounds: ");
            string rounds = Console.ReadLine();

            while (string.IsNullOrEmpty(rounds) || !Int32.TryParse(rounds, out roundsInput))
            {
                Console.WriteLine("Please input a valid number.");
                Console.Clear();
                Console.WriteLine("How many rounds would you like to play?");
                rounds = Console.ReadLine();
            }
            return roundsInput;
        }
    }
}
