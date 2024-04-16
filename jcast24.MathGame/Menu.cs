/*
 * TODO: make sure to finish implementing the other methods
 */

namespace jcast24.MathGame;
public class Menu
{
    public void MenuSystem()
    {
        string? input;
        var engine = new Engine();
        // Menu
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Please choose an option: ");
            Console.WriteLine("(a) Addition");
            Console.WriteLine("(s) Subtraction");
            Console.WriteLine("(d) Division");
            Console.WriteLine("(m) Multiplication");
                        
            input = Console.ReadLine();
            
            // Ask user how many games they would like to play?
            Console.Write("How many games would you like to play?: ");
            int numOfGames = Convert.ToInt32(Console.ReadLine());
            
            switch (input)
            {
                case "a":
                    engine.Addition(numOfGames);
                    break;
                case "s":
                    engine.Subtraction(numOfGames);
                    break;
                case "d":
                    engine.Division(numOfGames);
                    break;
                case "m":
                    engine.Multiplication(numOfGames);
                    break;
                default:
                    Console.WriteLine("Please ask again!");
                    break;
            }
        }
    }
}