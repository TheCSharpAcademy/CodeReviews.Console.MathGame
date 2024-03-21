using System;
using System.Diagnostics;
using System.Dynamic;

namespace MathGame.Arashi256
{
    internal class GameEngine
    {
        int _score = 0;
        private int _difficulty = 2;
        private Stopwatch _stopWatch = new Stopwatch();
        private string? _elapsedTime = String.Empty;

        internal void AdditionGame(string message)
        {
            Console.WriteLine(message);
            _difficulty = GetDifficulty();
            int rounds = Helpers.GetNumberOfRounds(GameType.Addition);
            _stopWatch.Start();
            for (int i = 0; i < rounds; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                int[] numbers = GetGameRoundOfType(GameType.Addition, _difficulty);
                ProcessRound(GameType.Addition, numbers[0], numbers[1]);
                if (i == (rounds - 1))
                {
                    TimeSpan ts = _stopWatch.Elapsed;
                    // Format and display the TimeSpan value.
                    _elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine($"Game over. Your final score is {_score} and you took {_elapsedTime} time. Press any key to go to the main menu.");
                }
            }
            Helpers.AddToHistory(_score, GameType.Addition, _difficulty - 1, _elapsedTime);
            ResetGame();
        }

        internal void SubtractionGame(string message)
        {
            Console.WriteLine(message);
            _difficulty = GetDifficulty();
            int rounds = Helpers.GetNumberOfRounds(GameType.Subtraction);
            _stopWatch.Start();
            for (int i = 0; i < rounds; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                int[] numbers = GetGameRoundOfType(GameType.Subtraction, _difficulty);
                ProcessRound(GameType.Subtraction, numbers[0], numbers[1]);
                if (i == (rounds - 1))
                {
                    TimeSpan ts = _stopWatch.Elapsed;
                    // Format and display the TimeSpan value.
                    _elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine($"Game over. Your final score is {_score} and you took {_elapsedTime} time. Press any key to go to the main menu.");
                }
            }
            Helpers.AddToHistory(_score, GameType.Subtraction, _difficulty - 1, _elapsedTime);
            ResetGame();
        }

        internal void MultiplicationGame(string message)
        {
            Console.WriteLine(message);
            _difficulty = GetDifficulty();
            int rounds = Helpers.GetNumberOfRounds(GameType.Multiplication);
            _stopWatch.Start();
            for (int i = 0; i < rounds; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                int[] numbers = GetGameRoundOfType(GameType.Multiplication, _difficulty);
                ProcessRound(GameType.Multiplication, numbers[0], numbers[1]);
                if (i == (rounds - 1))
                {
                    TimeSpan ts = _stopWatch.Elapsed;
                    // Format and display the TimeSpan value.
                    _elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine($"Game over. Your final score is {_score} and you took {_elapsedTime} time. Press any key to go to the main menu.");
                }
            }
            Helpers.AddToHistory(_score, GameType.Multiplication, _difficulty - 1, _elapsedTime);
            ResetGame();
        }

        internal void DivisionGame(string message)
        {
            Console.WriteLine(message);
            _difficulty = GetDifficulty();
            int rounds = Helpers.GetNumberOfRounds(GameType.Division);
            _stopWatch.Start();
            for (int i = 0; i < rounds; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                int[] numbers = GetGameRoundOfType(GameType.Division, _difficulty);
                ProcessRound(GameType.Division, numbers[0], numbers[1]);
                if (i == 4)
                {
                    TimeSpan ts = _stopWatch.Elapsed;
                    // Format and display the TimeSpan value.
                    _elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine($"Game over. Your final score is {_score} and you took {_elapsedTime} time. Press any key to go to the main menu.");
                }
            }
            Helpers.AddToHistory(_score, GameType.Division, _difficulty - 1, _elapsedTime);
            ResetGame();
        }

        internal void RandomGame(string message)
        {
            int[] numbers = new int[2];
            string result;
            Console.WriteLine(message);
            _difficulty = GetDifficulty();
            int rounds = Helpers.GetNumberOfRounds(GameType.Random);
            _stopWatch.Start();
            for (int i = 0; i < rounds; i++)
            {
                int randomGameRound = new Random().Next(1, 5);
                Console.Clear();
                Console.WriteLine(message);
                switch ((GameType)randomGameRound) {
                    case GameType.Addition:
                        numbers = GetGameRoundOfType(GameType.Addition, _difficulty);
                        ProcessRound(GameType.Addition, numbers[0], numbers[1]);
                        break;
                    case GameType.Subtraction:
                        numbers = GetGameRoundOfType(GameType.Subtraction, _difficulty);
                        ProcessRound(GameType.Subtraction, numbers[0], numbers[1]);
                        break;
                    case GameType.Division:
                        numbers = GetGameRoundOfType(GameType.Division, _difficulty);
                        ProcessRound(GameType.Division, numbers[0], numbers[1]);
                        break;
                    case GameType.Multiplication:
                        numbers = GetGameRoundOfType(GameType.Multiplication, _difficulty);
                        ProcessRound(GameType.Multiplication, numbers[0], numbers[1]);
                        break;
                }
                if (i == (rounds - 1))
                {
                    TimeSpan ts = _stopWatch.Elapsed;
                    // Format and display the TimeSpan value.
                    _elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine($"Game over. Your final score is {_score} and you took {_elapsedTime} time. Press any key to go to the main menu.");
                }
            }
            Helpers.AddToHistory(_score, GameType.Random, _difficulty - 1, _elapsedTime);
            ResetGame();
        }

        internal int GetDifficulty()
        {
            string result = String.Empty;
            Console.WriteLine("What difficulty do you want to use? (1 - Easy, 2 - Medium, 3 - Hard)?");
            do
            {
                result = Helpers.ValidateResult(Console.ReadLine());
            } while (int.Parse(result) < 1 || int.Parse(result) > 3);
            return int.Parse(result); 
        }

        internal int[] GetGameRoundOfType(GameType gameType, int difficulty) 
        {
            int[] numbers = new int[2];
            var random = new Random();
            switch (gameType)
            {
                case GameType.Division:
                    var divisionNumbers = Helpers.GetDivisionNumbers(difficulty);
                    numbers[0] = divisionNumbers[0];
                    numbers[1] = divisionNumbers[1];
                    break;
                default:
                    numbers[0] = random.Next(1, 9) * difficulty;
                    numbers[1] = random.Next(1, 9) * difficulty;
                    break;
            }
            return numbers;
        }

        internal void ProcessRound(GameType gameType, int firstNumber, int secondNumber)
        {
            string result = string.Empty;
            bool isCorrectAnswer = false;
            switch (gameType)
            {
                case GameType.Addition:
                    Console.WriteLine($"{firstNumber} + {secondNumber}");
                    result = Helpers.ValidateResult(Console.ReadLine());
                    if (int.Parse(result) == (firstNumber + secondNumber))
                    {
                        isCorrectAnswer = true;
                    }
                    else
                    {
                        isCorrectAnswer = false;
                    }
                    break;
                case GameType.Subtraction:
                    Console.WriteLine($"{firstNumber} - {secondNumber}");
                    result = Helpers.ValidateResult(Console.ReadLine());
                    if (int.Parse(result) == (firstNumber - secondNumber))
                    {
                        isCorrectAnswer = true;
                    }
                    else
                    {
                        isCorrectAnswer = false;
                    }
                    break;
                case GameType.Division:
                    Console.WriteLine($"{firstNumber} / {secondNumber}");
                    result = Helpers.ValidateResult(Console.ReadLine());
                    if (int.Parse(result) == (firstNumber / secondNumber))
                    {
                        isCorrectAnswer = true;
                    }
                    else
                    {
                        isCorrectAnswer = false;
                    }
                    break;
                case GameType.Multiplication:
                    Console.WriteLine($"{firstNumber} * {secondNumber}");
                    result = Helpers.ValidateResult(Console.ReadLine());
                    if (int.Parse(result) == (firstNumber * secondNumber))
                    {
                        isCorrectAnswer = true;
                    }
                    else
                    {
                        isCorrectAnswer = false;
                    }
                    break;
            }
            if (isCorrectAnswer)
            {
                Console.WriteLine("Your answer was correct! Type any any to go to the next question.");
                _score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect. Type any any to go to the next question.");
                Console.ReadLine();
            }
        }

        internal void ResetGame()
        {
            _stopWatch.Reset();
            _score = 0;
            _elapsedTime = String.Empty;
        }
    }
}
