using MathGame.models;
using System.Linq;

namespace MathGame
{
    internal class Helpers
    {
        internal static List<Game> games = new List<Game>
{
    new Game { Date = DateTime.Now.AddDays(1), Type = GameType.Addition, Score = 5, Time = TimeSpan.FromSeconds(12) },
    new Game { Date = DateTime.Now.AddDays(2), Type = GameType.Multiplication, Score = 4, Time = TimeSpan.FromSeconds(9) },
    new Game { Date = DateTime.Now.AddDays(3), Type = GameType.Division, Score = 4, Time = TimeSpan.FromSeconds(11) },
    new Game { Date = DateTime.Now.AddDays(4), Type = GameType.Subtraction, Score = 3, Time = TimeSpan.FromSeconds(10) },
    new Game { Date = DateTime.Now.AddDays(5), Type = GameType.Addition, Score = 1, Time = TimeSpan.FromSeconds(8) },
    new Game { Date = DateTime.Now.AddDays(6), Type = GameType.Multiplication, Score = 2, Time = TimeSpan.FromSeconds(11) },
    new Game { Date = DateTime.Now.AddDays(7), Type = GameType.Division, Score = 3, Time = TimeSpan.FromSeconds(9) },
    new Game { Date = DateTime.Now.AddDays(8), Type = GameType.Subtraction, Score = 4, Time = TimeSpan.FromSeconds(10) },
    new Game { Date = DateTime.Now.AddDays(9), Type = GameType.Addition, Score = 4, Time = TimeSpan.FromSeconds(13) },
    new Game { Date = DateTime.Now.AddDays(10), Type = GameType.Multiplication, Score = 1, Time = TimeSpan.FromSeconds(7) },
    new Game { Date = DateTime.Now.AddDays(11), Type = GameType.Subtraction, Score = 0, Time = TimeSpan.FromSeconds(9) },
    new Game { Date = DateTime.Now.AddDays(12), Type = GameType.Division, Score = 2, Time = TimeSpan.FromSeconds(12) },
    new Game { Date = DateTime.Now.AddDays(13), Type = GameType.Subtraction, Score = 5, Time = TimeSpan.FromSeconds(10) },
};


        internal static void PrintGames()
        {
            List<Game> gamesToPrint = new();
            gamesToPrint = games;

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("-------------------------");
            foreach (var game in gamesToPrint)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts - {game.Time}seconds");
            }
            Console.WriteLine("-------------------------\n");

            
            bool isSortingOrFilering = true;

            while (isSortingOrFilering)
            {
                Console.WriteLine("would you like to filter(F) or sort(S) games or return to menu?(M)");
                string input = Console.ReadLine().ToUpper();

                if (input == "F")
                {
                    gamesToPrint = FilterGames(gamesToPrint);
                    Console.Clear();

                    foreach (var game in gamesToPrint)
                    {
                        Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts - {game.Time}seconds");
                    }
                }
                else if (input == "S")
                {
                    gamesToPrint = SortGames(gamesToPrint);
                    Console.Clear();

                    foreach (var game in gamesToPrint)
                    {
                        Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts - {game.Time}seconds");
                    }
                }
                else if (input == "M")
                {
                    isSortingOrFilering = false;
                }
                else
                {
                    Console.WriteLine("please provide a valid input.");
                }
            }
            Console.Clear();

        }

        internal static void AddToHistory(int gameScore, GameType gameType, TimeSpan Time)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                Time = Time
            }) ;
        }

        internal static int[] GetDivisionNumbers(int difficulty)
        {
            int num1;
            int num2;
            var random = new Random();

            switch (difficulty)
            {
                case 1:
                    num1 = random.Next(1, 20);
                    num2 = random.Next(1, 20);
                    break;
                case 2:
                    num1 = random.Next(1, 50);
                    num2 = random.Next(1, 50);
                    break;
                case 3:
                    num1 = random.Next(10, 100);
                    num2 = random.Next(10, 100);
                    break;
                case 4:
                    num1 = random.Next(1, 1000);
                    num2 = random.Next(1, 1000);
                    break;
                default:
                    num1 = random.Next(1, 20);
                    num2 = random.Next(1, 20);
                    break;
            }
                int[] result = new int[2];

            while (num1 % num2 != 0)
            {
                switch (difficulty)
                {
                    case 1:
                        num1 = random.Next(1, 20);
                        num2 = random.Next(1, 20);
                        break;
                    case 2:
                        num1 = random.Next(1, 50);
                        num2 = random.Next(1, 50);
                        break;
                    case 3:
                        num1 = random.Next(10, 100);
                        num2 = random.Next(10, 100);
                        break;
                    case 4:
                        num1 = random.Next(1, 1000);
                        num2 = random.Next(1, 1000);
                        break;
                    default:
                        num1 = random.Next(1, 20);
                        num2 = random.Next(1, 20);
                        break;
                }
            }

            result[0] = num1;
            result[1] = num2;

            return result;
        }
        
        static List<Game> FilterGames(List<Game> gamesToPrint)
        {
            List<Game> alteredGamesList = new List<Game>();
            Console.WriteLine("Enter Filter: \nB - Back \nBD - Before Date \nAD - After Date \nSGT - Score Greater Than \nSLT - Score Less Than");
            string filter = Console.ReadLine().ToUpper();
            bool isSelectingFilter = true;
            while (isSelectingFilter == true)
            {
                switch (filter)
                {
                    case "B":
                        isSelectingFilter = false;
                        break;
                    case "BD":
                        Console.WriteLine("enter Date (YYYY-MM-DD): ");
                        DateTime BeforeDateFilter = DateTime.Parse(Console.ReadLine());
                        alteredGamesList = new List<Game>(gamesToPrint.Where(x => x.Date < BeforeDateFilter));
                        isSelectingFilter = false;
                        break;
                    case "AD":
                        Console.WriteLine("enter Date (YYYY-MM-DD): ");
                        DateTime AfterDateFilter = DateTime.Parse(Console.ReadLine());
                        alteredGamesList = new List<Game>(gamesToPrint.Where(x => x.Date > AfterDateFilter));
                        isSelectingFilter = false;
                        break;
                    case "SGT":
                        Console.WriteLine("enter score:");
                        int ScoreGreaterThanFilter = Convert.ToInt32((Console.ReadLine()));
                        alteredGamesList = new List<Game>(gamesToPrint.Where(x => x.Score > ScoreGreaterThanFilter));
                        isSelectingFilter = false;
                        break;
                    case "SLT":
                        Console.WriteLine("enter score: ");
                        int scoreLessThanFilter = Convert.ToInt32((Console.ReadLine()));
                        alteredGamesList = new List<Game>(gamesToPrint.Where(x => x.Score < scoreLessThanFilter));
                        isSelectingFilter = false;
                        break;
                    default:
                        Console.WriteLine("Please input a valid option.");
                        break;
                }
            


            }
            return alteredGamesList;
        }

        static List<Game> SortGames(List<Game> gamesToPrint)
        {
            Console.WriteLine("\nB - Back \nDA - Date ascending \nDD - Date Descending \nSA - Score Ascending \nSD - Score Descending");
            string filterType = Console.ReadLine().ToUpper();

            switch (filterType)
            {
                case "B":
                    Console.WriteLine("returning to menu...");
                    break;
                case "DA":
                    Console.WriteLine("sorting list...");
                    gamesToPrint = gamesToPrint.OrderBy(x => x.Date).ToList();
                    break;
                case "DD":
                    Console.WriteLine("sorting list...");
                    gamesToPrint = gamesToPrint.OrderByDescending(x => x.Date).ToList();
                    break;
                case "SA":
                    Console.WriteLine("sorting list...");
                    gamesToPrint = gamesToPrint.OrderBy(x => x.Score).ToList();
                    break;
                case "SD":
                    Console.WriteLine("sorting list...");
                    gamesToPrint = gamesToPrint.OrderByDescending(x => x.Score).ToList();
                    break;
            }
            return gamesToPrint;
        }

        internal static int ExceptionHandledInt32Parse(string answer)
        {
            while (string.IsNullOrEmpty(answer) || !Int32.TryParse(answer, out _))
            {
                Console.WriteLine("Invalid input. please only input integers.");
                answer = Console.ReadLine();
            }

            int result = Convert.ToInt32(answer);

            return result;
        }

    }
}
