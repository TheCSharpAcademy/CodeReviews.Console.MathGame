namespace MathGame.kmakai;

public class MathGameGame
{
    public List<Game> GamesPlayed { get; set; } = new List<Game>();
    public Game? CurrentGame { get; set; }

    public void run()
    {

        Console.WriteLine("Welcome to the Math Game!");
        while (true)
        {
            switch (GetOption())
            {
                case "1":
                    CurrentGame = new Game(Operation.Add);
                    break;
                case "2":
                    CurrentGame = new Game(Operation.Subtract);
                    break;
                case "3":
                    CurrentGame = new Game(Operation.Multiply);
                    break;
                case "4":
                    CurrentGame = new Game(Operation.Divide);
                    break;
                case "5":
                    CurrentGame = new Game((Operation)new Random().Next(0, 4));
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    return;
                case "7":
                    PrintGamesPlayed();
                    break;

            };


            if (CurrentGame != null)
            {
                Console.Clear();
                GamesPlayed.Add(CurrentGame);
                if (CurrentGame.Op == Operation.Divide)
                {
                    Console.WriteLine("Rounding to the nearest whole number.");
                }
                Console.WriteLine($"What is {CurrentGame?.NumberOne} {CurrentGame?.Op} {CurrentGame?.NumberTwo}?");
                Console.Write("Answer: ");
                string? answer = Console.ReadLine();

                while (answer == null || answer == "")
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    answer = Console.ReadLine();
                }

                CurrentGame.UserAnswer = int.Parse(answer);

                if (answer == CurrentGame.Answer.ToString())
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Incorrect! The correct answer is {CurrentGame.Answer}");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                CurrentGame = null;
                Console.Clear();
            }
        }
    }

    public void PrintGamesPlayed()
    {
        Console.Clear();
        Console.WriteLine("--------------Games Played---------------");
        foreach (Game game in GamesPlayed)
        {
            Console.WriteLine($"{game.NumberOne} {game.Op} {game.NumberTwo} = {game.Answer}");
            Console.WriteLine("Your answer: " + game.UserAnswer);
        }
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    public string GetOption()
    {

        Console.WriteLine("Please select an operation: ");
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Subtract");
        Console.WriteLine("3. Multiply");
        Console.WriteLine("4. Divide");
        Console.WriteLine("5. Random Game");
        Console.WriteLine("6. Exit");
        Console.WriteLine("7. See Games Played");
        Console.Write("Choice: ");
        string choice = Console.ReadLine();


        return choice;
    }

}


