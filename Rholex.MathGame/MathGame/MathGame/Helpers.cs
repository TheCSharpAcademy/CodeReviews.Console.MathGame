using MathGame.Model;

namespace MathGame
{
    internal class Helpers
    {

        internal static List<Records> records = new List<Records>();

        internal static string GetName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty.");
                Console.WriteLine("Please enter your name: ");
                name = Console.ReadLine();
            }
            return name;
        }

        internal static string ValidateResult(string result)
        {

            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer must be an integer. Try again.");
                result = Console.ReadLine();
            }
            return result;
        }

        internal static void AddToRecords(int gameScore, GameType gameType, int rounds, GameDifficulty difficulty)
        {
            records.Add(new Records
            {
                Date = DateTime.Now,
                Difficulty = difficulty,
                Score = gameScore,
                Type = gameType,
                Rounds = rounds,
            });
        }

        internal static void PrintRecords()
        {
            //var gamesToPrint = records.Where(x => x.Date > new DateTime(2022, 08, 09)).OrderByDescending(x => x.Score);
            Console.Clear();
            Console.WriteLine("Game Records:");
            Console.WriteLine("--------------------");
            foreach (var games in records)
            {
                Console.WriteLine($"{games.Date} - {games.Type} - {games.Difficulty}: {games.Score}pts/{games.Rounds}pts");
            }
            Console.ReadKey();
        }

        
        internal static int[] GetNumbers(GameType gameType, GameDifficulty difficulty)
        {
            Random random = new Random();
            var numbers = new int[2];

            switch(gameType)
            {
                case GameType.Addition:
                    if (difficulty == GameDifficulty.Easy)
                    {
                        numbers[0] = random.Next(1, 9);
                        numbers[1] = random.Next(1, 9);
                    }

                    else if (difficulty == GameDifficulty.Medium)
                    {
                        numbers[0] = random.Next(1, 99);
                        numbers[1] = random.Next(1, 99);
                    }

                    else
                    {
                        numbers[0] = random.Next(1, 500);
                        numbers[1] = random.Next(1, 500);
                    }
                    break;

                case GameType.Subtraction:
                    if (difficulty == GameDifficulty.Easy)
                    {
                        numbers[0] = random.Next(1, 9);
                        numbers[1] = random.Next(1, 9);
                    }

                    else if (difficulty == GameDifficulty.Medium)
                    {
                        numbers[0] = random.Next(1, 99);
                        numbers[1] = random.Next(1, 99);
                    }

                    else
                    {
                        numbers[0] = random.Next(1, 500);
                        numbers[1] = random.Next(1, 500);
                    }
                    break;

                case GameType.Multiplication:
                    if (difficulty == GameDifficulty.Easy)
                    {
                        numbers[0] = random.Next(1, 9);
                        numbers[1] = random.Next(1, 9);
                    }

                    else if (difficulty == GameDifficulty.Medium)
                    {
                        numbers[0] = random.Next(1, 99);
                        numbers[1] = random.Next(1, 99);
                    }

                    else
                    {
                        numbers[0] = random.Next(1, 500);
                        numbers[1] = random.Next(1, 500);
                    }
                    break;

                case GameType.Division:

                    
                    if (difficulty == GameDifficulty.Easy)
                    {
                        do
                        {
                            numbers[0] = random.Next(1, 9);
                            numbers[1] = random.Next(1, 9);
                        }
                        while (numbers[0] % numbers[1] != 0);
                        
                    }

                    else if (difficulty == GameDifficulty.Medium)
                    {
                        do
                        {
                            numbers[0] = random.Next(1, 90);
                            numbers[1] = random.Next(1, 90);
                        }
                        while (numbers[0] % numbers[1] != 0);
                    }

                    else
                    {
                        do
                        {
                            numbers[0] = random.Next(1, 500);
                            numbers[1] = random.Next(1, 500);
                        }
                        while (numbers[0] % numbers[1] != 0);
                    }
                    break; 
            }
            return numbers;

        }
    }
}
            
        
