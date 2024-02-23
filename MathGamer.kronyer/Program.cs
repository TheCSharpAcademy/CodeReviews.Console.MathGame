using MathGamer;

namespace MathGame;
internal class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        string name = Helpers.GetName();
        menu.ShowMenu(name);
    }
}



