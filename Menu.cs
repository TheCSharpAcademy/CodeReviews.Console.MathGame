namespace MathGame
{
    internal class Menu
    {
        internal void ShowMenu(string name)
        {
            Console.WriteLine("\nHello " + name + "! Welcome to the Math Quiz!");
            bool exit = true;
            GameEngine gameEngine = new GameEngine();
            while (exit)
            {

                Console.WriteLine("Choose the operation you want to practice: ");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. View Scores");
                Console.WriteLine("6. Exit");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1: gameEngine.Addition(); break;
                        case 2: gameEngine.Subtraction(); break;
                        case 3: gameEngine.Multiplication(); break;
                        case 4: gameEngine.Division(); break;
                        case 5: Helpers.ViewScores(); break;
                        case 6:
                            Console.WriteLine("Goodbye!");
                            exit = false;
                            break;
                        default: Console.WriteLine("Invalid choice!"); break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
