using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.jwhitt3r
{
    static class Menu
    {

        public static char GenerateMenu()
        {
            Console.WriteLine(@" Game Menu
                A) Addition
                B) Subtraction
                C) Division
                D) Multiplication
                E) List previous games
                P) Print Menu
                Q) Exit
            ");
            return GetUserInput();
        }

        public static int GenerateDifficultyMenu()
        {
            int difficulty = 1;
            Console.WriteLine(@" Difficulty Menu
                A) Difficulty Level 1
                B) Difficulty Level 2
                C) Difficulty Level 3
            ");

            char userInput = GetUserInput();
            if (userInput == '+')
            {
                difficulty = 1;
            }
            if (userInput == '-')
            {
                difficulty = 2;
            }
            if (userInput == '/')
            {
                difficulty = 3;
            }
            return difficulty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static char GetUserInput()
        {
            char userInput = Console.ReadKey().KeyChar;
            switch (userInput)
            {
                case 'a':
                    Console.WriteLine("A - Addition");
                    return '+';
                case 'b':
                    Console.WriteLine("B - Subtraction");
                    return '-';
                case 'c':
                    Console.WriteLine("C - Division");
                    return '/';
                case 'd':
                    Console.WriteLine("D - Multiplication");
                    return '*';
                case 'e':
                    Console.WriteLine("E - List previous answer");
                    return 'e';
                case 'p':
                    Console.WriteLine("P - Print Menu");
                    GenerateMenu();
                    break;
                case 'q':
                    Console.WriteLine("Q - Quit Game");
                    Console.WriteLine("Thank you for playing");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("No character input placed, printing menu...");
                    return 'p';
            }
            return 'p';
        }
    }
}

