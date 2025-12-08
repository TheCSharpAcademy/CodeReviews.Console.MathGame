using MathGame.Models;

namespace MathGame
{
    internal class GameResult
    {
        public int Result { get; set; }
        public GameMode GameMode { get; set; }
        public DateTime Date { get; set; }

        public GameResult(int result, GameMode gameMode)
        {
            Result = result;
            GameMode = gameMode;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return new string(
                $"On {Date.ToString()} you played a game of {GameMode.ToString()} and got the score {Result} "
            );
        }
    }

    internal class Program
    {
        const int QUESTIONS_PER_GAME = 5;
        const int GAME_MODES = 6;

        public static Dictionary<GameMode, List<QuestionSet>> questionBank = new Dictionary<
            GameMode,
            List<QuestionSet>
        >()
        {
            {
                GameMode.ADDITION,
                new List<QuestionSet>()
                {
                    new QuestionSet("5 + 5 = ?", 10),
                    new QuestionSet("10 + 2 = ?", 12),
                    new QuestionSet("13 + 12 = ?", 25),
                    new QuestionSet("44 + 22 = ?", 66),
                    new QuestionSet("100 + 55 = ?", 155),
                }
            },
            {
                GameMode.SUBTRACTION,
                new List<QuestionSet>()
                {
                    new QuestionSet("5 - 5 = ?", 0),
                    new QuestionSet("10 - 2 = ?", 8),
                    new QuestionSet("13 - 12 = ?", 1),
                    new QuestionSet("44 - 22 = ?", 22),
                    new QuestionSet("100 - 55 = ?", 45),
                }
            },
            {
                GameMode.MULTIPLICATION,
                new List<QuestionSet>()
                {
                    new QuestionSet("5 * 5 = ?", 25),
                    new QuestionSet("10 * 2 = ?", 20),
                    new QuestionSet("13 * 12 = ?", 156),
                    new QuestionSet("44 * 22 = ?", 968),
                    new QuestionSet("100 * 55 = ?", 5500),
                }
            },
            {
                GameMode.DIVISION,
                new List<QuestionSet>()
                {
                    new QuestionSet("5 / 5 = ?", 1),
                    new QuestionSet("10 / 2 = ?", 5),
                    new QuestionSet("36 / 12 = ?", 3),
                    new QuestionSet("44 / 22 = ?", 2),
                    new QuestionSet("100 / 10 = ?", 10),
                }
            },
        };

        public static List<GameResult> gameResults = new();

        public static void Main(string[] args)
        {
            // TODO: Refactor to Engine class
            Console.WriteLine(
                "Welcome to the C# Academy Math Game!\nThere are several game modes to choose from. Each game run will contain 5 questions."
            );
            bool playing = true;

            // TODO: Refactor to Engine loop
            while (playing)
            {
                Console.WriteLine(
                    "Please choose a game mode. Your options are;\n1) Addition\n2) Subtraction\n3) Multiplication\n4) Division\n5) Show Previous Games\n6) Quit"
                );

                bool validInput = Int32.TryParse(Console.ReadLine(), out int userChoice);
                if (!validInput || !validGameMode(userChoice))
                {
                    Console.WriteLine(
                        "Invalid input provided. Please make sure you choose an existing game mode."
                    );
                    continue;
                }

                // TODO: Refactor to Engine Question method
                switch (userChoice)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        PlayGame((GameMode)userChoice);
                        break;
                    case 5:
                        DisplayGameResults();
                        break;
                    case 6:
                        playing = false;
                        break;
                    default:
                        break;
                }
            }
        }

        static bool validGameMode(int userChoice)
        {
            return (userChoice > 0 && userChoice <= GAME_MODES);
        }

        static void PlayGame(GameMode gameMode)
        {
            Console.WriteLine($"You are now playing the {gameMode} game.");
            int score = 0;

            for (int i = 0; i < QUESTIONS_PER_GAME; i++)
            {
                Console.WriteLine(questionBank[gameMode][i].Question);

                bool validResponse = Int32.TryParse(Console.ReadLine(), out int answer);

                if (validResponse && answer == questionBank[gameMode][i].Answer)
                {
                    score += 1;
                }
            }

            ConcludeGame(gameMode, score);
        }

        static void ConcludeGame(GameMode gameMode, int score)
        {
            Console.WriteLine($"Your game is complete! Your score was: {score}");
            gameResults.Add(new GameResult(score, gameMode));
        }

        static void DisplayGameResults()
        {
            if (gameResults.Count() == 0)
            {
                Console.WriteLine("No previous game results found!\n");
                return;
            }

            foreach (GameResult gameResult in gameResults)
            {
                Console.WriteLine(gameResult.ToString());
            }
            Console.WriteLine();
        }
    }
}
