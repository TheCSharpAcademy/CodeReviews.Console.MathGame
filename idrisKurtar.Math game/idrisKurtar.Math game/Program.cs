using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idrisKurtar.Math_game
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var date = DateTime.Now;
            var menu = new Menu();
            var games = new List<string>();
            string name = GetName();

            menu.ShowMenu(name, date);
        }


        static string GetName()
        {
            Console.WriteLine("Please type yor name ");
            string name = Console.ReadLine();
            return name;
        }

    }
}
