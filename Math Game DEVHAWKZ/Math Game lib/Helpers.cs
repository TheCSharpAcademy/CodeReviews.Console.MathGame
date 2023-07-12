using Math_Game_lib.Model;


namespace Math_Game_lib
{
    public static class Helpers
    {
        // greeting
        public static void Greeting(string name, DateTime date)
        {
            Console.Clear();

            Console.WriteLine($"Hello {name}. It's {date.DayOfWeek}. This is your Math's game.\nIt's great that you are working on yourself.");
            Console.WriteLine("\nPress any key to show menu");
            Console.ReadKey();

        }

        // player name
        public static string GetName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("You need to enter a name. Try again.");
                name = Console.ReadLine();
            }
            return name;
        }

        // number of questions
        internal static int NumberOfQuestions()
        {
            Console.Clear();
            Console.WriteLine("Please enter number of questions for the game: ");
            return UserValidations.GetInteger(Console.ReadLine());
        }

        // get numbers
        internal static int[] GetNumbers(int size, char operation, int minValue, int maxValue)
        {
            int[] numbers;

            if (operation != 'd')
            {
                numbers = new int[size * 2];
            }
            else
            {
                numbers = new int[size];
            }

            Random rand = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next(minValue, maxValue);
            }

            return numbers;
        }

        // divisible numbers
        internal static int DivisibleNumbers(int number)
        {
            Random random = new Random();
            int n = random.Next(1, number);

            while (number % n != 0)
            {
                n = random.Next(1, number);
            }

            return n;
        }

        // show menu
        internal static void ShowMenu()
        {
            Console.Clear();

            Console.WriteLine("What game would you like to play today?\nChoose from the options below:\n");
            Console.WriteLine($@"V - View Previous Games
A - Addition
S - Subtraction
M - Multiplication
D - Divison
R - Random game
E - Exit the game

------------------------------------------------------------------------");
        }

        // choosing type of game
        internal static bool ChooseTypeOfGame(bool anotherGame, string choice)
        {
            GameEngine game = new GameEngine();

            switch (choice.Trim().ToLower())
            {
                case "v":
                    PreviousGames();
                    break;

                case "a":
                    game.Addition();
                    break;

                case "s":
                    game.Subtraction();
                    break;

                case "m":
                    game.Multiplication();
                    break;

                case "d":
                    game.Division();
                    break;

                case "r":
                    game.RandomGame();
                    break;

                case "e":
                    anotherGame = ExitGame();
                    break;

                default:
                    Console.WriteLine("\nPlease choose option from the menu.\nPress any key to continue");
                    Console.ReadKey();
                    break;
            }

            return anotherGame;
        }

        // list of games played
        private static readonly List<Game> games = new List<Game>();

        // add games to history
        internal static void AddToHistory(int score, GameType gameType, GameDifficulty difficulty, TimeSpan elapsedTime, int numOfQuestions)
        {
            games.Add(new Game
            {
                DateTime = DateTime.Now,
                GameType = gameType,
                GameDifficulty = difficulty,
                GameDuration = elapsedTime,
                NumberOfQuestion = numOfQuestions,
                Score = score
            });
        }

        // print games history
        internal static void PreviousGames()
        {
            Console.Clear();
            Console.WriteLine("Games History\n");

            if (games.Count == 0)
            {
                Console.WriteLine("You haven't played any game yet!");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }

            else
            {
                foreach (Game game in games)
                {
                    Console.WriteLine($"{game.DateTime} - {game.GameType}: Game Difficulty = {game.GameDifficulty}, Elapsed Time = {game.GameDuration.Seconds} seconds, Number of questions = {game.NumberOfQuestion}, Score = {game.Score}");
                }
                Console.WriteLine("\nPress any key to get back to main menu.");
                Console.ReadKey();
            }

        }

        // show level Menu
        internal static void ShowLevelMenu()
        {
            Console.WriteLine($@"Choose level of the game:

E - Easy
M - Medium
H - Hard");

            Console.Write("Your choice: ");

        }

        // choose level
        internal static int[] ChooseGameLevel(int numberOfQuestions, char operation, out GameDifficulty difficulty)
        {
            Console.Clear();
            Helpers.ShowLevelMenu();
            string level = UserValidations.GetLevel(Console.ReadLine());

            difficulty = 0;
            int[] numbers = null;

            bool emptyNumbers = false;

            switch (level.ToLower())
            {
                case "e":
                    difficulty = GameDifficulty.Easy;
                    numbers = LevelOfDifficulty.Easy(numberOfQuestions, operation);
                    break;

                case "m":
                    difficulty = GameDifficulty.Medium;
                    numbers = LevelOfDifficulty.Medium(numberOfQuestions, operation);
                    break;

                case "h":
                    difficulty = GameDifficulty.Hard;
                    numbers = LevelOfDifficulty.Hard(numberOfQuestions, operation);
                    break;

                default:
                    emptyNumbers = true;
                    break;
            }


            if (emptyNumbers == true)
            {
                Console.WriteLine("\nYou need to choose some of the options in the menu. Please try again.\nPress any key to continue.");
                Console.ReadKey();
                numbers = ChooseGameLevel(numberOfQuestions, operation, out difficulty);
            }

            return numbers;
        }

        // fill game details
        internal static void FillGameDetails(int score, int numberOfQuestions, GameType gameType, GameDifficulty difficulty, TimeSpan elapsedTime)
        {
            Console.Clear();
            Console.WriteLine($"You had {score} out of {numberOfQuestions} correct answers!");
            Helpers.AddToHistory(score, gameType, difficulty, elapsedTime, numberOfQuestions);
            Console.WriteLine("Press any key to get back to main menu.");
            Console.ReadKey();
        }

        // check Answer
        internal static int CheckAnswer(int[] numbers, char operation)
        {
            int correctAnswer = 0;
            int score = 0;
            int answer = 0;
            for (int i = 0; i < numbers.Length; i = i + 2)
            {
                Console.Clear();

                switch (operation)
                {
                    case 'a':
                        correctAnswer = numbers[i] + numbers[i + 1];
                        Console.WriteLine($"How much is: {numbers[i]} + {numbers[i + 1]}? ");
                        answer = UserValidations.GetAnswer(Console.ReadLine());
                        break;

                    case 's':
                        correctAnswer = numbers[i] - numbers[i + 1];
                        Console.WriteLine($"How much is: {numbers[i]} - {numbers[i + 1]}? ");
                        answer = UserValidations.GetAnswer(Console.ReadLine());
                        break;

                    case 'm':
                        correctAnswer = numbers[i] * numbers[i + 1];
                        Console.WriteLine($"How much is: {numbers[i]} * {numbers[i + 1]}? ");
                        answer = UserValidations.GetAnswer(Console.ReadLine());
                        break;
                }

                if (answer == correctAnswer)
                {
                    Console.WriteLine("Your answer is correct\nPress any key to continue");
                    Console.ReadKey();
                    score++;
                }
                else
                {
                    Console.WriteLine($"Your answer is incorrect. Correct answer is: {correctAnswer}\nPress any key to continue");
                    Console.ReadKey();
                }
            }
            return score;
        }

        internal static int CheckDivisionAnswer(int[] numbers)
        {
            int[] divisonNumbers = new int[numbers.Length];

            for (int i = 0; i < divisonNumbers.Length; i++)
            {
                divisonNumbers[i] = Helpers.DivisibleNumbers(numbers[i]);
            }

            int correctAnswer = 0;
            int score = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Clear();
                correctAnswer = numbers[i] / divisonNumbers[i];

                Console.WriteLine($"How much is: {numbers[i]} / {divisonNumbers[i]}? ");
                int answer = UserValidations.GetAnswer(Console.ReadLine());

                if (answer == correctAnswer)
                {
                    Console.WriteLine("Your answer is correct\nPress any key to continue");
                    Console.ReadKey();
                    score++;
                }
                else
                {
                    Console.WriteLine("Your answer is incorrect\nPress any key to continue");
                    Console.ReadKey();
                }
            }

            return score;
        }

        // Exit game
        internal static bool ExitGame() => false;

    }
}