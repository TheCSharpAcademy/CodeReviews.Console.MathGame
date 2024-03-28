const string validMenuItems = "ASMDHQ";
// Generic string for reading user input
string? readResult;
// Menu item chosen by the user
char menuItemChosen;

Greetings();
DisplayMenu();
menuItemChosen = ChooseMenuItem();
MenuItemAction(menuItemChosen);

// Greets the user
void Greetings()
{
    Console.WriteLine("Welcome to the Math Game !\n");
}

// Displays the menu
void DisplayMenu()
{
    Console.WriteLine(@"Menu
----------
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

}

// Play Addition Game
void AdditionGame()
{

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

// Display the List containing the history of previous games played
void DisplayGameHistory()
{

}

// Saves the last game played in the List
void SaveGame()
{

}