namespace MathGame.Matija87;

public class Menu
{
    internal void DisplayMenu(string name, DateTime dateTime)
    {
        char gameSelected;
        bool isGameOn = true;

        Console.Clear();
        Console.WriteLine($"Hi {name}! Welcome to Math Game!");
        Console.WriteLine($"Today is {dateTime}");
        Console.WriteLine("Press any key to start the game!");
        Console.ReadKey();
        
        do
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine(@"Choose your game: 
View Previous Games (V)
Addition (A)
Subtraction (S)
Multiplication (M)
Division (D)
Quit (Q)");

            bool correctInput = false;
            do
            {
                Console.WriteLine("-------------------------------------------------------");
                gameSelected = Console.ReadKey().KeyChar;
                gameSelected = Char.ToLower(gameSelected);
                Console.WriteLine();
                switch (gameSelected)
                {
                    case 'v':
                        Helpers.GetGames();
                        correctInput = true;
                        break;
                    case 'a':
                        GameEngine.Addition();
                        correctInput = true;
                        break;
                    case 's':
                        GameEngine.Subtraction();
                        correctInput = true;
                        break;
                    case 'm':
                        GameEngine.Multiplication();
                        correctInput = true;
                        break;
                    case 'd':
                        GameEngine.Division();
                        correctInput = true;
                        break;
                    case 'q':
                        Console.WriteLine("Thanks for playing!");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Wrong selection! Try again!");
                        break;
                }
            } while (!correctInput && isGameOn);

        } while (isGameOn);
    }
}
