namespace MathGame.Wolfieeex
{
    internal class MainMenu
    {
        internal void MainMenuFunctionality(string? name, DateTime date)
        {
            // Main menu functionality- show options and ask user for the input:
            Console.Write($"\n\r{new string('-', Console.BufferWidth)}");
            Console.WriteLine($@"Hello {name}! Today is {date}. What mode are you going to play? Choose one of the options listed below:
A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Ranodom Mode
E - Exit Game");
            Console.Write($"\r{new string('-', Console.BufferWidth)}");
            Console.Write($"\nYour option: ");

            // Read input and decide whether it's valid. If not, retry. If yes, select correct option to proceed to:
            string? userInput = null;
            bool mainProgramLoop = true;
            while (mainProgramLoop)
            {
                try
                {
                    // Check if input is valid:
                    userInput = Console.ReadLine();
                    Helpers.ReadInput(ref userInput, "You must select one of the options listed above to play the game or exit this application. What would you like to do: ");

                    // If option selected, check if it corresponds to any of the listed below and then run it:
                    switch (userInput.ToLower())
                    {
                        case "a":
                            break;
                        case "s":
                            break;
                        case "m":
                            break;
                        case "d":
                            break;
                        case "r":
                            break;
                        case "e":
                            mainProgramLoop = false;
                            break;
                        default:
                            
                            throw new InvalidOperationException($"\r\"{userInput}\" is not a valid input. Please select a correct option listed above: ");

                    }
                }
                catch (InvalidOperationException ex)
                {
                    Helpers.ReinsertLine(ex.Message);
                }
            }
        }
    }
}
