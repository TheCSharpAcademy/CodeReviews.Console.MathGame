using System;
using System.Threading;

namespace MeksMathGame
{
    class Program
    {
        public int tries = 3;

        public void InputInvalid(string error)
        {
            if (tries > 0)
            {
                tries--;
                Console.WriteLine("\n" + error + " " + tries + " Tries Left.");
            }
            else
            {
                Console.WriteLine("\nMaximum Number Attempts Reached. Exiting Program.");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }
        public void GetUserInput()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("When You Are Ready To Begin, Enter 'yes' To Start, Or 'no' To Exit.\n");


            for (int i = 0; i < 3; i++)
            {
                string userReady = Console.ReadLine().ToLower();

                if (userReady == "yes")
                {
                    break;
                }
                else if (userReady == "no")
                {
                    Console.WriteLine("Exiting Program. Please Wait. . .");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
                else
                {
                    InputInvalid("Enter yes To Begin Or no To Exit");
                }
            }

            Console.WriteLine("\nLaunching Difficulty Selection. Please Wait. . .");
            Thread.Sleep(2000);
            Console.Clear();

            MainMenu mainMenu = new();
            mainMenu.DifficultySelection();
        }

        public void WelcomeLabel()
        {
            List<string> welcomeText = new()
            {
                "Welcome To Mek's Math Game!",
                "Some Rules Of Thumb To Remember While Playing:",
                "1) All Answers Are In The Form Of An Integer.",
                "2) If Your Division Answer Gives You A Decimal Like: 0.86, Then Your Answer Is 0",
                "3) This Game Has 3 Difficulties: Easy, Medium, and Hard.",
                "4) None Of The Numbers You Will Encounter On Any Difficulty Will Go Higher Than 100.\n"
            };

            foreach (string text in welcomeText)
            {
                Console.WriteLine(text);
            };

            Program program = new();
            program.GetUserInput();
        }

        static void Main(string[] args)
        {
            Console.Title = "Mek's Math Game - Version 1.0.0";

            Program program = new();
            program.WelcomeLabel();
        }
    }
}