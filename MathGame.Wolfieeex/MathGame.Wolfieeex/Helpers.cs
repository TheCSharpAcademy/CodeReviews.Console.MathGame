using MathGame.Wolfieeex.Models;

namespace MathGame.Wolfieeex;

internal class Helpers
{
    // List of all played games (if selected true, it assigns starter data to recorded games for code checks):
    private static bool runTest = false;
    public static List<GameInstance> GameInstances = !runTest ? new List<GameInstance>() : new List<GameInstance>
    {
        new GameInstance{Name = "Aleks", Date = DateTime.Now.AddDays(1), Score = 4, Type = GameModes.Subtraction, Difficulty = GameDifficulty.Moderate, QuestionsCount = 8, Time = 5},
        new GameInstance{Name = "Anastazja", Date = DateTime.Now.AddDays(0), Score = 5, Type = GameModes.Addition, Difficulty = GameDifficulty.Hard, QuestionsCount = 6, Time = 50},
        new GameInstance{Name = "Bozena", Date = DateTime.Now.AddDays(0), Score = 6, Type = GameModes.Addition, Difficulty = GameDifficulty.Easy, QuestionsCount = 10, Time = 100},
        new GameInstance{Name = "Julie", Date = DateTime.Now.AddDays(2), Score = 10, Type = GameModes.Addition, Difficulty = GameDifficulty.Moderate, QuestionsCount = 20, Time = 200},
        new GameInstance{Name = "Kristine", Date = DateTime.Now.AddDays(3), Score = 20, Type = GameModes.Multiplication, Difficulty = GameDifficulty.Easy, QuestionsCount = 20, Time = 100},
        new GameInstance{Name = "Pawel", Date = DateTime.Now.AddDays(-9), Score = 2, Type = GameModes.Random, Difficulty = GameDifficulty.Easy, QuestionsCount = 6, Time = 30},
        new GameInstance{Name = "Pete", Date = DateTime.Now.AddDays(14), Score = 1, Type = GameModes.Addition, Difficulty = GameDifficulty.Moderate, QuestionsCount = 3, Time = 35},
        new GameInstance{Name = "Ana", Date = DateTime.Now.AddDays(8), Score = 0, Type = GameModes.Subtraction, Difficulty = GameDifficulty.Hard, QuestionsCount = 5, Time = 95},
    };

    // Remove previous line and insert a new one instead:
    public static void ReinsertLine(string message)
    {
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write($"\r{new string(' ', Console.BufferWidth)}");
        Console.Write("\r" + message);
    }

    // Prints message below the working area that will inform user they can return to a previous screen by pressing "E"
    // (custom message can be added):
    public static void PrintExitPrompt(string message = "Press \"E\" - to return to a previous menu.")
    {
        int xCursorPosition = Console.CursorLeft;
        Console.SetCursorPosition(0, Console.CursorTop + 2);
        Console.Write($"\n\n{new string(' ', Console.BufferWidth)}");
        Console.Write(message);
        Console.SetCursorPosition(xCursorPosition, Console.CursorTop - 5);
    }

    // Reads user input and check if it's not empty or null. Optionally, compares it to array of options that are considered valid.
    // Runs in loop until the user input is considered correct:
    /// <param name="failMessage">
    /// Message that will replace the previous input prompt on console if ReadLine method fails.
    /// </param>
    /// <param name="options">
    /// Array of elements that will be compared with the input parameter.
    /// </param>
    /// <param name="numberRange">
    /// An array of exactly 2 numbers. The first value represents minimal range, the second value maximal range.
    /// </param>
    /// /// <param name="notInRangeFailMessage">
    /// Message displayed if number is not in range.
    /// </param>
    public static void ReadInput(ref string? input, string failMessage, string[]? options = null, int[]? numberRange = null, string? notInRangeFailMessage = "")
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

                // If array of extreme integers was given, check if value is a number and if it's in range. Consider the exit option in "if" checks:
                if (numberRange != null)
                {
                    int inputInt = 0;
                    bool isNumber = int.TryParse(input, out inputInt);
                    if (!isNumber && !isOnList)
                    {
                        throw new InvalidDataException($"{notInRangeFailMessage}(Your choice must be a valid, short number): ");
                    }
                    else if (isNumber && (inputInt < numberRange[0] || inputInt > numberRange[1]))
                    {
                        throw new InvalidDataException($"{notInRangeFailMessage}(Your number must be in range of {numberRange[0]} and {numberRange[1]}): ");
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

    // Called from the MainMenu class under PreviousGames screen selection:
    public static void DisplayPreviousGames()
    {
        // Display the header:
        Console.Clear();
        Console.WriteLine("Previous games: ");
        Console.WriteLine($"{new string('-', Console.BufferWidth)}");

        // Query each GameInstance by its mode sorting them descending by score value:
        for (int i = 0; i < 5; i++)
        {
            // Try to get the list of games with certain mode. If there are no games with certain mode, skip the iteration and 
            // continue checking for other modes. Game order that is displayed is sorted by highest scores first:
            List<GameInstance> currentInstance;
            try
            {
                currentInstance = GameInstances.Where(x => (int)x.Type == i).OrderByDescending(x => x.Score).ToList();
                if (currentInstance == null || currentInstance.Count == 0)
                    throw new NullReferenceException();
            }
            catch (NullReferenceException ex)
            {
                continue;
            }

            // Write all games that were played withe seperate headers for each game mode:
            Console.WriteLine($"Previous {Enum.GetName(currentInstance[0].Type).ToLower()} games:");
            Console.WriteLine($"{new string('.', 40)}");
            Console.WriteLine(new string("Name:").PadRight(30) + new string("Date: ").PadRight(30) + new string("Difficulty:").PadRight(20) + new string("Score:").PadRight(10) + new string("Out of:").PadRight(10) + new string("Total time:").PadRight(10) + "\n");
            foreach (GameInstance instance in currentInstance)
            {
                Console.WriteLine(instance.Name.PadRight(30) + instance.Date.ToString().PadRight(30) + Enum.GetName(instance.Difficulty).PadRight(20) + instance.Score.ToString().PadRight(10) + instance.QuestionsCount.ToString().PadRight(10) + (instance.Time.ToString() + " seconds").PadRight(15));
            }
            Console.WriteLine($"{new string('-', Console.BufferWidth)}");
        }
        // After displaying the table, promt exit to main menu: 
        Console.Write("\n\n\nPress Enter to return to back menu: ");
        Console.ReadLine();
    }
}
