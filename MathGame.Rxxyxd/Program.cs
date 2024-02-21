//                              Methods to create
// 
// StartGame()
// GenerateNumbers(int[] numbers[], int questionsCount, bool isDivision = false)
// AdditionQuiz(int[] numbers)
// SubtractionQuiz(int[] numbers)
// MultiplicationQuiz(int[] numbers)
// DivisionQuiz(int[] numbers)
// AppendGameHistoryArray(string quizName, int score)
// GameHistory(string quizName = null)
//

using System.Runtime.CompilerServices;

string? userInput = "";
int menuOption;
bool inputIsValid;

do
{
    Console.WriteLine("\t\tMath Game");
    Console.WriteLine();
    Console.WriteLine("1.\tAddition");
    Console.WriteLine("2.\tSubtaction");
    Console.WriteLine("3.\tMultiplication");
    Console.WriteLine("4.\tDivision");
    Console.WriteLine("5.\t Game History");
    Console.WriteLine();
    Console.WriteLine("Select an option 1-5 or type 'exit': ");
    try
    {
        userInput = Console.ReadLine();

        if (userInput == null || userInput == "")
            throw new NullReferenceException("Menu option cannot be empty.");
            userInput = "";
        
        inputIsValid = int.TryParse(userInput, out menuOption);
        if (!inputIsValid)
        {
            throw new FormatException("Menu option must be an integral number between 1 and 5.");
        }
        
        try
        {
            StartGame(menuOption);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error has occured: {ex.Message}");
        }
    }
    catch (FormatException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        Thread.Sleep(1000);
    }
    catch (NullReferenceException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        Thread.Sleep(1000);
    }
} while (!String.Equals(userInput, "exit"));

void StartGame(int userSelection)
{
    switch (userSelection)
    {
        // Addition Quiz
        case 1:
            break;
        // Subtraction Quiz
        case 2:
            break;
        // Multiplication Quiz
        case 3:
            break;
        // Division Quiz
        case 4:
            break;
        // Game History
        case 5:
            break;
        // userSelection does not equal 1 through 5 (return to menu)
        default:
            break;
    }
}