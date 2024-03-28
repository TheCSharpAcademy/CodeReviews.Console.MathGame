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




// --------------------------------------------------
// EXECUTION
// --------------------------------------------------

Greetings();
while (true)
{
    DisplayMenu();
    menuItemChosen = ChooseMenuItem();
    MenuItemAction(menuItemChosen);

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
            AdditionGame();
            break;

        case 'S':
            SubtractionGame();
            break;

        case 'M':
            MultiplicationGame();
            break;

        case 'D':
            DivisionGame();
            break;

        case 'H':
            DisplayGameHistory();
            break;

        default:
            Console.WriteLine("Goodbye");
            Environment.Exit(0);
            break;

    }
}

// Play Addition Game
void AdditionGame()
{
    // The 2 random numbers used for the game
    int[] gameNumbers = new int[2];
    Random random = new Random();

    gameNumbers[0] = random.Next(0, 10);
    gameNumbers[1] = random.Next(0, 10);

    Console.WriteLine($"{gameNumbers[0]} + {gameNumbers[1]} = ?");

    int playerNumberAnswer = GetPlayerNumberAnswer();

    if (playerNumberAnswer == gameNumbers[0] + gameNumbers[1])
        Console.WriteLine("You win !");
    else
        Console.WriteLine("You lose ...");
}

// Play Subtraction Game
void SubtractionGame()
{

}

// Play Multiplication Game
void MultiplicationGame()
{

}

// Play Division Game
void DivisionGame()
{

}

int GetPlayerNumberAnswer()
{
    return 0;
}

// Display the List containing the history of previous games played
void DisplayGameHistory()
{

}

// Saves the last game played in the List
void SaveGame()
{

}