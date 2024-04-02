// --------------------------------------------------
// CONSTANTS
// --------------------------------------------------

// Letters corresponding to valid menu items
const string validMenuItems = "ASMDHQ";

// --------------------------------------------------
// VARIABLES
// --------------------------------------------------

// Generic string for reading user input
string? readResult;

// Menu item chosen by the user
char menuItemChosen;

// game occurence
int gameOccurence = 0;
// last game data, to save in the list of previous games
string[] lastGameData = new string[4];
// List of previous games
List<string> gamesHistory = new List<string>();




// --------------------------------------------------
// EXECUTION
// --------------------------------------------------

Greetings();
while (true)
{
    DisplayMenu();
    menuItemChosen = ChooseMenuItem();
    MenuItemAction(menuItemChosen);

    Console.WriteLine("Press any key to return to the menu...");
    Console.ReadKey();
    Console.Clear();
}




// --------------------------------------------------
// METHODS
// --------------------------------------------------

// Greets the user
void Greetings()
{
    Console.WriteLine("Welcome to the Math Game !\n");
}

// Displays the menu
void DisplayMenu()
{
    Console.WriteLine(@"Menu
--------------------
A - Addition Game
S - Subtraction Game
M - Multiplication Game
D - Division Game
H - History of previous games
Q - Quit");
}

// returns a valid user selected menu item
char ChooseMenuItem()
{
    while (true)
    {
        readResult = Console.ReadLine();

        if (string.IsNullOrEmpty(readResult) || readResult.Trim().Length != 1)
        {
            Console.WriteLine("Please enter a letter corresponding to a menu item.");
            continue;
        }

        char menuItem = readResult.Trim().ToUpper()[0];
        if (validMenuItems.Contains(menuItem))
            return menuItem;
        else
            Console.WriteLine("Invalid option, please try again.");
    }
}

// Executes the action corresponding to the menu item chosen by the user
void MenuItemAction(char menuItemChosen)
{
    switch (menuItemChosen)
    {
        case 'A':
            lastGameData = AdditionGame();
            SaveGame(lastGameData);
            break;

        case 'S':
            lastGameData = SubtractionGame();
            SaveGame(lastGameData);
            break;

        case 'M':
            lastGameData = MultiplicationGame();
            SaveGame(lastGameData);
            break;

        case 'D':
            lastGameData = DivisionGame();
            SaveGame(lastGameData);
            break;

        case 'H':
            DisplayGameHistory(gamesHistory);
            break;

        default:
            Console.WriteLine("Goodbye");
            Environment.Exit(0);
            break;

    }
}

// Play Addition Game
string[] AdditionGame()
{
    Console.Clear();
    Console.WriteLine(@"Addition Game
--------------------");
    
    Random random = new Random();

    // The random numbers used for the game
    int firstNumber = random.Next(0, 10);
    int secondNumber = random.Next(0, 10);

    Console.WriteLine($"{firstNumber} + {secondNumber} = ?");

    int playerNumberAnswer = GetPlayerNumberAnswer();

    bool gameResult = winOrLose(playerNumberAnswer, firstNumber + secondNumber);

    return new string[] { "Addition", $"{firstNumber} + {secondNumber}", playerNumberAnswer.ToString(), gameResult ? "WIN" : "LOSE"};
}

// Play Subtraction Game
string[] SubtractionGame()
{
    Console.Clear();
    Console.WriteLine(@"Addition Game
--------------------");

    Random random = new Random();

    // The random numbers used for the game
    int firstNumber = random.Next(0, 10);
    int secondNumber = random.Next(0, 10);

    Console.WriteLine($"{firstNumber} - {secondNumber} = ?");

    int playerNumberAnswer = GetPlayerNumberAnswer();

    bool gameResult = winOrLose(playerNumberAnswer, firstNumber - secondNumber);

    return new string[] { "Subtraction", $"{firstNumber} - {secondNumber}", playerNumberAnswer.ToString(), gameResult ? "WIN" : "LOSE" };
}

// Play Multiplication Game
string[] MultiplicationGame()
{
    Console.Clear();
    Console.WriteLine(@"Addition Game
--------------------");

    Random random = new Random();

    // The random numbers used for the game
    int firstNumber = random.Next(0, 10);
    int secondNumber = random.Next(0, 10);

    Console.WriteLine($"{firstNumber} x {secondNumber} = ?");

    int playerNumberAnswer = GetPlayerNumberAnswer();

    bool gameResult = winOrLose(playerNumberAnswer, firstNumber * secondNumber);

    return new string[] { "Multiplication", $"{firstNumber} x {secondNumber}", playerNumberAnswer.ToString(), gameResult ? "WIN" : "LOSE" };
}

// Play Division Game
string[] DivisionGame()
{
    Console.Clear();
    Console.WriteLine(@"Addition Game
--------------------");

    Random random = new Random();

    // The random numbers used for the game
    int firstNumber;
    int secondNumber;
    do
    {
        firstNumber = random.Next(0, 101);
        secondNumber = random.Next(1, 101);
    } while (firstNumber % secondNumber != 0);

    Console.WriteLine($"{firstNumber} / {secondNumber} = ?");

    int playerNumberAnswer = GetPlayerNumberAnswer();

    bool gameResult = winOrLose(playerNumberAnswer, firstNumber / secondNumber);

    return new string[] { "Division", $"{firstNumber} / {secondNumber}", playerNumberAnswer.ToString(), gameResult ? "WIN" : "LOSE" };
}

// Get the player input for the answer of the game until it is a valid number
int GetPlayerNumberAnswer()
{
    while (true)
    {
        readResult = Console.ReadLine();
        try
        {
            return int.Parse(readResult.Trim());
        }
        catch (OverflowException)
        {
            Console.WriteLine("Invalid number : too big ! Please enter a valid number");
        }
        catch
        {
            Console.WriteLine("Please enter a valid number");
        }
    }
}

// Win (true) or lose (false) the game and displays a message
bool winOrLose(int playerNumberAnswer, int operationResult)
{
    if (playerNumberAnswer == operationResult)
    {
        Console.WriteLine("You win !");
        return true;
    }
    else
    {
        Console.WriteLine("You lose ...");
        Console.WriteLine($"The answer was {operationResult}");
        return false;
    }
}

/* Display the List containing the history of previous games played
Example :
#   | GAME           | CHALLENGE | ANSWER     | RESULT
99  | Multiplication | 100 x 100 |      10000 | WIN
100 | Addition       | 1 + 2     | 2000000000 | LOSE
*/
void DisplayGameHistory(List<string> gamesHistory)
{
    Console.Clear();
    Console.WriteLine("#   | GAME           | CHALLENGE | ANSWER     | RESULT");

    foreach (string game in gamesHistory)
    {
        Console.WriteLine(game);
    }
}

// Format the game data into a string for the history array to be displayed nicely on screen
string GameHistoryFormatLine(int gameOccurence, string[] lastGameData)
{
    string gamesHistoryLine = "";

    gamesHistoryLine += gameOccurence.ToString().PadRight(3) + " | ";
    gamesHistoryLine += lastGameData[0].PadRight(14) + " | ";
    gamesHistoryLine += lastGameData[1].PadRight(9) + " | ";
    gamesHistoryLine += lastGameData[2].PadLeft(10) + " | ";
    gamesHistoryLine += lastGameData[3];

    return gamesHistoryLine;
}

// Saves the last game played in the List
void SaveGame(string[] lastGameData)
{
    try
    {
        gameOccurence++;

        gamesHistory.Add(GameHistoryFormatLine(gameOccurence, lastGameData));
    }
    catch (OverflowException)
    {
        Console.WriteLine("You have reached the limit of games that can be saved in one session. From now on, games will not be saved in history");
    }
}