using System.Net.NetworkInformation;

namespace MathGame
{
    internal class Print
    {
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("----Math Game Menu----");
            Console.WriteLine("----------------------");
            Console.WriteLine("A. Addition");
            Console.WriteLine("S. Subtraction");
            Console.WriteLine("M. Multiplication");
            Console.WriteLine("D. Division");
            Console.WriteLine("H. History of games");
            Console.WriteLine("Q. Quit the game");
            Console.WriteLine("----------------------");
        }

        public static void Operation(int firstNumber, int SecondNumber, char operation)
        {
            Console.Clear();
            Console.WriteLine($"{firstNumber} {operation} {SecondNumber}:");
        }

        //TODO
        public static void History(List<(DateTime, char, int)> historyList)
        {
            Console.WriteLine("History of games: \n");
            foreach (var element in historyList)
            {
                Console.WriteLine($"{element.Item1} - Operation: '{element.Item2}' - Score: {element.Item3}");
            }
            
            Console.WriteLine("\nPress enter to return to main menu");
            Console.ReadKey();
        }
    }
}
