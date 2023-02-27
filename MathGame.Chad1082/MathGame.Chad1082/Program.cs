using System;
using System.Linq.Expressions;

namespace MathGame.chad1082
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Menu menu = new Menu();


            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();

            var date = DateTime.UtcNow;

            menu.ShowMainMenu(name, date);



        }



    }
}