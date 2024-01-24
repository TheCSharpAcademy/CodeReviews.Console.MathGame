using ShihabudheenSha.MathGame.Model;

namespace ShihabudheenSha.MathGame
{
    internal class GameEngine
    {
        List<GameScore> gameScores = new List<GameScore>();

        internal void AdditionGame()
        {
            int score = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine("Addition Game");
                Console.WriteLine("-----------------------");
                int firstNumber = new Random().Next(1, 9);
                int secondNumber = new Random().Next(1, 9);
                Console.WriteLine($" {firstNumber} + {secondNumber} = ");
                Console.SetCursorPosition(10, 2);
                string usrAnswer = Console.ReadLine();
                usrAnswer = Helpers.ValidateGameUserAnswer(usrAnswer);
                if (int.Parse(usrAnswer) == (firstNumber + secondNumber))
                {
                    Console.WriteLine($"Your answer is correct! Press any key to continue");
                    Console.ReadLine();
                    score++;
                }
                else
                {

                    Console.WriteLine("Your answer is incorrect. Press any key to continue");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Your score is {score}. Press any key to go back main menu");
                    AddGameScore(score, GameType.Addition);
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        internal void SubtractionGame()
        {
            int score = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine("Subtraction Game");
                Console.WriteLine("-----------------------");
                int firstNumber = new Random().Next(1, 9);
                int secondNumber = new Random().Next(1, 9);
                Console.WriteLine($" {firstNumber} - {secondNumber} = ");
                Console.SetCursorPosition(10, 2);
                string usrAnswer = Console.ReadLine();
                usrAnswer = Helpers.ValidateGameUserAnswer(usrAnswer);
                if (int.Parse(usrAnswer) == (firstNumber - secondNumber))
                {
                    Console.WriteLine($"Your answer is correct! Press any key to continue");
                    Console.ReadLine();
                    score++;
                }
                else
                {

                    Console.WriteLine("Your answer is incorrect. Press any key to continue");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Your score is {score}. Press any key to continue");
                    AddGameScore(score, GameType.Subtraction);
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        internal void MultiplicationGame()
        {

            int score = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine("Multiplication Game");
                Console.WriteLine("-----------------------");
                int firstNumber = new Random().Next(1, 9);
                int secondNumber = new Random().Next(1, 9);
                Console.WriteLine($" {firstNumber} * {secondNumber} = ");
                Console.SetCursorPosition(10, 2);
                string usrAnswer = Console.ReadLine();
                usrAnswer = Helpers.ValidateGameUserAnswer(usrAnswer);
                if (int.Parse(usrAnswer) == (firstNumber * secondNumber))
                {
                    Console.WriteLine($"Your answer is correct! Press any key to continue");
                    Console.ReadLine();
                    score++;
                }
                else
                {

                    Console.WriteLine("Your answer is incorrect. Press any key to continue");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Your score is {score}. Press any key to continue");
                    AddGameScore(score, GameType.Multiplication);
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        internal void DivisionGame()
        {
            int score = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine("Division Game");
                Console.WriteLine("-----------------------");
                int[] divsionRandomNumbers = Helpers.GetRandomDivisionNumbers();
                int firstNumber = divsionRandomNumbers[0];
                int secondNumber = divsionRandomNumbers[1];
                Console.WriteLine($" {firstNumber} / {secondNumber} = ");
                Console.SetCursorPosition(10, 2);
                string usrAnswer = Console.ReadLine();
                usrAnswer = Helpers.ValidateGameUserAnswer(usrAnswer);
                if (int.Parse(usrAnswer) == (firstNumber / secondNumber))
                {
                    Console.WriteLine($"Your answer is correct! Press any key to continue");
                    Console.ReadLine();
                    score++;
                }
                else
                {

                    Console.WriteLine("Your answer is incorrect. Press any key to continue");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Your score is {score}. Press any key to continue");
                    AddGameScore(score, GameType.Divison);
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        internal void AddGameScore(int score, GameType gameType)
        {
            gameScores.Add(new GameScore()
            {
                Score = score,
                GameType = gameType,
            });
        }
        internal void showGameScore()
        {
            Console.Clear();
            Console.WriteLine("Your Score");
            Console.WriteLine("------------------------------");
            foreach (var gameScore in gameScores)
            {
                Console.WriteLine($"{gameScore.GameType} : {gameScore.Score}pts");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
    internal enum GameType
    {
        Addition,
        Subtraction,
        Divison,
        Multiplication
    }
}
