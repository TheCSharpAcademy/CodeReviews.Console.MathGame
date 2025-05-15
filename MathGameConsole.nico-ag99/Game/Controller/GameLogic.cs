using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.View;
using Game.Model;
using System.Xml.Linq;

namespace Game.Controller
{
    internal class GameLogic
    {
        static Random random = new Random();
        static GameSession session = new GameSession();
        private static DifficultyMode difficultyMode = DifficultyMode.Easy;

        public void GameRun()
        {
            int option;
            bool exit = false;

            AskForPlayerName();

            do
            {
                GetValidInput(out option, () => ConsoleUI.ShowMainMenuMessage());

                switch (option) 
                {
                    case 0:
                        Console.WriteLine("\n     [ Good Bye ]");
                        exit = true;
                        break;
                    case 1:
                        PlayGame();
                        break;
                    case 2:
                        ShowHistory();
                        break;
                    case 3:
                        ChangeDifficulty();
                        break;
                    case 4:
                        AddNewPlayer();
                        break;
                    default:
                        ConsoleUI.ShowErrorMessage();
                    break;
                }
            }while (!exit);
        }
        static void AskForPlayerName()
        {
            string playerName;
            do
            {
                ConsoleUI.ShowPlayerNamePrompt();

                string? input = Console.ReadLine();
                playerName = input?.Trim() ?? "";

                if (playerName.Length > 8 || playerName.Any(char.IsDigit) || playerName.Contains(" ") || string.IsNullOrEmpty(playerName)) 
                {
                    Console.WriteLine("\n[ Invalid Input: Must be max 8 letters, no numbers ]");
                    Console.ReadKey();
                }
                else
                {
                    session.Name = playerName;

                    Console.WriteLine($"\n[ Welcome to the game, {playerName}! Let's start playing! ]");
                    Console.ReadKey();
                    break;
                }
                Console.Clear();
            }while (true);
        }
        private static void GetValidInput(out int option, Action ShowMessage)
        {
            while (true)
            {
                ShowMessage();
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    return;
                }
                ConsoleUI.ShowErrorMessage();
            }
        }
        static int GenerateRandomNumber()
        {
            switch (difficultyMode)
            {
                case DifficultyMode.Easy:
                    return random.Next(1, 100);
                case DifficultyMode.Medium:
                    return random.Next(100, 1000);
                case DifficultyMode.Hard:
                    return random.Next(1000, 100000);
                default:
                    return 0;
            }
        }
        static void PlayGame()
        {
            int option;
            bool isReturningToMainMenu = false;

            do
            {
                GetValidInput(out option, () => ConsoleUI.ShowGameOptionsMessage());

                switch (option)
                {
                    case 0:
                        isReturningToMainMenu = true;
                        break;
                    case 1:
                        Operation('+');
                        break;
                    case 2:
                        Operation('-');
                        break;
                    case 3:
                        Operation('*');
                        break;
                    case 4:
                        Operation('/');
                        break;
                    case 5:
                        Operation('R');
                        break;
                    default:
                        ConsoleUI.ShowErrorMessage();
                        break;
                }
            }while (!isReturningToMainMenu);
        }
        static void Operation(char sign)
        {
            session.ResetTimer();
            session.StartTimer();

            Dictionary<char, string> operationNames = new Dictionary<char, string>
            {
                {'+', "Addition" },
                {'-', "Subtraction" },
                {'*', "Multiplication" },
                {'/', "Division" },
                {'R', "Random Mode" }
            };

            session.Score = 0;
            int numberOfQuestions = 5;

            if (sign == 'R')
            {
                char[] operationSigns = { '+', '-', '*', '/' };
                for (int i = 0; i < numberOfQuestions; i++)
                {
                    char randomSign = operationSigns[random.Next(0, operationSigns.Length)];
                    MathQuestion(randomSign);
                }
            }
            else 
            {
                for (int i = 0; i < numberOfQuestions; i++)
                {
                    MathQuestion(sign);
                }
            }

            session.StopTimer();
            ConsoleUI.ShowFinishScoreMessage(session.GetElapsedTime(), session.Score);

            if (operationNames.ContainsKey(sign))
                session.SaveGameData(operationNames[sign], difficultyMode.ToString());

            session.ResetScore();
        }
        static void MathQuestion(char sign)
        {
            Console.Clear();

            int num1, num2, answer;

            if (sign == '/')
            {
                num2 = GenerateRandomNumber();
                num1 = num2 * random.Next(1, 10);
            }
            else
            {
                num1 = GenerateRandomNumber();
                num2 = GenerateRandomNumber();
            }

            GetValidInput(out answer, () => ConsoleUI.ShowMathQuest(sign, num1, num2, session.Score));
            
            Dictionary<char, Func<int, int, int>> operations = new Dictionary<char, Func<int, int, int>>
            {
                {'+', (a, b) => a + b},
                {'-', (a, b) => a - b},
                {'*', (a, b) => a * b},
                {'/', (a, b) => a / b}
            };

            if (operations.ContainsKey(sign) && answer == operations[sign](num1, num2))
            {
                ConsoleUI.ShowRandomMessage(true, random.Next(0, 6));
                session.Score++;
            }
            else 
            {
                ConsoleUI.ShowRandomMessage(false, random.Next(0, 6));
            }
        }
        static void ShowHistory() 
        {
            ConsoleUI.ShowGameHistoryMessage(session.History.ToArray());
        }
        static void ChangeDifficulty() 
        {
            int option;
            bool isReturningToMainMenu = false;

            do
            {
                GetValidInput(out option, () => ConsoleUI.ShowDifficultyMainMessage());
                switch (option)
                {
                    case 0:
                        isReturningToMainMenu = true;
                        break;
                    case 1:
                        difficultyMode = DifficultyMode.Easy;
                        ConsoleUI.ShowDifficultyChangeMessage(difficultyMode.ToString());
                        break;
                    case 2:
                        difficultyMode = DifficultyMode.Medium;
                        ConsoleUI.ShowDifficultyChangeMessage(difficultyMode.ToString());
                        break;
                    case 3:
                        difficultyMode = DifficultyMode.Hard;
                        ConsoleUI.ShowDifficultyChangeMessage(difficultyMode.ToString());
                        break;
                    default:
                        ConsoleUI.ShowErrorMessage();
                        break;
                }
            }while (!isReturningToMainMenu);
        }
        static void AddNewPlayer() 
        {
            int option;
            bool isReturningToMainMenu = false;

            do 
            {
                GetValidInput(out option, () => ConsoleUI.ShowChangePlayerMessage());
                switch (option) 
                {
                    case 0:
                        isReturningToMainMenu = true;
                        break;
                    case 1:
                        Console.Clear();
                        AskForPlayerName();
                        break;
                    default:
                        ConsoleUI.ShowErrorMessage();
                        break;
                }
            }while (!isReturningToMainMenu);
        }
    }
}
