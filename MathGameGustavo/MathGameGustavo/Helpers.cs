using MathGameGustavo.Models;

namespace MathGameGustavo
{
    internal class Helpers
    {
        internal static List<Game> games = new List<Game>()
        {
        };

        internal int[] GetDivisionNumbers()
        {
            var random = new Random();
            int firstNumber = random.Next(1, 100);
            int secondNumber = random.Next(1, 100);

            int[] result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 100);
                secondNumber = random.Next(1, 100);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        internal void AddToHistory(int gameScore, GameType gameType, int questionNumber, long timePassed)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                QuestionNumber = questionNumber,
                TimeElapsed = timePassed,
            });
        }

        internal void PrintGames()
        {
            IEnumerable<Game> gamesToPrint = games.OrderByDescending(x => x.Score);

            Console.Clear();
            Console.WriteLine("Game History:\n---------------------------");
            foreach (var game in gamesToPrint)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()}\n{game.Type}\nScore: {game.Score} / {game.QuestionNumber}\n{game.TimeElapsed} Seconds!");
                Console.WriteLine("---------------------------");
            }
            Console.ReadLine();
        }

        internal string? ValidateAnswer(string answer)
        {
            while (string.IsNullOrEmpty(answer) || !Int32.TryParse(answer, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
                answer = Console.ReadLine();
            }
            return answer;
        }

        internal string? ValidateDifficulty(string answer)
        {
            while ((string.IsNullOrEmpty(answer) || !Int32.TryParse(answer, out _) || (int.Parse(answer) < 1 || int.Parse(answer) > 3)))
            {
                Console.WriteLine("Your answer needs to be an integer between 1 and 3. Try again.");
                answer = Console.ReadLine();
            }
            return answer;
        }

        internal string GetName()
        {
            Console.WriteLine("Please type your name:");
            string name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cant be empty.");
                name = Console.ReadLine();
            }
            return name;
        }

        internal string QuestionNumber()
        {
            Console.WriteLine("How many questions would you like the game to have?");
            string numberOfQuestions = Console.ReadLine();
            numberOfQuestions = ValidateAnswer(numberOfQuestions);
            Console.Clear();
            return numberOfQuestions;
        }

        internal string DifficultyMenu()
        {
            int diff = 0;
            string difficultyLevel;

                Console.WriteLine(@$"Select the game Difficulty Level:
        1 - Easy
        2 - Medium
        3 - Hard");
                difficultyLevel = Console.ReadLine();
                difficultyLevel = ValidateDifficulty(difficultyLevel);
                diff = int.Parse(difficultyLevel);
            Console.Clear();

            return (difficultyLevel);
        }

        internal int[] DifficultyNumberGen(string difficultyLevel)
        {
            bool chooseLevel = true;
            int[] numbers = null;
            
                switch (difficultyLevel.ToLower().Trim())
                {
                    case "1":
                        numbers = EasyLevel();
                        chooseLevel = false;
                        break;
                    case "2":
                        numbers = MediumLevel();
                        chooseLevel = false;
                        break;
                    case "3":
                        numbers = HardLevel();
                        chooseLevel = false;
                        break;
                }
            return numbers;
        }

        private int[] EasyLevel()
        {
            var random = new Random();
            int firstNumber = random.Next(0, 10);
            int secondNumber = random.Next(0, 10);

            int[] numbers = { firstNumber, secondNumber };

            return numbers;
        }

        private int[] MediumLevel()
        {
            var random = new Random();
            int firstNumber = random.Next(-5, 10);
            int secondNumber = random.Next(-5 , 10);

            int[] numbers = { firstNumber, secondNumber };

            return numbers;
        }

        private int[] HardLevel()
        {
            var random = new Random();
            int firstNumber = random.Next(-10, 10);
            int secondNumber = random.Next(-10, 10);

            int[] numbers = { firstNumber, secondNumber };

            return numbers;
        }
    }
}
