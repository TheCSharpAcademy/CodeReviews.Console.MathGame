// See https://aka.ms/new-console-template for more information
using MathGameV2.Models;
using System.ComponentModel.DataAnnotations;

namespace MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine newEngine = new Engine();
            newEngine.GenerateMainMenu();

            Console.ReadLine();
        }
    }
}


