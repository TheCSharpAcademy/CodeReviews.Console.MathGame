using System;

namespace MathGame
{
    class Program
    {
        static void Main()
        {
            Menu menu = new Menu();
            Console.WriteLine("Welcome! Please type your name:");
            Console.WriteLine("\n");

            string name = Console.ReadLine();
            menu.StartMenu(name);
        }
    }
}
