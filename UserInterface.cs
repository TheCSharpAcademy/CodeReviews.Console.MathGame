using MathGame;

namespace mathGame.Natephor;

public static class UserInterface
{
    public static void Greeter()
    {
        Console.WriteLine("""
                          ███╗   ███╗█████╗██████████╗  ██╗     ██████╗ █████╗███╗   ██████████╗
                          ████╗ ██████╔══██╚══██╔══██║  ██║    ██╔════╝██╔══██████╗ ██████╔════╝
                          ██╔████╔█████████║  ██║  ███████║    ██║  ████████████╔████╔███████╗  
                          ██║╚██╔╝████╔══██║  ██║  ██╔══██║    ██║   ████╔══████║╚██╔╝████╔══╝  
                          ██║ ╚═╝ ████║  ██║  ██║  ██║  ██║    ╚██████╔██║  ████║ ╚═╝ █████████╗
                          ╚═╝     ╚═╚═╝  ╚═╝  ╚═╝  ╚═╝  ╚═╝     ╚═════╝╚═╝  ╚═╚═╝     ╚═╚══════╝
                          """);
    }
    
    public static void DisplayMenu()
    {
        Console.WriteLine("\nSelect an operation (1-4):");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Random Operation");
        Console.WriteLine("6. Show History");
        Console.WriteLine("7. End Game");
        Console.Write("Select an option: ");
    }

    public static void DisplayHistory(List<GameRound> rounds)
    {
        if (rounds.Count == 0)
        {
            Console.WriteLine("You haven't played any games this session.");
            return;
        }

        Console.WriteLine("\nPrinting Game History:");
        foreach (var round in rounds)
            Console.WriteLine($"{round.Question} = {round.Result} (you answered: {round.UserAnswer}).");
    }

    public static void DisplayRoundResult(string question, int result, int answer)
    {
        Console.ForegroundColor = ConsoleColor.Black;
        if (answer == result)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("That was correct!");
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("That was incorrect!");
        }
        
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine($"The answer was: {question} = {result}");
    }

    public static void EndMessage()
    {
        Console.WriteLine("\nGame Over.");
        Console.WriteLine("Thank you for playing!");
    }
}