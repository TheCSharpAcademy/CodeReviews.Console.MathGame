using MathGame.Helpers;
using MathGame.Models;
using System;

namespace MathGame.Core
{
    internal class GameEngine
    {
        // TODO: Refactor to be configurable (ask user for input)
        const int QUESTIONS_PER_GAME = 5;

        // TODO: Refactor to use a dictionary where the option provided is
        // the key to an action
        const int MENU_OPTIONS = 6;

        List<GameResult> gameResults;
        Dictionary<GameMode, List<QuestionSet>> questionBank;
        Random random;

        public GameEngine()
        {
            this.questionBank = [];
            this.gameResults = [];
            this.random = new(Guid.NewGuid().GetHashCode());
        }

        public void SeedQuestions()
        {
            questionBank.Clear();

            // Each game mode should have all questions populated so we only need to seed once
            foreach (GameMode gameMode in Enum.GetValues(typeof(GameMode)))
            {
                for (int i = 0; i < QUESTIONS_PER_GAME; i++)
                {
                    // TODO: We should make sure we have a valid question at some point
                    // (i.e., a division only incurs an integer division)

                    // TODO: The ranges should depend on difficulty
                    QuestionSet questionSet = QuestionSetHelper.GenerateQuestionSet(gameMode, this.random);
                }
            }
        }

        public void Run()
        {
            SeedQuestions();

            while (true)
            {
                // TODO: Refactor to extracted method
                Console.WriteLine(
                    "Please choose a game mode. Your options are;\n1) Addition\n2) Subtraction\n3) Multiplication\n4) Division\n5) Show Previous Games\n6) Quit"
                );

                // TODO: Refactor to validation/ get user input method
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
                        ExitGame();
                        break;
                    default:
                        break;
                }
            }

            bool validGameMode(int userChoice)
            {
                return (userChoice > 0 && userChoice <= MENU_OPTIONS);
            }

            void PlayGame(GameMode gameMode)
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

            void DisplayGameResults()
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

            void ConcludeGame(GameMode gameMode, int score)
            {
                Console.WriteLine($"Your game is complete! Your score was: {score}");
                gameResults.Add(new GameResult(score, gameMode));
            }

            void ExitGame()
            {
                Console.WriteLine("Thanks for playing!");
                Environment.Exit(0);
            }
        }
    }
}
