using System;
using System.Collections.Generic;
using System.Timers;

namespace MathGame.Parabeiium
{
    public class Runner
    {
        private bool running = true;
        private string userChoice;
        private List<string> history = new List<string>();
        Random rn = new Random();
        private int userQuestionsNum;
        static int counter;
        Difficuty difficuty;
        static Timer tmr = new Timer();
        bool random = false;


        public void Run()
        {
            tmr.Elapsed += TimerCountDown;
            tmr.Interval = 1000;
            while (running == true)
            {
                Console.WriteLine("Choose your type of game \n" +
                    "A - Addition\n" +
                    "S - Subtraction\n" +
                    "M - Multiplication\n" +
                    "D - Division\n" +
                    "H - Show History\n" +
                    "Q - To exit the program\n" +
                    "R - Random mode");
                userPickChoice();
            }
        }

        public void userPickChoice()
        {
            random = false;

            userChoice = Console.ReadLine().ToLower();
            switch (userChoice)
            {
                case "a":
                    DifficultyLevel(userChoice);
                    break;
                case "s":
                    DifficultyLevel(userChoice);
                    break;
                case "m":
                    DifficultyLevel(userChoice);
                    break;
                case "d":
                    DifficultyLevel(userChoice);
                    break;
                case "h":
                    ShowHistory(userChoice);
                    break;
                case "q":
                    running = false;
                    break;
                case "r":
                    random = true;
                    DifficultyLevel(userChoice);

                    break;
                default:
                    ErrMessage();
                    break;
            }
        }

        private void DifficultyLevel(string userChoice)
        {
            Console.WriteLine("Enter difficulty level:\n" +
                "E - Easy\n" +
                "M - Medium\n" +
                "H - Hard\n");

            string level = Console.ReadLine();

            switch (level)
            {
                case "e":
                    difficuty = Difficuty.Easy;
                    NumberOfQuestions();
                    break;
                case "m":
                    difficuty = Difficuty.Medium;
                    NumberOfQuestions();
                    break;
                case "h":
                    difficuty = Difficuty.Hard;
                    NumberOfQuestions();
                    break;
                default:
                    ErrMessage();
                    break;
            }
        }

        private void NumberOfQuestions()
        {
            Console.WriteLine("Enter number of questions you would like to answer");
            int.TryParse(Console.ReadLine(), out userQuestionsNum);
            if (userQuestionsNum == 0)
            {
                ErrMessage();
            }
            else
            {
                for (int i = userQuestionsNum; i > 0; i--)
                {
                    int firstNumber = default;
                    int secondNumber = default;
                    switch (difficuty)
                    {
                        case Difficuty.Easy:
                            counter = 30;
                            firstNumber = rn.Next(0, 11);
                            secondNumber = rn.Next(0, 11);
                            break;
                        case Difficuty.Medium:
                            counter = 20;
                            firstNumber = rn.Next(0, 51);
                            secondNumber = rn.Next(0, 51);
                            break;
                        case Difficuty.Hard:
                            counter = 15;
                            firstNumber = rn.Next(0, 101);
                            secondNumber = rn.Next(0, 101);
                            break;
                        default:
                            break;
                    }
                    OperationMode(userChoice, firstNumber, secondNumber);
                }
            }
        }

        private void ShowHistory(string choice)
        {
            if (userChoice == "h")
            {
                Console.Clear();
                Console.WriteLine("Recorded answers :");
                Console.WriteLine("-----------------");
                if (history.Count == 0)
                {
                    Console.WriteLine("no recorded answers");
                    Console.WriteLine();

                }
                foreach (var item in history)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();

        }

        private static void ErrMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("invalid Choice");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
        }

        public void OperationMode(string oper, int numOne, int numTwo)
        {
            if (random == true)
            {
                string[] operators = { "a", "s", "m", "d" };
                Random rnd = new Random();
                oper = operators[rnd.Next(0, operators.Length)];
            }
            Console.WriteLine();

            int sum = 0;
            switch (oper)
            {
                case "a":
                    Check(numOne, numTwo, sum, "+");
                    break;
                case "s":
                    Check(numOne, numTwo, sum, "-");
                    break;
                case "m":
                    Check(numOne, numTwo, sum, "*");
                    break;
                case "d":
                    Check(numOne, numTwo, sum, "/");
                    break;
            }
        }

        public void Check(int firstNum, int secondNum, int sum, string oper)
        {
            tmr.Start();

            string currentQuestion = $"{firstNum} {oper} {secondNum} = ? ";
            int userAnswer;
            bool answer;
            switch (oper)
            {
                case "+":
                    sum = firstNum + secondNum;
                    break;
                case "-":
                    sum = firstNum - secondNum;
                    break;
                case "*":
                    sum = firstNum * secondNum;
                    break;
                case "/":
                    sum = firstNum / secondNum;
                    break;

                default:
                    break;
            }

            Console.WriteLine(currentQuestion);
            int.TryParse(Console.ReadLine(), out userAnswer);

            if (userAnswer != sum)
            {
                answer = false;
                tmr.Stop();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Wrong answer , the correct answer is {sum}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                tmr.Stop();
                answer = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct");
                Console.ForegroundColor = ConsoleColor.White;

            }
            currentQuestion += (userAnswer.ToString() + " " + answer.ToString());
            history.Add(currentQuestion);
            running = true;
        }

        private static void TimerCountDown(object obj, ElapsedEventArgs e)
        {
            if (counter > 0)
            {
                counter--;

                Console.WriteLine(counter);
            }
            else if (counter <= 0)
            {
                tmr.Stop();
                Console.WriteLine("Time is up");
            }
        }

        public enum Difficuty
        {
            Easy,
            Medium,
            Hard
        }
    }
}
