using MathGame.Models;

namespace MathGame; 

internal class Program {

    DateTime date = DateTime.Now;

    internal static void Main(string[] args) {
        Menu menu = new Menu();

        string name = Helpers.GetName();
        DateTime date = DateTime.Now;

        menu.ShowMenu(name, date);
    }
}