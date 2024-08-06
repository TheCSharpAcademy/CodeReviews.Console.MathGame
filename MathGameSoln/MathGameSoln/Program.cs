using System.Diagnostics;

namespace MathGameSoln;

class Program
{
    private static readonly Random Random = new();
    private static List<string> ScoreSheet = new();
    

    static void Main(string[] args)
    {
        var rounds = 5;
        char entry;
        do
        {
            Console.Clear();
            Console.WriteLine("What Game would you like to play from the selection below:");
            Console.WriteLine("V - View Previous Games");
            Console.WriteLine("A - Addition");
            Console.WriteLine("S - Subtraction");
            Console.WriteLine("M - Multiplication");
            Console.WriteLine("D - Division");
            Console.WriteLine("R - Set number of rounds per game");
            Console.WriteLine("Q - Quit the program");

            entry = Console.ReadKey().KeyChar;
            switch (entry)
            {
                case 'v':
                    Console.WriteLine("\nView previous games chosen");

                    for (int i = 0; i < ScoreSheet.Count; i++)
                    {
                        Console.WriteLine($"Final Score game {i + 1}: {ScoreSheet[i]}");
                    }

                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                    break;
                case 'a':
                case 's':
                case 'm':
                case 'd':
                    Console.Clear();
                    PlayMathGame(rounds, entry);
                    break;
                case 'r':
                    Console.Clear();
                    Console.WriteLine("Enter the number of rounds:");
                    rounds = ValidRoundsEntry();
                    break;
                case 'q':
                case 'e':
                    Console.WriteLine("\nQuit the program");
                    break;
                default:
                    Console.WriteLine("\nInvalid Selection, please select again");
                    entry = Console.ReadKey().KeyChar;
                    break;
            }
        } while (entry != 'q');
    }

    private static void PlayMathGame(int rounds, char gameType)
    {
        Stopwatch stopwatch = new();
        int gameRounds = rounds;
        var gameName = gameType switch
        {
            'a' => "\n Addition Game",
            's' => "\n Subtraction Game",
            'm' => "\n Multiplication Game",
            'd' => "\n Division Game",
            _ => throw new Exception()
        };

        Console.WriteLine(gameName);
        int correctGames = 0;
        while (gameRounds > 0)
        {
            stopwatch.Start();
            (int x, int y) = GenereateXandY(gameType);
            int solution = GameSolution(gameType, x, y);
            int userSolution = ValidateUserAnswer();
            bool isCorrect = userSolution == solution;
            DisplayResults(isCorrect, solution);

            if (isCorrect)
            {
                correctGames++;
            }

            gameRounds--;
        }
        
        stopwatch.Stop();

        string finalScore = $"{correctGames}/{rounds}";
        ScoreSheet.Add(finalScore);

        Console.WriteLine($"Final Score {finalScore}, time to complete game {stopwatch.Elapsed.Minutes} minutes and {stopwatch.Elapsed.Seconds} seconds. Press Enter to continue");
        Console.ReadLine();
    }

    private static (int x, int y) GenereateXandY(char gameType) =>
        gameType switch
        {
            'a' => (Random.Next(101), Random.Next(101)),
            's' => GenereateXandYSubtaction(),
            'm' => (Random.Next(50 + 1), Random.Next(50 + 1)),
            'd' => GenereateXandYDivision(),
            _ => throw new Exception()
        };

    private static (int x, int y) GenereateXandYDivision()
    {
        var x = Random.Next(1, 101);
        var y = Random.Next(1, 101);
        while (x % y != 0 && y % x != 0)
        {
            x = Random.Next(101);
            y = Random.Next(101);
        }

        if (x % y == 0)
        {
            return (x, y);
        }
        else
        {
            return (y, x);
        }
    }

    private static (int x, int y) GenereateXandYSubtaction()
    {
        var x = Random.Next(101);
        var y = Random.Next(101);
        if (x > y)
        {
            return (x, y);
        }
        else
        {
            return (y, x);
        }
    }

    private static int GameSolution(char gameType, int x, int y) =>
        gameType switch
        {
            'a' => AdditionSolution(x, y),
            's' => SubtractionSolution(x, y),
            'm' => MultiplicationSolution(x, y),
            'd' => DivisionSolution(x, y),
            _ => throw new Exception()
        };

    static void DisplayResults(bool isCorrect, int solution)
    {
        if (isCorrect)
        {
            Console.WriteLine("That is correct. Press any key to continue");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine($"That is incorrect. The solution is {solution}. Press any key to continue");
            Console.ReadLine();
        }
    }

    static int AdditionSolution(int a, int b)
    {
        Console.WriteLine($"{a} + {b}");
        return a + b;
    }

    static int SubtractionSolution(int a, int b)
    {
        Console.WriteLine($"{a} - {b}");
        return a - b;
    }

    static int MultiplicationSolution(int a, int b)
    {
        Console.WriteLine($"{a} X {b}");
        return a * b;
    }

    static int DivisionSolution(int a, int b)
    {
        Console.WriteLine($"{a} / {b}");
        return a / b;
    }

    static int ValidateUserAnswer()
    {
        bool validEntry = false;

        var userSolution = Console.ReadLine();
        do
        {
            if (userSolution is null)
            {
                Console.WriteLine("Your input is invalid, please try again.");
                userSolution = Console.ReadLine();
                continue;
            }

            if (userSolution.ToLower() == "e")
            {
                Console.WriteLine("Exiting Game");
                return 0;
            }

            validEntry = int.TryParse(userSolution, out var numericValue);
            if (!validEntry)
            {
                Console.WriteLine("Your input is invalid, please try again.");
                userSolution = Console.ReadLine();
            }
            else
            {
                return numericValue;
            }
        } while (!validEntry);

        return 0;
    }

    static int ValidRoundsEntry()
    {
        bool validEntry = false;

        var userRounds = Console.ReadLine();
        do
        {
            if (userRounds is null)
            {
                Console.WriteLine("Your input is invalid, please try again.");
                userRounds = Console.ReadLine();
                continue;
            }

            validEntry = int.TryParse(userRounds, out var numericValue);
            if (!validEntry)
            {
                Console.WriteLine("Your input is invalid, please try again.");
                userRounds = Console.ReadLine();
            }
            else
            {
                return numericValue;
            }
        } while (!validEntry);

        return 0;
    }
}