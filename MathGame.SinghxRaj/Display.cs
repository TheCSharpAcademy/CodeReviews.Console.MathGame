using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinghxRaj.MathGame;

internal class Display
{
    public static void Intro()
    {
        Console.WriteLine("Welcome to the Math Game");
        Console.WriteLine("Play addition, subtract, multiplication, and division game.");
        Console.WriteLine();
    }
    
    public static void Options()
    {
        Console.WriteLine("Type 0 to exit application.");
        Console.WriteLine("Type 1 to view games played");
        Console.WriteLine("Type 2 to play addition game");
        Console.WriteLine("Type 3 to play subtraction game");
        Console.WriteLine("Type 4 to play multiplication game");
        Console.WriteLine("Type 5 to play division game");
        Console.WriteLine();
    }

    public static void Exit()
    {
        Console.WriteLine("Exiting application");
        Console.WriteLine("Press any key to close...");
        Console.ReadKey();
    }
}
