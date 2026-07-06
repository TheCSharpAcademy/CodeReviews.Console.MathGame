using System.Diagnostics;
using Spectre.Console;

namespace MathGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<GameHistory> history = new List<GameHistory>();
            while (true)
            {
                var choice = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("* * MENU * * ").AddChoices("Quiz me ..", "Previous Scores", "Exit"));
                int points = 0;
                switch (choice)
                {

                    case "Quiz me ..":
                        var timer = new Stopwatch();
                        timer.Start();
                        var op  = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Choose an operation:").AddChoices("+", "-", "*", "/"));
                        points = MathOperation(op);
                        timer.Stop();

                        history.Add(new GameHistory
                        {
                            Date = DateTime.Now,
                            GameType = op,
                            Score = points,
                            TimeTaken = timer.Elapsed
                        });

                        break;
                    case "Previous Scores":
                        if (history.Count == 0)
                        {
                            Console.WriteLine("No games played yet.");
                        }
                        else
                        {
                            Console.WriteLine("\nGame History\n");

                            foreach (var game in history)
                            {
                                Console.WriteLine(
                                    $"Date : {game.Date:dd-MM-yyyy HH:mm:ss}\n" +
                                    $"Game : {game.GameType}\n" +
                                    $"Score: {game.Score}\n" +
                                    $"Time : {game.TimeTaken.TotalSeconds:F2} seconds\n");
                            }
                        }
                        break;
                    case "Exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }


            }
        }

        static int MathOperation(string op)
        {
            Random random = new Random();
            int points = 0;
            int count = 0;
            while (count < 5)
            {
                int a = random.Next(1, 100);
                int b = random.Next(1, 100);
                int  answer = 0;
                switch (op)
                {

                    case "+":

                        Console.WriteLine($"What is {a} + {b} ");
                        if (!int.TryParse(Console.ReadLine(), out answer))
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        else if (answer == a + b)
                        {
                            Console.WriteLine("Correct!");
                            points += 10;
                        }
                        else
                        {
                            Console.WriteLine($"Wrong! The correct answer is {a + b}");
                        }
                        break;
                    case "-":
                        Console.WriteLine($"What is {a} - {b}");
                        if (!int.TryParse(Console.ReadLine(), out answer))
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        else if (answer == a - b)
                        {
                            Console.WriteLine("Correct!");
                            points += 10;
                        }
                        else
                        {
                            Console.WriteLine($"Wrong! The correct answer is {a + b}");
                        }
                        break;
                    case "*":
                        Console.WriteLine($"What is {a} * {b}");
                        if (!int.TryParse(Console.ReadLine(), out answer))
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        else if (answer == a * b)
                        {
                            Console.WriteLine("Correct!");
                            points += 10;
                        }
                        else
                        {
                            Console.WriteLine($"Wrong! The correct answer is {a + b}");
                        }
                        break;
                    case "/":
                        b = random.Next(1, 11); 
                        a = b * random.Next(1, 11);
                        a = a * b;
                        Console.WriteLine($"What is {a} / {b}");
                        if (!int.TryParse(Console.ReadLine(), out answer))
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        else if (answer == a / b)
                        {
                            Console.WriteLine("Correct!");
                            points += 10;
                        }
                        else
                        {
                            Console.WriteLine($"Wrong! The correct answer is {a + b}");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid operation");
                        break;
                }
                count++;
            }

            return points;

        }

        class GameHistory
        {
            public DateTime Date { get; set; }
            public string GameType { get; set; }
            public int Score { get; set; }
            public TimeSpan TimeTaken { get; set; }
        }

    }
}
