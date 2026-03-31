namespace MathGame;

internal class Menu
{
    internal void ShowMenu(string name, DateTime date)
    {
        bool playAgain = true;
        
        Console.WriteLine($"Hello {name}! It is {date}.");

        do
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Play Math Game!");
            Console.WriteLine("2. Show Scores");
            Console.WriteLine("Enter x to exit");
            
            string menuSelection = Console.ReadLine();

            switch (menuSelection)
            {
                case "1":
                    Console.WriteLine("Math Game");
                    break;
                case "2":
                    Console.WriteLine("Show Scores");
                    break;
                case "x":
                    playAgain = false;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
        } while (playAgain);
        
        Console.WriteLine("Thanks for playing!");
    }
    
    
}