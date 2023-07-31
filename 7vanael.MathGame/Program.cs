using System.Dynamic;

namespace _7vanael.MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string name = Helpers.GetName();
            var menu = new Menu();
            var date = DateTime.UtcNow;
            var games = new List<string>();
            menu.ShowMenu(name, date);
        }
    }
}