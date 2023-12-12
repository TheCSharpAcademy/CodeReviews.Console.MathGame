using MathGameLibrary;

string name = Helper.GetString("Enter your name: ");

Console.WriteLine($"Hello, {name}. Welcome to the Math Game.");

List<GameModel> gameHistoryList = new List<GameModel>();

while (true)
{
    string choice = Helper.GetString(@"Please enter your choice:
    A. Addition
    S. Subtraction
    M. Multiplication
    D. Division
    H. History
    Q. Quit");


    switch (choice.Trim().ToLower())
    {
        case "a":
            gameHistoryList.Add(GameEngine.GameSession('+'));
            break;
        case "s":
            gameHistoryList.Add(GameEngine.GameSession('-'));
            break;
        case "m":
            gameHistoryList.Add(GameEngine.GameSession('*'));
            break;
        case "d":
            gameHistoryList.Add(GameEngine.GameSession('/'));
            break;
        case "h":
            GameEngine.ShowHistory(gameHistoryList);
            break;
        case "q":
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid choice! Press any key to try again.");
            Console.ReadLine();
            break;
    }    
}