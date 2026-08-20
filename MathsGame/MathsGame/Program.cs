using System.Collections.Generic;
using System.Diagnostics;

namespace MathsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowMenuSelection();
        }   

        static void ShowMenuSelection()
        {
            List<int> gameScores = new List<int>();
            List<TimeSpan> listOfTimes = new List<TimeSpan>();
            bool exitGame = false;
            string? menuSelection;

            do
            {
                Console.Clear();
                Console.WriteLine("Please select a menu option:\n\n1: Play\n2: Show Scores\n3: Exit");
                menuSelection = Console.ReadLine()?.ToLower().Trim();

                switch (menuSelection)
                {
                    case "1":
                        PlayGame(gameScores, listOfTimes);
                        break;

                    case "2":
                        ShowScores(gameScores, listOfTimes);
                        break;

                    case "3":
                        exitGame = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid option!");
                        break;
                }

            } while (exitGame == false);
        }

        static void PlayGame(List<int> scoresOfGames, List<TimeSpan> listOfTimes)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Maths Game!");

            Random random = new Random();

            int numOfQuestions = 10;
            int firstNum;
            int secondNum;
            int answer = 0;
            int userScore = 0;

            string operationSign = ChooseSign();
            int questionRange = ChooseDifficulty();

            Console.Clear();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < numOfQuestions; i++)
            {
                int randomSign = random.Next(1, 5);
                firstNum = random.Next(1, questionRange);
                secondNum = random.Next(1, questionRange);

                string currentSign = operationSign;

                Console.WriteLine($"Question {i+1}");
                if (currentSign == "random")
                {
                    switch (randomSign)
                    {
                        case 1:
                            currentSign = "+";
                            break;

                        case 2:
                            currentSign = "-";
                            break;

                        case 3:
                            currentSign = "x";
                            break;

                        case 4:
                            currentSign = "÷";
                            break;
                    }
                }

                switch (currentSign)
                {
                    case "+":
                        answer = firstNum + secondNum;
                        break;

                    case "-":
                        if (secondNum > firstNum)
                        {
                            int placeholder;
                            placeholder = firstNum;
                            firstNum = secondNum;
                            secondNum = placeholder;
                        }
                        answer = firstNum - secondNum;
                        break;

                    case "x":
                        answer = firstNum * secondNum;
                        break;

                    case "÷":
                        do
                        {
                            if (questionRange == 21)
                            {
                                firstNum = random.Next(1, 21);
                                secondNum = random.Next(1, 11);
                            }
                            else if (questionRange == 251)
                            {
                                firstNum = random.Next(1, 51);
                                secondNum = random.Next(1, 11);
                            }
                            else if (questionRange == 1001)
                            {
                                firstNum = random.Next(1, 101);
                                secondNum = random.Next(1, 11);
                            }

                        } while (secondNum == 0 || firstNum % secondNum != 0);

                        answer = firstNum / secondNum;
                        break;
                }
                Console.WriteLine($"Total Score: {userScore}/10");
                Console.WriteLine($"{firstNum} {currentSign} {secondNum} = ?");
                int parsedGuess;

                while (!int.TryParse(Console.ReadLine(), out parsedGuess))
                {
                    Console.WriteLine("That is not a number, try again!");
                }

                if (parsedGuess == answer)
                {
                    Console.WriteLine("Correct!");
                    userScore++; 
                }

                else
                {
                    Console.WriteLine($"Incorrect! The correct answer was {answer}");
                }

                Thread.Sleep(1000);
                Console.Clear();

            }

            stopwatch.Stop();
            TimeSpan timeTaken = stopwatch.Elapsed;

            Console.WriteLine($"You scored {userScore}/10\nYou took {timeTaken.Minutes} mins and {timeTaken.Seconds} seconds\nPress Enter to continue...");
            scoresOfGames.Add(userScore);
            listOfTimes.Add(timeTaken);
            Console.ReadLine();
        }

        static string ChooseSign()
        {
            char[] signs = ['+', '-', 'x', '÷'];
            string? SelectedSign;
            bool signSelected = false;

            do
            {
                Console.WriteLine("Please choose a sign: '+', '-', 'x', '÷', 'random'");
                SelectedSign = Console.ReadLine()?.ToLower().Trim();

                if (SelectedSign != "")
                {
                   foreach(char sign in signs)
                    {
                        if (sign.ToString() == SelectedSign)
                        {
                            return SelectedSign;
                        }

                        else if (SelectedSign == "random")
                        {
                            return SelectedSign;
                        }
                    }                                           
                }

            } while (signSelected == false);

            return SelectedSign;
        }

        static int ChooseDifficulty()
        {
            while (true)
            {

                Console.WriteLine("Please choose a difficulty! (easy, medium, hard)");
                string? difficultySelected = Console.ReadLine()?.ToLower().Trim();

                switch (difficultySelected)
                {
                    case "easy":
                        return 21;

                    case "medium":
                        return 251;

                    case "hard":
                        return 1001;

                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid option!");
                        break;
                }
            }
        }

        static void ShowScores(List<int> scoresOfGames, List<TimeSpan> timeToComplete)
        {
            Console.Clear();

            for (int i = 0; i < scoresOfGames.Count(); i++)
            {  
                Console.WriteLine($"Game {i+1}: {scoresOfGames[i]} ({timeToComplete[i].Minutes} mins, {timeToComplete[i].Seconds} seconds)");
            }

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }

}
