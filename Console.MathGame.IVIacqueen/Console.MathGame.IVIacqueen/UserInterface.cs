using MathGame.Models;

namespace MathGame;

internal class UserInterface()
{
    private string? readResult;
    internal void MainMenu()
    {
        string mainMenuSelection;

        do
        {
            Console.Clear();

            mainMenuSelection = "";     // Resets menu selection for each loop

            // Ask user if they want to play the game, check history, or exit
            Console.WriteLine("Welcome to the Math Game app. Your main menu options are");
            Console.WriteLine("1. Play the game");
            Console.WriteLine("2. Check game history");
            Console.WriteLine("3. End the program\n");

            readResult = Console.ReadLine();
            if (readResult != null)
            {
                mainMenuSelection = readResult.Trim();
            }

            // Selects appropiate option based on user input
            switch (mainMenuSelection)
            {
                case "1":
                    PlayGame();
                    break;
                case "2":
                    ScoreHistory.CheckHistory();
                    break;
                case "3":
                    ExitGame();
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again. (Press enter to retry)");
                    Console.ReadLine();
                    break;
            }
        } while (mainMenuSelection != "3");
    }

    // Second menu to choose which operation to play with
    internal void PlayGame()
    {
        Console.Clear();

        // Ask user which operation they want to use
        Console.WriteLine("Choose which operation you wish to play with");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Substraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Random using all operations");
        Console.WriteLine(".. Enter anything else to go back\n");

        // Checks if input is not null
        readResult = Console.ReadLine();
        int operationIndex = ValidateInput(readResult); // Validates input and adjusts index

        // Goes to the next menu with the correct operation
        if (operationIndex >= (int)GameMode.Addition && operationIndex <= (int)GameMode.Random)
        {
            ChooseDifficulty((GameMode) operationIndex);
        }
    }

    internal void ChooseDifficulty(GameMode mode)
    {
        Console.Clear();

        // Ask user which difficulty they want to use
        Console.WriteLine("Choose which difficulty you wish to play with");
        Console.WriteLine("The higher the difficulty, the bigger the numbers used");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");
        Console.WriteLine(".. Enter anything else to go back\n");

        readResult = Console.ReadLine();
        int difficultyLevel = ValidateInput(readResult); // Validates input and adjusts index

        // Starts the game with the correct operation and difficulty
        if (difficultyLevel >= (int)GameDifficulty.Easy && difficultyLevel <= (int)GameDifficulty.Hard)
        {
            GameEngine.GameProcess(mode, (GameDifficulty) difficultyLevel);
        }
    }

    // Displays message for when user exits the game
    internal void ExitGame()
    {
        Console.WriteLine("Thank you for playing!");
        Console.ReadLine();
    }

    // Checks if user input is not null and returns an adjusted interger
    internal int ValidateInput(string result)
    {
        int index = -1; // Default index value

        if (result != null)
        {
            int.TryParse(result, out index);
            index--;       // Adjust operation index to match math game logic
        }

        return index;
    }
}