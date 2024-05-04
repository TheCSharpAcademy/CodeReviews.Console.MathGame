namespace IbraheemKarim.MathGame
{
    internal class GameEngine
    {
        public void StartGame()
        {
            GameType gameType = GetDesiredGameType();
            ProcessGameTypeChoice(gameType);
        }
        private GameType GetDesiredGameType()
        {
            bool firstIteration = true;
            do
            {
                Console.Clear();

                if (!firstIteration)
                    Console.WriteLine("Invalid input!! \n");

                Console.WriteLine(@$"
Choose what kind of game would you like to play:
1 - Addition 
2 - Subtraction
3 - Multiplication
4 - Division");
                Console.WriteLine("---------------------------------------------");

                if (int.TryParse(Console.ReadLine(), out int selection))
                {
                    if (selection < 5 && selection > 0)
                        return (GameType)selection;
                }

                firstIteration = false;
            } while (true);

        }
        private void ProcessGameTypeChoice(GameType gameType)
        {
            switch (gameType)
            {
                case GameType.Addition:
                    this.CustomMathGame("Addition game", '+', (first, second) => first + second, GameType.Addition);
                    break;
                case GameType.Subtraction:
                    this.CustomMathGame("Subtraction game", '-', (first, second) => first - second, GameType.Subtraction);
                    break;
                case GameType.Multiplication:
                    this.CustomMathGame("Multiplication game", '*', (first, second) => first * second, GameType.Multiplication);
                    break;
                case GameType.Division:
                    this.DivisionGame("Division game");
                    break;
            }

        }
        private void CustomMathGame(string gameTitle, char operationSymbol, Func<int, int, int> operationFunction, GameType gameType)
        {
            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(gameTitle);

                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} {operationSymbol} {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == operationFunction(firstNumber, secondNumber))
                {
                    Console.WriteLine("Your answer was correct! Press any key to continue");
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press any key to continue");
                }

                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine($"Game over. Your final score is {score}/5. Press any key to go back to the main menu.");
            Console.ReadKey();

            GamesHistory.AddToHistory(score, gameType);
        }
        private void DivisionGame(string message)
        {
            var score = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);

                var divisionNumbers = Helpers.GetDivisionNumbers();
                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");

                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Press any key to continue");
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Press any key to continue");
                }

                Console.ReadKey();
            }


            Console.Clear();
            Console.WriteLine($"Game over. Your final score is {score}/5. Press any key to go back to the main menu.");
            Console.ReadKey();

            GamesHistory.AddToHistory(score, GameType.Division);
        }
    }
}
