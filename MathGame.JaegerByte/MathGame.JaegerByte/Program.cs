using System;
using static System.Console;
using System.Diagnostics;
using System.Collections.Generic;

namespace MathGame.JaegerByte
{
    #region enums
    enum GameDifficulty
    {
        NotSelected = 0,
        Easy = 1,
        Normal = 2,
        Hard = 3
    }

    enum GameState
    {
        Selecting,
        Playing,
        GameOver
    }
    #endregion
    class Program
    {
        #region staticVariables
        static int windowWidth = 60;
        static int windowHeight = 20;

        static int numberOfRoundsPerGame = 10;

        static GameDifficulty selectedDifficulty = GameDifficulty.NotSelected;
        static GameState gamestate = GameState.Selecting;

        static int correctAnswers = 0;

        static Stopwatch stopwatch = new Stopwatch();

        static List<int> gameHistoryScores = new List<int>();
        static List<TimeSpan> gameHistoryTimers = new List<TimeSpan>();
        static List<GameDifficulty> gameHistoryDifficulty = new List<GameDifficulty>();
        #endregion
        static void Main()
        {
            DefineConsole();
            DefineHeader();

            while (true)
            {
                switch (gamestate)
                {
                    case GameState.Selecting:
                        while (selectedDifficulty == GameDifficulty.NotSelected)
                        {
                            DisplayDifficultyOptions();
                            SelectDifficulty();
                        }
                        gamestate = GameState.Playing;
                        break;
                    case GameState.Playing:
                        correctAnswers = 0;
                        DisplayGameRules();
                        stopwatch.Start();
                        PlayGame(selectedDifficulty);
                        break;
                    case GameState.GameOver:
                        stopwatch.Stop();
                        DisplayScore();
                        gameHistoryScores.Add(correctAnswers);
                        gameHistoryTimers.Add(stopwatch.Elapsed);
                        gameHistoryDifficulty.Add(selectedDifficulty);
                        stopwatch.Reset();
                        SelectRestart();
                        break;
                }
            }
        }

        static void DefineConsole()
        {
            {
                Title = "Math Game";
                SetWindowSize(windowWidth, windowHeight);
                SetBufferSize(windowWidth, windowHeight);
                CursorVisible = false;
            }
        }

        static void DefineHeader()
        {
            string headline = "The C# Academy - Console MathGame";
            string subHeadline = "JaegerByte";
            SetCursorPosition(windowWidth / 2 - headline.Length / 2, 1);
            WriteLine(headline);
            SetCursorPosition(windowWidth / 2 - subHeadline.Length / 2, 2);
            WriteLine(subHeadline);
            WriteLine();
            Write(new string('-', windowWidth));
        }

        static void SelectDifficulty()
        {
            while (true)
            {
                ConsoleKeyInfo pressedKey = ReadKey(true);
                if (pressedKey.Key == ConsoleKey.D1 || pressedKey.Key == ConsoleKey.F1)
                {
                    while (true)
                    {
                        SetCursorPosition(0, 10);
                        Write("Select easy mode? Press Y/N");
                        pressedKey = ReadKey(true);
                        if (pressedKey.Key == ConsoleKey.Y)
                        {
                            selectedDifficulty = GameDifficulty.Easy;
                            WriteLine($"\nYou selected easy mode!");
                            WriteLine("Press ANY key to proceed");
                            ReadKey(true);
                            ClearConsoleLines(6, 12, 6, 0);
                            break;
                        }
                        else if (pressedKey.Key == ConsoleKey.N)
                        {
                            ClearConsoleLines(10, 10, 10, 0);
                            break;
                        }
                    }
                    break;
                }
                if (pressedKey.Key == ConsoleKey.D2 || pressedKey.Key == ConsoleKey.F2)
                {
                    while (true)
                    {
                        SetCursorPosition(0, 10);
                        Write("Select normal mode? Press Y/N");
                        pressedKey = ReadKey(true);
                        if (pressedKey.Key == ConsoleKey.Y)
                        {
                            selectedDifficulty = GameDifficulty.Normal;
                            WriteLine($"\nYou selected normal mode!");
                            WriteLine("Press ANY key to proceed");
                            ReadKey(true);
                            ClearConsoleLines(6, 12, 6, 0);
                            break;
                        }
                        else if (pressedKey.Key == ConsoleKey.N)
                        {
                            ClearConsoleLines(10, 10, 10, 0);
                            break;
                        }
                    }
                    break;
                }
                if (pressedKey.Key == ConsoleKey.D3 || pressedKey.Key == ConsoleKey.F3)
                {
                    while (true)
                    {
                        SetCursorPosition(0, 10);
                        Write("Select hard mode? Press Y/N");
                        pressedKey = ReadKey(true);
                        if (pressedKey.Key == ConsoleKey.Y)
                        {
                            selectedDifficulty = GameDifficulty.Hard;
                            WriteLine($"\nYou selected hard mode!");
                            WriteLine("Press ANY key to proceed");
                            ReadKey(true);
                            ClearConsoleLines(6, 12, 6, 0);
                            break;
                        }
                        else if (pressedKey.Key == ConsoleKey.N)
                        {
                            ClearConsoleLines(10, 10, 10, 0);
                            break;
                        }
                    }
                    break;
                }
            }
        }

        static void DisplayDifficultyOptions()
        {
            ClearConsoleLines(6, 18, 6, 0);
            WriteLine("Please select your difficulty... (press 1,2,3)");
            Write("1 - ");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("easy");
            ForegroundColor = ConsoleColor.White;
            Write("2 - ");
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("normal");
            ForegroundColor = ConsoleColor.White;
            Write("3 - ");
            ForegroundColor = ConsoleColor.Red;
            WriteLine("hard");
            ForegroundColor = ConsoleColor.White;
        }

        static void ClearConsoleLines(int lineBegin, int lineEnd, int lineReturn, int columnReturn)
        {
            for (int i = lineBegin; i <= lineEnd; i++)
            {
                SetCursorPosition(0, i);
                Write(new string(' ', windowWidth));
            }
            SetCursorPosition(columnReturn, lineReturn);
        }

        static void DisplayGameRules()
        {
            WriteLine("You will be given 10 math problems.\nTry to solve them as fast as possible. \nType in your answer and confirm with ENTER.");
            WriteLine("Press ANY key to start the Game!");
            ReadKey(true);
        }

        static void PlayGame(GameDifficulty difficulty)
        {
            int maxNumber = 25;
            if (difficulty == GameDifficulty.Easy)
            {
                maxNumber = 25;
            }
            if (difficulty == GameDifficulty.Normal)
            {
                maxNumber = 50;
            }
            if (difficulty == GameDifficulty.Hard)
            {
                maxNumber = 100;
            }

            Random rnd = new Random();

            for (int i = 1; i < numberOfRoundsPerGame; i++)
            {
                ClearConsoleLines(6, 10, 8, windowWidth / 2 - 4);
                int randomOperation = rnd.Next(1, 5);

                bool viableProblem = false;

                int correctResult = 0;

                while (!viableProblem)
                {
                    int firstNumber = rnd.Next(0, maxNumber);
                    int secondNumber = rnd.Next(0, maxNumber);

                    switch (randomOperation)
                    {
                        case 1:
                            correctResult = firstNumber + secondNumber;
                            viableProblem = true;
                            WriteLine($"{firstNumber} + {secondNumber} = ?");
                            break;
                        case 2:
                            correctResult = firstNumber - secondNumber;
                            viableProblem = true;
                            WriteLine($"{firstNumber} - {secondNumber} = ?");
                            break;
                        case 3:
                            correctResult = firstNumber * secondNumber;
                            viableProblem = true;
                            WriteLine($"{firstNumber} * {secondNumber} = ?");
                            break;
                        case 4:
                            if (secondNumber == 0)
                            {
                                break;
                            }
                            if (firstNumber % secondNumber == 0 && firstNumber > secondNumber)
                            {
                                correctResult = firstNumber / secondNumber;
                                viableProblem = true;
                                WriteLine($"{firstNumber} / {secondNumber} = ?");
                            }
                            break;
                    }
                }
                SetCursorPosition(windowWidth / 2 - 2, 10);
                int playerAnswer;
                Int32.TryParse(ReadLine(), out playerAnswer);
                if (correctResult == playerAnswer)
                {
                    correctAnswers++;
                }
            }
            gamestate = GameState.GameOver;
        }

        static void DisplayScore()
        {
            ClearConsoleLines(8, 12, 8, 0);
            WriteLine("Game over!");
            WriteLine($"{correctAnswers} correct answers in {stopwatch.Elapsed:m\\:ss} minutes! ");
        }

        static void SelectRestart()
        {
            WriteLine("Press ENTER to play again or press SPACE for the Scoreboard");
            while (true)
            {
                ConsoleKeyInfo pressedKey = ReadKey(true);
                if (pressedKey.Key == ConsoleKey.Enter)
                {
                    gamestate = GameState.Playing;
                    ClearConsoleLines(6, 12, 6, 0);
                    break;
                }
                if (pressedKey.Key == ConsoleKey.Spacebar)
                {
                    DisplayGameHistory();
                    break;
                }
            }
        }

        static void DisplayGameHistory()
        {
            ClearConsoleLines(6, 12, 6, 0);
            for (int i = 0; i < gameHistoryScores.Count; i++)
            {
                WriteLine($"{i + 1}. Score: {gameHistoryScores[i]} - Time: {gameHistoryTimers[i]:m\\:ss} - Difficulty: {gameHistoryDifficulty[i]} ");
            }
            WriteLine("Press ANY key to return to the menu");
            ReadKey(true);
            selectedDifficulty = GameDifficulty.NotSelected;
            gamestate = GameState.Selecting;
        }

    }
}
