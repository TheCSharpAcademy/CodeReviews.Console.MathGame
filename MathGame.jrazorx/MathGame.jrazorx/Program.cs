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
H - History of previous games");
}

// Asks the user to choose a menu item
// returns user input
char ChooseMenuItem()
{
    return ' ';
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