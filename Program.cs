using MathGame.Models;

namespace MathGame; 

internal class Program {

    DateTime date = DateTime.Now;

    internal static void Main(string[] args) {
        Menu menu = new Menu();

        string name = GetName();
        DateTime date = DateTime.Now;

        menu.ShowMenu(name, date);
    }

    static string GetName() {
        Console.Write("Please, type in your name. \n" +
                      ">");
        string name = Console.ReadLine();
        return name;
    }
}