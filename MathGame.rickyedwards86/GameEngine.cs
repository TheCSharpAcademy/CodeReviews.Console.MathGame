using MathGame.Constants;
using System.Diagnostics;

namespace MathGame
{
    internal class GameEngine
    {
        static readonly GameEngine _instance = new GameEngine();
        string GameType { get; set; }
        int firstNumber;
        int secondNumber;
        int score;
        int totalQuestions = 10;
        int questionsLeft;
        static Stopwatch sw = Stopwatch.StartNew();

        public static GameEngine Instance { get { return _instance; } }

        public void StartGame(string gameType)
        {
            score = 0;
            this.GameType = gameType;
            this.questionsLeft = totalQuestions;

            WriteHeader();

            CreateNewQuestion();

            Console.WriteLine($"Game Over! you scored {score} out of {totalQuestions} in {sw.ElapsedMilliseconds / 1000} seconds");
            Console.WriteLine($"Press 's' to save your score, or any other key to skip");

            var cki = Console.ReadKey().Key;

            if (cki == ConsoleKey.S)
            {
                SaveGame();
                Console.WriteLine("Score Saved. Going back to Main Menu");
            }
        }

        void WriteHeader()
        {
            Console.Clear();
            var gameTypeText = GameType switch
            {
                Operand.Addition => nameof(Operand.Addition),
                Operand.Subtraction => nameof(Operand.Subtraction),
                Operand.Division => nameof(Operand.Division),
                Operand.Multiplication => nameof(Operand.Multiplication)
            };
            Console.WriteLine($"Welcome to {gameTypeText}");
            Console.WriteLine($"There will be {totalQuestions} questions to answer, type 'stop' at any time to return to the main menu.");
            Console.WriteLine($"For each question, enter your answer and press Enter.");
            Console.WriteLine($"\r\nQuestion {(totalQuestions - questionsLeft) + 1} out of {totalQuestions}");
            if (questionsLeft < totalQuestions)
            {
                Console.WriteLine($"Score is {score} out of {totalQuestions}\r\n");
            }
        }

        void CreateNewQuestion()
        {
            WriteHeader();
            firstNumber = GetRandomNumber(GameType);
            secondNumber = GetRandomNumber(GameType);

            switch (GameType)
            {
                case Operand.Division:
                    while (firstNumber < secondNumber || firstNumber % secondNumber != 0)
                    {
                        firstNumber = GetRandomNumber(GameType);
                        secondNumber = GetRandomNumber(GameType);
                    }
                    break;
                case Operand.Subtraction:
                    while (firstNumber < secondNumber)
                    {
                        firstNumber = GetRandomNumber(GameType);
                        secondNumber = GetRandomNumber(GameType);
                    }
                    break;
            }

            AskQuestion();
        }

        int GetRandomNumber(string gameType)
        {
            var random = new Random();

            return gameType != Operand.Division ? random.Next(1, 20) : random.Next(1, 100);
        }

        void AskQuestion()
        {
            Console.WriteLine($"{firstNumber} {GameType} {secondNumber} =");
            WaitForAnswer();
        }

        void WaitForAnswer()
        {
            var answerText = Console.ReadLine();

            if (string.IsNullOrEmpty(answerText))
            {
                Console.WriteLine("Invalid Entry, please try again");
                this.AskQuestion();
                return;
            }

            if (answerText == "stop")
            {
                return;
            }

            var answer = Double.Parse(answerText);
            var isCorrect = false;

            switch (GameType)
            {
                case Operand.Addition:
                    isCorrect = answer == firstNumber + secondNumber;
                    break;
                case Operand.Subtraction:
                    isCorrect = answer == firstNumber - secondNumber;
                    break;
                case Operand.Multiplication:
                    isCorrect = answer == firstNumber * secondNumber;
                    break;
                case Operand.Division:
                    isCorrect = answer == firstNumber / secondNumber;
                    break;
            }

            ProcessAnswer(isCorrect);

            questionsLeft--;
            if (questionsLeft > 0)
            {
                CreateNewQuestion();
            }
        }

        void ProcessAnswer(bool isCorrect)
        {
            if (isCorrect) { score += 1; }
        }

        void SaveGame()
        {
            GameHistory.Instance.SaveScore(new GameScore { Operand = GameType, Score = score, TotalQuestions = totalQuestions, TimeTaken = (sw.ElapsedMilliseconds / 1000) });
        }
    }
}