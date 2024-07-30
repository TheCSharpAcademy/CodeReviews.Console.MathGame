using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class Games
    {

        static string? readResult;
        static int response;
        static Random random = new();
        public static int score = 0;
        static bool validResponse;
        static int result;
        static int a;
        static int b;
        public static int HighestScore = 0;
        public static void Addition(Random numberGenerator, int difficulty = 1, int smallestNum = 0, int greatestNum = 51)
        {
            if (difficulty == 2)
            {
                smallestNum = -100;
                greatestNum = 100;
            }
            else if (difficulty == 3)
            {
                smallestNum = -1000;
                greatestNum = 1000;
            }
            else if (difficulty == 4)
            {
                smallestNum = -10000;
                greatestNum = 10000;
            }

            a = numberGenerator.Next(smallestNum, greatestNum);
            b = numberGenerator.Next(smallestNum, greatestNum);
            result = a + b;
            GameMenu.DisplayMessage("Find the value of x for:");
            GameMenu.DisplayMessage($"{a} + x = {result}\n"); ;
            
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
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    for (int i = 0;i < Console.WindowWidth; i++) Console.Write(" ");
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    for (int i = 0; i < Console.WindowWidth; i++) Console.Write(" ");
                    Console.SetCursorPosition(0,Console.CursorTop);
                }
            } while (readResult == null || !validResponse);

            bool finalResult = response == b ? true : false;
            if (!finalResult && response > b - 5 && response < b + 5) { score++; }
            else if (finalResult) { GameMenu.DisplayMessage($"Well done x = {b}"); score += 2; }
            else { GameMenu.DisplayMessage($"Sorry, wrong anser. The right anser is x = {b}"); }
        }

        public static void Subtracion(Random numberGenerator, int difficulty = 1, int smallestNum = 0, int greatestNum = 51)
        {
            if (difficulty == 2)
            {
                smallestNum = -100;
                greatestNum = 100;
            }
            else if (difficulty == 3)
            {
                smallestNum = -1000;
                greatestNum = 1000;
            }
            else if (difficulty == 4)
            {
                smallestNum = -10000;
                greatestNum = 10000;
            }

            a = numberGenerator.Next(smallestNum, greatestNum);
            b = numberGenerator.Next(smallestNum, greatestNum);
            result = a - b;
            GameMenu.DisplayMessage("Find the value of x for:");
            GameMenu.DisplayMessage($"{a} - x = {result}");

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
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    for (int i = 0; i < Console.WindowWidth; i++) Console.Write(" ");
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    for (int i = 0; i < Console.WindowWidth; i++) Console.Write(" ");
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
            } while (readResult == null || !validResponse);

            bool finalResult = response == b ? true : false;
            if (!finalResult && response > b - 5 && response < b + 5) { score++; }
            else if (finalResult) { GameMenu.DisplayMessage($"Well done x = {b}"); score += 2; }
            else { GameMenu.DisplayMessage($"Sorry, wrong anser. The right anser is x = {b}"); }
        }

        public static void Multiplication(Random numberGenerator, int difficulty = 1, int smallestNum = 0, int greatestNum = 11)
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

            do
            {
                a = numberGenerator.Next(smallestNum, greatestNum);
                b = numberGenerator.Next(smallestNum, greatestNum);            
                result = a * b;
            } while (result != 0);

            GameMenu.DisplayMessage("Find the value of x for:");
            GameMenu.DisplayMessage($"{a} * x = {result}");

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
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    for (int i = 0; i < Console.WindowWidth; i++) Console.Write(" ");
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    for (int i = 0; i < Console.WindowWidth; i++) Console.Write(" ");
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
            } while (readResult == null || !validResponse);

            bool finalResult = response == b ? true : false;
            if (!finalResult && response > b - 5 && response < b + 5) { score++; }
            else if (finalResult) { GameMenu.DisplayMessage($"Well done x = {b}"); score += 2; }
            else { GameMenu.DisplayMessage($"Sorry, wrong anser. The right anser is x = {b}"); }
        }

        public static void Division(Random numberGenerator, int difficulty = 1, int smallestNum = 0, int greatestNum = 11)
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

            do
            {
                a = numberGenerator.Next(smallestNum, greatestNum);
                b = numberGenerator.Next(smallestNum, greatestNum);
                result = a * b;
            } while (result != 0);

            GameMenu.DisplayMessage("Find the value of x for:");
            GameMenu.DisplayMessage($"{result}/{a} = x");

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
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    for (int i = 0; i < Console.WindowWidth; i++) Console.Write(" ");
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    for (int i = 0; i < Console.WindowWidth; i++) Console.Write(" ");
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
            } while (readResult == null || !validResponse);

            bool finalResult = response == b ? true : false;
            if (!finalResult && response > b - 5 && response < b + 5) { score++; }
            else if (finalResult) { GameMenu.DisplayMessage($"Well done x = {b}"); score += 2; }
            else { GameMenu.DisplayMessage($"Sorry, wrong anser. The right anser is x = {b}"); }

        }

    }
}
