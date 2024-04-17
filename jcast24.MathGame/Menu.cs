namespace jcast24.MathGame;
public class Menu
{
    public void MenuSystem(int numOfGames)
    {
        var engine = new Engine();
        var isGameOn = true;
        
        // Menu
        do
        {
            Console.Clear();
            Console.WriteLine("Please choose an option: ");
            Console.WriteLine("(a) Addition");
            Console.WriteLine("(s) Subtraction");
            Console.WriteLine("(d) Division");
            Console.WriteLine("(m) Multiplication");
            Console.WriteLine("(v) View games!");
            Console.WriteLine("(r) Random Question");
            Console.WriteLine("(q) quit");
            Console.WriteLine("-------------------------------------");
            
            var input = Console.ReadLine();

            switch (input.Trim().ToLower())
            {
                case "v":
                    engine.GetGames();
                    break;
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
                case "r":
                    engine.randomGame(numOfGames);
                    break;
                case "q":
                    Console.WriteLine("Goodbye!");
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Please ask again!");
                    break;
            }
        } while(isGameOn);
    }
}