using System.Diagnostics;

namespace MathGame.mekasu0124;

public class GameEngine
{
    public void StartAddGame(string username, DateTime date, int totalQuestions, string difficulty)
    {
        int score = 0;
        Stopwatch timer = new Stopwatch();

        timer.Start();
        for (int i = 0; i < totalQuestions; i++)
        {
            if (i == 0)
            {
                timer.Start();
            }
            int[] numbers = GetNumber(difficulty);
            
            int number1 = numbers[0];
            int number2 = numbers[1];
            int solution = number1 + number2;

            string question = $"{number1} + {number2} = ";
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(question);
            string guess = Console.ReadLine();
            int input = Helpers.ValidateNumericInput(question, guess);

            if (input == solution)
            {
                score++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nYou Got It Right! Score: {score}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress Any Key For Next Question");
                Console.ReadLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOh No. You Got It Wrong. Next Question");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Correct Solution: {solution}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress Any Key For Next Question");
                Console.ReadLine();
            }

            Console.Clear();
        }

        timer.Stop();
        
        GameModel newGame = CreateGame(username, date, "Addition", score, totalQuestions, difficulty, timer.Elapsed.ToString(@"hh\:mm\:ss"));
        PreviousGames.SaveGame(newGame);

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Game Over! Press Any Key To Go To Main Menu");
        Console.ReadLine();
        
        GameMenu.ShowMenu(username, date);
    }

    public void StartSubGame(string username, DateTime date, int totalQuestions, string difficulty)
    {
        int score = 0;
        Stopwatch timer = new Stopwatch();

        timer.Start();
        for (int i = 0; i < totalQuestions; i++)
        {
            int[] numbers = GetNumber(difficulty);
            
            int number1 = numbers[0];
            int number2 = numbers[1];
            int solution;
            string question;
            
            if (number2 > number1)
            {
                solution = number2 - number1;
                question = $"{number2} - {number1} = ";
            }
            else
            {
                solution = number1 - number2;
                question = $"{number1} - {number2} = ";
            }
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(question);
            string guess = Console.ReadLine();
            int input = Helpers.ValidateNumericInput(question, guess);

            if (input == solution)
            {
                score++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nYou Got It Right! Score: {score}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress Any Key For Next Question");
                Console.ReadLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOh No. You Got It Wrong. Next Question");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Correct Solution: {solution}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress Any Key For Next Question");
                Console.ReadLine();
            }

            Console.Clear();
        }

        timer.Stop();
        
        GameModel newGame = CreateGame(username, date, "Subtraction", score, totalQuestions, difficulty, timer.Elapsed.ToString(@"hh\:mm\:ss"));
        PreviousGames.SaveGame(newGame);

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Game Over! Press Any Key To Go To Main Menu");
        Console.ReadLine();
        
        GameMenu.ShowMenu(username, date);
    }

    public void StartMultGame(string username, DateTime date, int totalQuestions, string difficulty)
    {
        int score = 0;
        Stopwatch timer = new Stopwatch();
        
        timer.Start();
        for (int i = 0; i < totalQuestions; i++)
        {
            int[] numbers = GetNumber(difficulty);
            
            int number1 = numbers[0];
            int number2 = numbers[1];
            int solution = number1 * number2;
            string question = $"{number2} * {number1} = ";
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(question);
            string guess = Console.ReadLine();
            int input = Helpers.ValidateNumericInput(question, guess);

            if (input == solution)
            {
                score++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nYou Got It Right! Score: {score}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress Any Key For Next Question");
                Console.ReadLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOh No. You Got It Wrong. Next Question");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Correct Solution: {solution}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress Any Key For Next Question");
                Console.ReadLine();
            }

            Console.Clear();
        }

        timer.Stop();
        
        GameModel newGame = CreateGame(username, date, "Multiplication", score, totalQuestions, difficulty, timer.Elapsed.ToString(@"hh\:mm\:ss"));
        PreviousGames.SaveGame(newGame);

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Game Over! Press Any Key To Go To Main Menu");
        Console.ReadLine();
        
        GameMenu.ShowMenu(username, date);
    }

    public void StartDivGame(string username, DateTime date, int totalQuestions, string difficulty)
    {
        int score = 0;
        Stopwatch timer = new Stopwatch();

        timer.Start();
        for (int i = 0; i < totalQuestions; i++)
        {
            int[] numbers = GetNumber(difficulty);
            
            int number1 = numbers[0];
            int number2 = numbers[1];

            while (number1 % number2 != 0)
            {
                numbers = GetNumber(difficulty);

                number1 = numbers[0];
                number2 = numbers[1];
            }

            int solution = number1 / number2;
            string question = $"{number1} / {number2} = ";
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(question);
            string guess = Console.ReadLine();
            int input = Helpers.ValidateNumericInput(question, guess);

            if (input == solution)
            {
                score++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nYou Got It Right! Score: {score}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress Any Key For Next Question");
                Console.ReadLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOh No. You Got It Wrong. Next Question");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Correct Solution: {solution}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress Any Key For Next Question");
                Console.ReadLine();
            }

            Console.Clear();
        }

        timer.Stop();
        
        GameModel newGame = CreateGame(username, date, "Multiplication", score, totalQuestions, difficulty, timer.Elapsed.ToString(@"hh\:mm\:ss"));
        PreviousGames.SaveGame(newGame);

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Game Over! Press Any Key To Go To Main Menu");
        Console.ReadLine();
        
        GameMenu.ShowMenu(username, date);
    }

    private static GameModel CreateGame(string username, DateTime date, string gameType, int score, int total, string difficulty, string timer)
    {
        GameModel newGame = new()
        {
            Username = username,
            Date = date,
            Score = score,
            Total = total,
            Difficulty = difficulty,
            GameType = gameType,
            TotalTime = timer
        };

        return newGame;
    }

    private static int[] GetNumber(string difficulty)
    {
        Random rng = new();
        int firstNumber = 0;
        int secondNumber = 0;
        var result = new int[2];
        
        if (difficulty == "Easy")
        {
            firstNumber = rng.Next(0, 99);
            secondNumber = rng.Next(0, 99);
        }
        else if (difficulty == "Medium")
        {
            firstNumber = rng.Next(100, 199);
            secondNumber = rng.Next(100,199);
        }
        else if (difficulty == "Hard")
        {
            firstNumber = rng.Next(200,299);
            secondNumber = rng.Next(200,299);
        }

        result[0] = firstNumber;
        result[1] = secondNumber;

        return result;
    }
}