using System.Diagnostics;
using MathGame.Helpers;
using MathGame.Models;

namespace MathGame.Core
{
    internal class GameEngine
    {
        const int QUESTIONS_PER_GAME = 5;
        const int MENU_OPTIONS = 6;
        const int MAX_DIFFICULTY_SETTING = 5;
        const int MIN_DIFFICULTY_SETTING = 1;

        List<GameResult> gameResults;
        Dictionary<GameMode, List<QuestionSet>> questionBank;
        Random random;

        public GameEngine()
        {
            this.questionBank = [];
            this.gameResults = [];
            this.random = new(Guid.NewGuid().GetHashCode());
        }

        public void SeedQuestions(GameMode gameMode, int difficulty)
        {
            questionBank.Clear();

            List<QuestionSet> questions = new();
            for (int i = 0; i < QUESTIONS_PER_GAME; i++)
            {
                QuestionSet questionSet = QuestionSetHelper.GenerateQuestionSet(
                    gameMode,
                    this.random,
                    difficulty
                );
                questions.Add(questionSet);
            }

            questionBank.Add(gameMode, questions);
        }

        public void Run()
        {
            Console.WriteLine(
                "Welcome to the C# Academy Math Game!\nThere are several game modes to choose from. Each game run will contain 5 questions."
            );

            while (true)
            {
                int userChoice = GetGameModeChoice();

                HandleUserChoice(userChoice);
            }
        }

        bool ValidGameModeChoice(int userChoice)
        {
            return (userChoice > 0 && userChoice <= MENU_OPTIONS);
        }

        bool ValidDifficultySetting(int difficulty)
        {
            return difficulty >= MIN_DIFFICULTY_SETTING && difficulty <= MAX_DIFFICULTY_SETTING;
        }

        void PlayGame(GameMode gameMode, int difficulty)
        {
            Console.WriteLine($"You are now playing the {gameMode} game.");
            int score = 0;

            Stopwatch gameTimer = new Stopwatch();
            gameTimer.Start();

            for (int i = 0; i < QUESTIONS_PER_GAME; i++)
            {
                Console.WriteLine(questionBank[gameMode][i].Question);

                bool validResponse = Int32.TryParse(Console.ReadLine(), out int answer);

                if (validResponse && answer == questionBank[gameMode][i].Answer)
                {
                    score += 1;
                }
            }

            gameTimer.Stop();
            ConcludeGame(gameMode, score, difficulty, gameTimer.ElapsedMilliseconds);
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

        void ConcludeGame(GameMode gameMode, int score, int difficulty, long timeTaken)
        {
            Console.WriteLine($"Your game is complete! Your score was: {score}, and you took {TimeSpan.FromMilliseconds(timeTaken).TotalMinutes:N2} minutes.");
            gameResults.Add(new GameResult(score, gameMode, difficulty, timeTaken));
        }

        void ExitGame()
        {
            Console.WriteLine("Thanks for playing!");
            Environment.Exit(0);
        }

        int GetGameModeChoice()
        {
            while (true)
            {
                Console.WriteLine(
                    "Please choose a game mode. Your options are;\n1) Addition\n2) Subtraction\n3) Multiplication\n4) Division\n5) Show Previous Games\n6) Quit"
                );
                bool validInput = Int32.TryParse(Console.ReadLine(), out int choice);
                if (!validInput || !ValidGameModeChoice(choice))
                {
                    Console.WriteLine(
                        "Invalid input provided. Please make sure you choose an existing game mode."
                    );
                    continue;
                }

                return choice;
            }
        }

        int GetDifficulty()
        {
            while (true)
            {
                Console.WriteLine("Please choose a difficulty setting (1-5)");
                bool validInput = Int32.TryParse(Console.ReadLine(), out int difficulty);
                if (!validInput || !ValidDifficultySetting(difficulty))
                {
                    Console.WriteLine(
                        "Invalid input provided. Please make sure you choose a valid difficulty setting.");
                    continue;
                }

                return difficulty;
            }
        }

        void HandleUserChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    int difficulty = GetDifficulty();
                    SeedQuestions((GameMode)choice, difficulty);
                    PlayGame((GameMode)choice, difficulty);
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
    }
}
