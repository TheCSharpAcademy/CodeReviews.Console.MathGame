using System.Collections.Generic;

namespace MathGame
{
    internal enum GameMode
    {
        ADDITION = 0,
        SUBTRACTION,
        MULTIPLICATION,
        DIVISION,
    }

    internal class QuestionSet
    {
        public string Question { get; set; }
        public int Answer { get; set; }

        public QuestionSet(string question, int answer)
        {
            Question = question;
            Answer = answer;
        }
    }

    internal class Program
    {
        const int QUESTIONS_PER_GAME = 5;
        const int GAME_MODES = 4;

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
                    new QuestionSet("10 / 2 = ?", 2),
                    new QuestionSet("36 / 12 = ?", 3),
                    new QuestionSet("44 / 22 = ?", 2),
                    new QuestionSet("100 / 10 = ?", 10),
                }
            },
        };

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
                    "Please choose a game mode. Your options are;\n1) Addition\n2) Subtraction\n3) Multiplication\n4) Division"
                );

                bool validInput = Int32.TryParse(Console.ReadLine(), out int userChoice);
                if (!validInput || !validGameMode(userChoice))
                {
                    Console.WriteLine(
                        "Invalid input provided. Please make sure you choose an existing game mode."
                    );
                    continue;
                }
                Console.WriteLine($"Entering game mode {userChoice}");

                // TODO: Refactor to Engine Question method
                switch (userChoice)
                {
                    case 1:
                        PlayAdditionGame();
                        break;
                    case 2:
                        PlaySubtractionGame();
                        break;
                    case 3:
                        PlayMultiplicationGame();
                        break;
                    case 4:
                        PlayDivisionGame();
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

        static void PlayAdditionGame()
        {
            Console.WriteLine("You are now playing the ADDITION game.");

            for (int i = 0; i < GAME_MODES; i++)
            {
                Console.WriteLine(questionBank[GameMode.ADDITION][i].Question);

                bool validResponse = Int32.TryParse(Console.ReadLine(), out int answer);

                if (validResponse && answer == questionBank[GameMode.ADDITION][i].Answer)
                {
                    Console.WriteLine("Congrats smarty boy");
                }
                else
                {
                    Console.WriteLine("Dead wrong.");
                }
            }
        }

        static void PlaySubtractionGame()
        {
            Console.WriteLine("You are now playing the SUBTRACTION game.");

            for (int i = 0; i < GAME_MODES; i++)
            {
                Console.WriteLine(questionBank[GameMode.SUBTRACTION][i].Question);

                bool validResponse = Int32.TryParse(Console.ReadLine(), out int answer);

                if (validResponse && answer == questionBank[GameMode.SUBTRACTION][i].Answer)
                {
                    Console.WriteLine("Congrats smarty boy");
                }
                else
                {
                    Console.WriteLine("Dead wrong.");
                }
            }
        }

        static void PlayMultiplicationGame()
        {
            Console.WriteLine("You are now playing the MULTIPLICATION game.");

            for (int i = 0; i < GAME_MODES; i++)
            {
                Console.WriteLine(questionBank[GameMode.MULTIPLICATION][i].Question);

                bool validResponse = Int32.TryParse(Console.ReadLine(), out int answer);

                if (validResponse && answer == questionBank[GameMode.MULTIPLICATION][i].Answer)
                {
                    Console.WriteLine("Congrats smarty boy");
                }
                else
                {
                    Console.WriteLine("Dead wrong.");
                }
            }
        }

        static void PlayDivisionGame()
        {
            Console.WriteLine("You are now playing the DIVISION game.");

            for (int i = 0; i < GAME_MODES; i++)
            {
                Console.WriteLine(questionBank[GameMode.DIVISION][i].Question);

                bool validResponse = Int32.TryParse(Console.ReadLine(), out int answer);

                if (validResponse && answer == questionBank[GameMode.DIVISION][i].Answer)
                {
                    Console.WriteLine("Congrats smarty boy");
                }
                else
                {
                    Console.WriteLine("Dead wrong.");
                }
            }
        }
    }
}
