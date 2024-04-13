/*
 * TODO: Implement score/amount of games played ask user if they want to play 1 or more games, show score at the end 
 */
namespace jcast24.MathGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Please enter your name: ");
            // var name = Console.ReadLine();
            // var date = DateTime.UtcNow;
            Console.WriteLine("Welcome to the Math Game!");
            var menu = new Menu();
            menu.MenuSystem();
        }

    }
}