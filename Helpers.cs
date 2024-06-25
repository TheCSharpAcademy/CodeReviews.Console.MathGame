using MathGame.Models;

namespace MathGame
{
    internal class Helpers
    {
        internal static List<Game> games = new List<Game>();
        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games history");
            Console.WriteLine("--------------------------\n");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts Difficulty:{game.Difficulty} {game.GameTime}");
            }
                Console.WriteLine("--------------------------");
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadLine();
        }

        internal static int[] GetDivisionNumbers(int difficulty = 3)
        {
            var random = new Random();
            var firstNumber = 0;
            var secondNumber = 0;
            if (difficulty == 1)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 9);
                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = random.Next(1, 99);
                    secondNumber = random.Next(1, 9);
                }
            }
            else if (difficulty == 2)
            {
                firstNumber = random.Next(1, 999);
                secondNumber = random.Next(2, 99);
                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = random.Next(1, 999);
                    secondNumber = random.Next(2, 99);
                }
            }
            else //difficulty == 3
            {
                firstNumber = random.Next(1, 9999);
                secondNumber = random.Next(2, 999);
                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = random.Next(1, 9999);
                    secondNumber = random.Next(2, 999);
                }
            }
            var result = new int[2];

            result[0] = firstNumber;
            result[1] = secondNumber;
            
            return result;
        }

        internal static void AddToHistory(int gameScore, GameType gameType, string difficulty, string gameTime)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                Difficulty = difficulty,
                GameTime = gameTime
            });
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
                {
                Console.WriteLine("Your answer needs to be an integer, try again.");
                result = Console.ReadLine();
            }
            return result;
        }

        internal static string GetName()
        {
            Console.WriteLine("Please enter your name");
            string? name = Console.ReadLine();

            while(string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty, please enter a name");
                name = Console.ReadLine();
            }
                return name;
        }

        internal static int[] SetDifficulty(GameType gameType)
        {
            int[] difficultyRange = new int[3];
            Console.WriteLine($@"
_________________________
Select a Difficluty
E - Easy
M - Medium
H - Hard
-------------------------");
                string? difficulty = Console.ReadLine().ToLower().Trim();
            Console.Clear();
            while(string.IsNullOrWhiteSpace(difficulty) || difficulty != "e" && difficulty != "m" && difficulty != "h")
            {
                Console.WriteLine("Please select a valid difficulty");
                difficulty = Console.ReadLine();

            }

            switch (gameType)
            {
                case 0: //adition
                    if (difficulty == "e")
                    {
                        difficultyRange[0] = 9;
                        difficultyRange[1] = 9;
                        difficultyRange[2] = 1;
                    }
                    else if (difficulty == "m")
                    {
                        difficultyRange[0] = 99;
                        difficultyRange[1] = 99;
                        difficultyRange[2] = 2;
                    }
                    else
                    {
                        difficultyRange[0] = 999;
                        difficultyRange[1] = 999;
                        difficultyRange[2] = 3;
                    }
                    break;
                case (GameType)1://subtraction
                    if (difficulty == "e")
                    {
                        difficultyRange[0] = 9;
                        difficultyRange[1] = 9;
                        difficultyRange[2] = 1;
                    }
                    else if (difficulty == "m")
                    {
                        difficultyRange[0] = 99;
                        difficultyRange[1] = 99;
                        difficultyRange[2] = 2;
                    }
                    else
                    {
                        difficultyRange[0] = 999;
                        difficultyRange[1] = 999;
                        difficultyRange[2] = 3;
                    }
                    break;
                case (GameType)2://multiplication
                    if (difficulty == "e")
                    {
                        difficultyRange[0] = 9;
                        difficultyRange[1] = 9;
                        difficultyRange[2] = 1;
                    }
                    else if (difficulty == "m")
                    {
                        difficultyRange[0] = 99;
                        difficultyRange[1] = 99;
                        difficultyRange[2] = 2;
                    }
                    else
                    {
                        difficultyRange[0] = 999;
                        difficultyRange[1] = 999;
                        difficultyRange[2] = 3;
                    }
                    break;
                case (GameType)3://Division
                    if (difficulty == "e")
                    {
                        difficultyRange[2] = 1;
                        
                    }
                    else if (difficulty == "m")
                    {
                        difficultyRange[2] = 2;
                        
                    }
                    else
                    {
                        difficultyRange[2] = 3;
                        
                    }
                    break;
                 case (GameType)4:
                    if (difficulty == "e")
                    {
                        difficultyRange[0] = 9;
                        difficultyRange[1] = 9;
                        difficultyRange[2] = 1;
                    }
                    else if (difficulty == "m")
                    {
                        difficultyRange[0] = 99;
                        difficultyRange[1] = 99;
                        difficultyRange[2] = 2;
                    }
                    else
                    {
                        difficultyRange[0] = 999;
                        difficultyRange[1] = 999;
                        difficultyRange[2] = 3;
                    }
                    break;
                default:
                    break;
            }


                    return difficultyRange;
        }

        internal static int GetNumberOfQuestions()
        {
            Console.WriteLine("How many questions would you like in this round?");
            string result = Console.ReadLine();
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer, try again.");
                result = Console.ReadLine();
            }
            return int.Parse(result);
        }
    }
}
