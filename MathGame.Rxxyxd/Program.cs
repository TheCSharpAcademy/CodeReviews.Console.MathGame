/*
A math game that allows you to answer easy math questions with basic operators: + - * /. 
*/

using System.Data;

// Top level variables
string? userInput = "";
int menuOption;
bool inputIsValid;
bool exit = false;


// Main Menu
while (!exit)
{
    Console.WriteLine("\t\tMath Game");
    Console.WriteLine();
    Console.WriteLine("1.\tAddition");
    Console.WriteLine("2.\tSubtaction");
    Console.WriteLine("3.\tMultiplication");
    Console.WriteLine("4.\tDivision");
    Console.WriteLine("5.\tGame History");
    Console.WriteLine();
    Console.WriteLine("Select an option 1-5 or type 'exit': ");
    try
    {
        userInput = Console.ReadLine();

        if (userInput == null || userInput == "")
        {
            throw new NullReferenceException("Menu option cannot be empty."); // May need to change the exception that is thrown here for a more fitting one.

        }
        else if (userInput.ToLower() == "exit")
        {
            exit = true;
            continue;
        }
        inputIsValid = int.TryParse(userInput, out menuOption);
        if (!inputIsValid)
        {
            throw new FormatException("Menu option must be an integral number between 1 and 5.");
        }

        try
        {
            StartGame(menuOption); // Method is probably not needed. Could be removed in future commits.
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error has occured: {ex.Message}");
            Thread.Sleep(1000);
            Console.Clear();
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
}


void StartGame(int userSelection)
{
    // StartGame() Variables
    int questionCount;
    questionCount = QuestionCount();

    switch (userSelection)
    {
        // Addition Quiz
        case 1:
            Quiz(1, questionCount);
            break;
        // Subtraction Quiz
        case 2:
            Quiz(2, questionCount);
            break;
        // Multiplication Quiz
        case 3:
            Quiz(3, questionCount);
            break;
        // Division Quiz
        case 4:
            Quiz(4, questionCount);
            break;
        // Game History
        case 5:
            GameHistory();
            break;
        // userSelection does not equal 1 through 5 (return to menu)
        default:
            break;
    }
}

// Requests the user to input how many questions they would like to answer and returns it as an integer.
int QuestionCount()
{
    // QuestionCount() Variables
    int questionCount = 0;
    string? userInput;

    do
    {
        inputIsValid = false;
        Console.WriteLine("How many questions would you like to answer?");
        try
        {
            userInput = Console.ReadLine();
            if (userInput == "" || userInput == "")
            {
                throw new NullReferenceException("Question Count must not be null.");
            }
            else if (!int.TryParse(userInput, out questionCount))
            {
                throw new FormatException("Question count must be an integral number.");
            }
            else
            {
                inputIsValid = true;
            }
        }
        catch (NullReferenceException ex) { Console.WriteLine($"Error: {ex.Message}"); }
        catch (FormatException ex) { Console.WriteLine($"Error: {ex.Message}"); }
    } while (inputIsValid == false);
    return questionCount;
}

/*
Possible mode values are as follows:

1 - Addition
2 - Subtraction
3 - Multiplication
4 - Division

I also threw an exception if the argument is of range.
I feel like this method has a lot of repeated code. Probably could be simplified.

*/
void Quiz(int mode, int questionCount)
{
    int answer;
    int userAnswer;
    bool inputIsValid;
    int score = 0;
    if (mode >= 5)
    {
        throw new ArgumentOutOfRangeException($"{mode} is not a valid mode.\n Possible Modes are: 1 - Addition\n2 - Subtraction\n3 - Multiplication\n4 - Division");
    }
    else
    {
        switch (mode)
        {
            case 1: // addition
                // #1 Generates Numbers for the questions with GenerateNumbers() Method
                int[] numbers = GenerateNumbers(questionCount);
                /*
                #2 Loops through numbers Array, displaying each question until i is equal to questionCount integer.
                The do-while loop is for input validation. I think there may be a better approach for this.
                This comment can be applied to cases 1 through 3.
                */
                for (int i = 0; i != questionCount * 2; i += 2)
                {
                    do
                    {
                        Console.Clear();
                        inputIsValid = false;
                        answer = numbers[i] + numbers[i + 1];
                        Console.WriteLine($"{numbers[i]} + {numbers[i + 1]}");
                        userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out userAnswer))
                        {
                            inputIsValid = true;
                            score = CheckAnswer(userAnswer, answer, score);
                        }
                        else
                            continue;
                    } while (inputIsValid == false);
                }
                Console.WriteLine($"You got {score}/{questionCount}");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                break;
            case 2: // subtraction
                numbers = GenerateNumbers(questionCount);
                for (int i = 0; i != questionCount * 2; i += 2)
                {
                    do
                    {
                        Console.Clear();
                        inputIsValid = false;
                        answer = numbers[i] - numbers[i + 1];
                        Console.WriteLine($"{numbers[i]} - {numbers[i + 1]}");
                        userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out userAnswer))
                        {
                            inputIsValid = true;
                            score = CheckAnswer(userAnswer, answer, score);
                        }
                        else
                            continue;
                    } while (inputIsValid == false);
                }
                Console.WriteLine($"You got {score}/{questionCount}");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                break;
            case 3: // Multiplication
                numbers = GenerateNumbers(questionCount);
                for (int i = 0; i != questionCount * 2; i += 2)
                {
                    do
                    {
                        Console.Clear();
                        inputIsValid = false;
                        answer = numbers[i] * numbers[i + 1];
                        Console.WriteLine($"{numbers[i]} x {numbers[i + 1]}");
                        userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out userAnswer))
                        {
                            inputIsValid = true;
                            score = CheckAnswer(userAnswer, answer, score);
                        }
                        else
                            continue;
                    } while (inputIsValid == false);
                }
                Console.WriteLine($"You got {score}/{questionCount}");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                break;
            case 4: // Division - TODO
                break;
        }
    }
}

// Simple method for scoring and checking that answer and UserInput are equal.
int CheckAnswer(int userAnswer, int answer, int score)
{
    if (userAnswer == answer)
    {
        Console.WriteLine("Correct! +1 score!");
        Thread.Sleep(1000);
        return score+1;
    }
    else
    {
        Console.WriteLine("Incorrect.");
        Thread.Sleep(1000);
        return score;
    }
}
// generates numbers for quizes 
int[] GenerateNumbers(int questionCount, bool isDivision = false)
{
    Random random = new Random();
    int[] generatedNumbers = new int[questionCount * 2];
    if (isDivision)
    {
        // TODO
    }

    else
    {
        for (int i = 0; i != (questionCount * 2); i++)
        {
            generatedNumbers[i] = random.Next(1, 10);
        }
    }
    return generatedNumbers;
}

// displays game history - TODO
void GameHistory()
{

}