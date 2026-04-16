using MathGame;

Console.WriteLine("Welcome to Math Game!");

var quiz = new Quiz();

int counter = 0;
string? userInput = null;
while (counter < 5)
{
    MenuOptions menuChoice = SelectOperationMenu();
    if (menuChoice == MenuOptions.Exit)
    {
        break;
    }
    else if (menuChoice == MenuOptions.History)
    {
        quiz.PrintHistory();
        Console.WriteLine("\n");
        continue;
    }

    string currentProblem = quiz.GenerateQuestion((int)menuChoice);
    int userAnswer = 0;

    do
    {
        Console.WriteLine(currentProblem);
        Console.Write("Enter your answer: ");
        userInput = Console.ReadLine();
    } while (!int.TryParse(userInput, out userAnswer));

    if (quiz.VerifyAnswer(userAnswer))
    {
        Console.WriteLine("The answer was correct!");
    }
    else
    {
        Console.WriteLine("The answer was incorrect!");
    }

    counter++;
    Console.WriteLine("\n");
}

Console.WriteLine($"Your final score is {quiz.Score}");
Console.WriteLine("Thank you for playing!");


static MenuOptions SelectOperationMenu()
{
    Console.WriteLine("Select an operation:");
    foreach (var menuOption in Enum.GetValues(typeof(MenuOptions)))
    {
        Console.WriteLine($"{(int)menuOption}. {menuOption}");
    }

    string? userInput = null;
    MenuOptions menuChoice;
    do
    {
        Console.Write("Enter your choice: ");
        userInput = Console.ReadLine();
    }
    while (!(Enum.TryParse(userInput, out menuChoice) && Enum.IsDefined(menuChoice)));

    return menuChoice;
}

public enum MenuOptions
{
    Addition = 1,
    Subtraction = 2,
    Multiplication = 3,
    Division = 4,
    History = 5,
    Exit = 6,
};
