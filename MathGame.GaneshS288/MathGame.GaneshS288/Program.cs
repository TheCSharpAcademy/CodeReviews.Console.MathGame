using MathGame;

Random random = new Random();
Menu menu = new Menu();
GameEngine gameEngine = new GameEngine();

List<string> gameRecords = new List<string>();

int index;
string? userInput;
bool isValidInput;

do
{
    menu.PrintGameSelection();

    userInput = Console.ReadLine()?.Trim();

    int checkInput;
    isValidInput = int.TryParse(userInput, out checkInput);

    if (userInput == "0")
        break;

    //randomize the selected game
    else if (userInput == "5")
    {
        userInput = $"{random.Next(1, 5)}";
        StartGameEngine();
    }

    else if (userInput == "6")
        gameEngine.DisplayGameRecords();

    else if (checkInput < 0 && checkInput > 6 || isValidInput == false)
    {
        Console.WriteLine("Please enter a valid value");
        Console.ReadLine();
    }

    else
        StartGameEngine();
}
while (userInput != "0");



void StartGameEngine()
{

    isValidInput = int.TryParse(userInput, out index);

    while (userInput != "exit")
    {
        userInput = gameEngine.PlayGame(userInput, index);
    }

}