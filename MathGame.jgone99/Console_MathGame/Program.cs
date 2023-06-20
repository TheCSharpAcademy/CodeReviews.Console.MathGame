
using Console_MathGame;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;

        MathGame mathGame = new MathGame();
        mathGame.Start();
    }
}