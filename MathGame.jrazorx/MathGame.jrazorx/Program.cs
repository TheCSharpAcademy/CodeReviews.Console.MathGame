using MathGame.jrazorx;

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

// current Game object
Game currentGame;




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
        case 'S':
        case 'M':
        case 'D':
            currentGame = new Game(menuItemChosen);
            currentGame.Play();
            SaveGame(currentGame);
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
string GameHistoryFormatLine(int gameOccurence, Game currentGame)
{
    string gamesHistoryLine = "";

    gamesHistoryLine += gameOccurence.ToString().PadRight(3) + " | ";
    gamesHistoryLine += currentGame.Mode.PadRight(14) + " | ";
    gamesHistoryLine += currentGame.Operation.PadRight(9) + " | ";
    gamesHistoryLine += currentGame.PlayerAnswer.ToString().PadLeft(10) + " | ";
    gamesHistoryLine += currentGame.IsWin ? "WIN" : "LOSE";

    return gamesHistoryLine;
}

// Saves the last game played in the List
void SaveGame(Game currentGame)
{
    try
    {
        gameOccurence++;

        gamesHistory.Add(GameHistoryFormatLine(gameOccurence, currentGame));
    }
    catch (OverflowException)
    {
        Console.WriteLine("You have reached the limit of games that can be saved in one session. From now on, games will not be saved in history");
    }
}