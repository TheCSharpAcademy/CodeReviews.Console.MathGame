using MathsGame;

// Game parameters
const int MAX_ROUNDS = 2;
int[] difficulty = new int[2];
bool gameRunning = false;

// Game Log
List<string> gameLog = new List<string>();

// Run initial difficulty setting
GameFunctions.SetDifficulty(difficulty);

TheMenu();

void TheMenu()
{
    do
    {
        gameRunning = true;
        
        Console.WriteLine("---------- Maths Game ----------");
        Console.WriteLine("Select an option below by typing in the command line:\n");

        Console.WriteLine("! - Change Difficulty\n");

        Console.WriteLine("V - View Past Games\n");

        Console.WriteLine("A - Addition");
        Console.WriteLine("S - Subtraction");
        Console.WriteLine("M - Multiplication");
        Console.WriteLine("D - Division");
        Console.WriteLine("R - Random\n");

        Console.WriteLine("Q - Quit\n");

        string? result = Console.ReadLine();
        if (result == null)
        {
            Console.WriteLine("Input was null, exiting game.");
            Environment.Exit(1);
        }

        try
        {
            char userInput = Convert.ToChar(result.Trim().ToLower());
            if (Char.IsPunctuation(userInput))
            {
                switch (userInput)
                {
                    case '!':
                        GameFunctions.SetDifficulty(difficulty);
                        break;

                }
            }
            else if (Char.IsAsciiLetter(userInput))
            {
                switch (userInput)
                {
                    // Place an arguement in the main Game() function that can be used to determine what
                        // operations to use.
                    case 'a':
                        Games.Game("Addition", difficulty, MAX_ROUNDS, gameLog);
                        break;
                    case 'd':
                        Games.Game("Division", difficulty, MAX_ROUNDS, gameLog);
                        break;
                    case 'v':
                        GameFunctions.ViewLog(gameLog);
                        break;
                    case 'r':
                        Games.Game("Random", difficulty, MAX_ROUNDS, gameLog);
                        break;
                    case 'q':
                        gameRunning = false;
                        Environment.Exit(1);
                        break;
                }
            }
            else
            {

            }
        }
        catch (FormatException)
        {
            Console.WriteLine($"{result} has too many characters. Please only input one character.");
        }

    } while (gameRunning);
}
