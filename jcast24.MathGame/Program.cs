using jcast24.MathGame;

namespace LocalMathGame;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Math game!");
        var menu = new Menu();
        menu.MenuSystem();
    }
}