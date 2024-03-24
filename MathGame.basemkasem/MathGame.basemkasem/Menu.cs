namespace MathGame.basemkasem;

internal class Menu
{
    GameEngine engine = new();
    internal void ShowMenu(string? name)
    {
        Console.WriteLine($"Hello, {name}! It's {DateTime.UtcNow}. This is your math's game.");
        Console.WriteLine("-----------------------------------------------------------------");
        Console.ReadLine();

        bool isGameOn = true;
        do
        {
            Console.Clear();
            Console.WriteLine("What game do you want to play today? Choose one option of the following:");
            Console.WriteLine("1. (+) Addition.");
            Console.WriteLine("2. (-) Subtraction.");
            Console.WriteLine("3. (*) Multiplication.");
            Console.WriteLine("4. (/) Division.");
            Console.WriteLine("5. History of privious games.\n ");
            Console.WriteLine("Write \"exit\" to close the game. ");


            var menuSelection = Console.ReadLine();

            switch (menuSelection.Trim().ToLower())
            {
                case "1":
                    engine.AdditionGame("Addition game selected");
                    break; //Addition
                case "2":
                    engine.SubtractionGame("Subtraction game selected");
                    break; //Subtraction
                case "3":
                    engine.MultiplicationGame("Multiplication game selected");
                    break; //Multiplication
                case "4":
                    engine.DivisionGame("division game selected");
                    break; //Division       
                case "5":
                    Helpers.PrintGames();
                    break;
                case "exit":
                case "e":
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("You entered a wrong value. Please try again.\n");
                    break;
            }
        } while (isGameOn);
    }
}
