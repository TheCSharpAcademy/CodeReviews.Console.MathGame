namespace MathGame.Wolfieeex
{
    internal class Helpers
    {
        // Remove previous line and insert a new one instead:
        public static void ReinsertLine(string message)
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write($"\r{new string(' ', Console.BufferWidth)}");
            Console.Write("\r" + message);
        }

        // Prints message below the working area that will inform user they can return to a previous screen by pressing "E":
        public static void PrintExitPrompt()
        {
            int xCursorPosition = Console.CursorLeft;
            Console.SetCursorPosition(0, Console.CursorTop + 2);
            Console.Write($"\n\n{new string(' ', Console.BufferWidth)}");
            Console.Write("Press \"E\" - to return to a previous menu.");
            Console.SetCursorPosition(xCursorPosition, Console.CursorTop - 5);
        }

        // Reads user input and check if it's not empty or null. Optionally, compares it to array of options that are considered valid:
        /// <param name="failMessage">
        /// Message that will replace the previous input prompt on console if ReadLine method fails.
        /// </param>
        /// <param name="options">
        /// Array of elements that will be compared with the input parameter.
        /// </param>
        /// <param name="numberRange">
        /// An array of exactly 2 numbers. The first value represents minimal range, the second value maximal range.
        /// </param>
        public static void ReadInput(ref string? input, string failMessage, string[]? options = null, int[]? numberRange = null)
        {
            bool isValidLoop = true;
            while (isValidLoop)
            {
                try
                {
                    // Check for valid input:
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        throw new NullReferenceException(failMessage);
                    }

                    // If array of options was given, check if input matches any of the elements:
                    bool isOnList = true;
                    if (options != null)
                    {
                        isOnList = false;
                        foreach (string op in options)
                        {
                            if (op == input.ToLower())
                            {
                                isOnList = true;
                            }
                        }
                    }

                    // If array of extreme integers was given, check if value is a number and if it's in range. Consider the exit option in if checks:
                    if (numberRange != null)
                    {
                        int inputInt = 0;
                        bool isNumber = int.TryParse(input, out inputInt);
                        if (!isNumber && !isOnList)
                        {
                            throw new InvalidDataException("Your choice must be a number: ");
                        }
                        else if (isNumber && (inputInt < numberRange[0] || inputInt > numberRange[1]))
                        {
                            throw new InvalidDataException("Your choice must be in range of 1 and 20: ");
                        }
                    }
                    else
                    {
                        if (!isOnList)
                        {
                            throw new InvalidDataException(failMessage);
                        }

                        return;
                    }
                    isValidLoop = false;
                }
                catch (NullReferenceException ex)
                {
                    Helpers.ReinsertLine(ex.Message);
                }
                catch (InvalidDataException ex)
                {
                    Helpers.ReinsertLine(ex.Message);
                }
            }
        }
    }
}
