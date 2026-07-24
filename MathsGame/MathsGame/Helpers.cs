using System.Diagnostics.Contracts;

namespace MathsGame;

internal class Helpers
{
    internal static bool isInRange(int number, int lowerBound, int higherBound)
    {
        if (number < lowerBound || number > higherBound)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    internal static void ConsoleClear()
    {
        Thread.Sleep(1000);
        Console.Clear();
    }
    
}
