namespace jcast24.MathGame;
public class Menu
{
    public void MenuSystem()
    {
        string? input;
        var engine = new Engine();
        while (true)
        {
            Console.WriteLine("Please choose an option: ");
            Console.WriteLine("(a) Addition");
            Console.WriteLine("(s) Subtraction");
            Console.WriteLine("(d) Division");
            Console.WriteLine("(m) Multiplication");
                        
            input = Console.ReadLine();
            switch (input)
            {
                case "a":
                    engine.Addition();
                    break;
                case "s":
                    engine.Subtraction();
                    break;
                case "d":
                    engine.Division();
                    break;
                case "m":
                    engine.Multiplication();
                    break;
                default:
                    Console.WriteLine("Please ask again!");
                    break;
            }
        }
    }
}