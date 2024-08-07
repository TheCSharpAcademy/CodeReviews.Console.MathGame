using System;
using System.Linq;

namespace MathGame
{
    internal class Games
    {

        static string? readResult;
        static int response;
        static Random random = new();
        public static int score;
        static bool validResponse;
        static int result;
        static int a;
        static int b;
        public static int HighestScore;
        
        public static void Play(int difficulty,int op, int smallestNum = 0, int greatestNum = 11)
        {
            if (difficulty == 2)
            {
                smallestNum = -10;
                greatestNum = 10;
            }
            else if (difficulty == 3)
            {
                smallestNum = -100;
                greatestNum = 100;
            }
            else if (difficulty == 4)
            {
                smallestNum = -1000;
                greatestNum = 1000;
            }

            a = random.Next(smallestNum, greatestNum);
            b = random.Next(smallestNum, greatestNum);

            switch (op)
            {
                case 1:
                    result = a + b;
                    GameMenu.DisplayMessage("Find the value of x for:");
                    GameMenu.DisplayMessage($"{a} + x = {result}\n");

                    break;
                case 2:
                    result = a - b;
                    GameMenu.DisplayMessage("Find the value of x for:");
                    GameMenu.DisplayMessage($"{a} - x = {result}");

                    break;
                case 3:
                    do
                    {
                        a = random.Next(smallestNum, greatestNum);
                        b = random.Next(smallestNum, greatestNum);
                        result = a * b;
                    } while (result == 0);

                    GameMenu.DisplayMessage("Find the value of x for:");
                    GameMenu.DisplayMessage($"{a} * x = {result}");

                    break;
                case 4:
                    do
                    {
                        a = random.Next(smallestNum, greatestNum);
                        b = random.Next(smallestNum, greatestNum);
                        result = a * b;
                    } while (result == 0);

                    GameMenu.DisplayMessage("Find the value of x for:");
                    GameMenu.DisplayMessage($"{result}/{a} = x");

                    break;
                default:
                    break;
            }
            
            do
            {
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    validResponse = int.TryParse(readResult, out response);
                }
                if (!validResponse)
                {
                    GameMenu.DisplayMessage("Please choose a valid integer for response");
                    Thread.Sleep(1000);
                    Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                    Console.SetCursorPosition(0, Console.CursorTop);
                }

            } while (readResult == null || !validResponse);

            // The wrong answer message was not displaying sometimes, the sleep fixed it.
            Thread.Sleep(300);

            bool finalResult = response == b ? true : false;
            if (!finalResult && response > b - 5 && response < b + 5) { score++; }
            else if (finalResult) { GameMenu.DisplayMessage($"Well done x = {b}"); score += 2; }
            else { GameMenu.DisplayMessage($"Sorry, wrong answer. The right answer is x = {b}"); }
        }

    }
}
