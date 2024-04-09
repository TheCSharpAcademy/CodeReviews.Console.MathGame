//Initialization of a variable to be used for generating random numbers in the game.
using System.Security.Cryptography.X509Certificates;

Random randomNumbers = new();

//Declaration of variables for storing generated random numbers and the answers to specific mathematical expressions.
int x, y, answerToProblem;

//This list will store the details of each game played, including the mathematical expression, the correct answer, the input of the player, and whether the answer is correct or incorrect. A storage of past games.
List<List<string>> gameHistory = [];

//Boolean flags to see if user input is valid (validInput) and if the user is done using the program (isDone).
bool validInput = false;
bool isDone = false;

//Storage for any user input from the console.
string? userInput;


//Implementation of a do-while loop to determine whether the user wants to continue playing or not.
do
{
    //Game menu
    Console.Clear();
    Console.WriteLine("Welcome to MATH GAME!\n");
    Console.WriteLine("Choose what type of game you want to play. Type 'exit' to close the program: ");
    Console.WriteLine("1. Multiplication");
    Console.WriteLine("2. Division");
    Console.WriteLine("3. Addition");
    Console.WriteLine("4. Subtraction");
    Console.WriteLine("5. Game History\n");

    userInput = Console.ReadLine();

    //Check if 'userInput' has value.
    if (userInput != null)
    {
        //Closes the program if the user types 'exit'.
        if (userInput.ToLower() == "exit")
        {
            isDone = true;
        }

        //Checks if the user input is a number by converting 'userInput' to an integer, which is then stored inside the 'chosenGame' variable.
        validInput = int.TryParse(userInput, out int chosenGame);

        if (validInput)
            //The use of switch-case makes the logic of the game easier to implement. In each case, except for the last one, a title is added to the 'gameHistory' list, followed by calling a method corresponding to the user's chosen operation to play.
            switch (chosenGame)
            {
                case 1:
                    gameHistory.Add(["Multiplication"]); //Add title.
                    Multiplication(); //Call method.
                    break;

                case 2:
                    gameHistory.Add(["Division"]); //...
                    Division(); //...
                    break;

                case 3:
                    gameHistory.Add(["Addition"]); //...
                    Addition(); //...
                    break;

                case 4:
                    gameHistory.Add(["Subtraction"]); //...
                    Subtraction();
                    break; //...

                case 5:
                    ShowHistory(); // Call method to show game history.
                    break;
            }
    }

} while (isDone == false); //Continuously checks if the user is done with the program or not.

//A method to deal with the logic of multiplying two numbers.
void Multiplication()
{
    //A placeholder used when the game starts, then change when the user answers the expression given, either 'Correct' or 'Incorrect'.
    string answerStatement = "Enter the correct answer";

    //A loop that iterates five times to simulate the changing of questions, each occurring five times.
    for (int i = 0; i < 5; i++)
    {
        //Clears the interface to simulate animation of the change of number of the question and the placeholder.
        Console.Clear();
        Console.WriteLine($"Multiplication({i + 1}/5) - {answerStatement}!");

        //Generate random numbers assigned to 'x' and 'y', ranging from 0 to 100.
        x = GenerateRandomNumber();
        y = GenerateRandomNumber();

        answerToProblem = x * y; //Store the answer to 'answerToProblem' variable.
        Console.WriteLine($"{x} x {y}"); //Prints the problem to the console.

        //Call the 'CheckAnswer()' method, passing 'x', 'y', 'answerToProblem', and the character representing the operation being played by the player. The method returns a string, either 'Correct' or 'Incorrect', which is stored in the 'answerStatement' variable.
        answerStatement = CheckAnswer(x, 'x', y, answerToProblem);
    }

    Console.Clear(); //Clears the console after the loop is finished to display the final result.
    Console.WriteLine($"Multiplication(5/5) - {answerStatement}!");

    Console.WriteLine("\n\rPress Enter to return to the Main menu.");
    Console.ReadLine(); //Waits for user input.
}


//A method to deal with the logic of dividing two numbers.
void Division()
{
    string answerStatement = "Enter the correct answer";

    for (int i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine($"Division({i + 1}/5) - {answerStatement}!");

        //This loop continuously updates the values assigned to 'x' and 'y'. This update depends on whether 'y' is greater than 'x' or if the division of 'x' by 'y' results in a remainder, ensuring that the answer remains an integer.
        do
        {
            x = GenerateRandomNumber();
            y = GenerateRandomNumber();

            //This loop ensures that the value assigned to 'y' is not zero. Dividing a number with a zero result to an error.
            while (y == 0)
            {
                y = GenerateRandomNumber();
            }

        } while (y > x || x % y != 0);

        answerToProblem = x / y;
        Console.WriteLine($"{x} / {y}");

        answerStatement = CheckAnswer(x, '/', y, answerToProblem);
    }

    Console.Clear();
    Console.WriteLine($"Division(5/5) - {answerStatement}!");
    Console.WriteLine("\n\rPress Enter to return to the Main menu.");
    Console.ReadLine();
}

//A method to deal with the logic of adding two numbers.
void Addition()
{
    string answerStatement = "Enter the correct answer";

    for (int i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine($"Addition({i + 1}/5) - {answerStatement}!");
        x = GenerateRandomNumber();
        y = GenerateRandomNumber();
        answerToProblem = x + y;

        Console.WriteLine($"{x} + {y}");

        answerStatement = CheckAnswer(x, '+', y, answerToProblem);
    }

    Console.Clear();
    Console.WriteLine($"Addition(5/5) - {answerStatement}!");
    Console.WriteLine("\n\rPress Enter to return to the Main menu.");
    Console.ReadLine();
}

//A method that deals with the logic of subtracting two numbers.
void Subtraction()
{
    string answerStatement = "Enter the correct answer";

    for (int i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine($"Subtraction({i + 1}/5) - {answerStatement}!");
        x = GenerateRandomNumber();
        y = GenerateRandomNumber();

        answerToProblem = x - y;
        Console.WriteLine($"{x} - {y}");

        answerStatement = CheckAnswer(x, '-', y, answerToProblem);
    }

    Console.Clear();
    Console.WriteLine($"Subtraction(5/5) - {answerStatement}!");
    Console.WriteLine("\n\rPress Enter to return to the Main menu.");
    Console.ReadLine();
}

//A method that generates random integers within the range of 0 to 100.
int GenerateRandomNumber()
{
    return randomNumbers.Next(0, 101);
}

//A method that prints out the entire game history, including details such as mathematical expressions, correct answers, and user responses.
void ShowHistory()
{
    Console.Clear();
    Console.WriteLine("Game History:\n"); //Print title

    //This if-else statement checks whether 'gameHistory' has any items stored in it. If it does, the if-block below is executed. Otherwise, it prints out 'No history.'
    if (gameHistory.Count != 0)
    {
        Console.WriteLine("\t\tExpression\t\tAnswer\t\tEvaluation\t\tYour Answer");

        //A nested foreach loop is used to iterate through each list in 'gameHistory', and within each inner list, iterate through and print each item.
        foreach (var row in gameHistory)
        {
            //Checks if the item inside the 'row' variable is not a single item.
            if (row.Count != 1)
            {
                Console.Write("\t\t"); //Prints a tab escape sequence.
            }

            foreach (var element in row)
            {
                if (row.Count == 1)
                {
                    Console.Write(element); //Prints out the operation as title.
                }
                else
                {
                    Console.Write(element + "\t\t"); //Prints out the expression, the correct answer, the evaluation of the user's answer, and the user's answer.
                }
            }
            Console.WriteLine();
        }
    }
    else
        Console.WriteLine("No history."); //Prints if 'gameHistory' is empty.

    Console.WriteLine("\n\rPress Enter to return to the Main menu.");
    Console.ReadLine();
}

//A method that prompts the user for input as the answer, compares the user's answer to the 'answerToProblem', and returns either 'Correct' or 'Incorrect'. It also ensures that the length of the expression is fixed to 10 characters before printing to avoid broken lines.
string CheckAnswer(int x, char ope, int y, int answerToProblem)
{
    int userAnswer = 0; //Initialization of a variable to store the user's answer.

    string answerStatement = ""; //Initialization of a string variable to store either 'Correct' or 'Incorrect'.

    do
    {
        userInput = Console.ReadLine(); //Waits for user input.
        validInput = int.TryParse(userInput, out userAnswer);

        if (validInput)
        {
            if (userAnswer == answerToProblem)
            {
                answerStatement = "Correct"; //Assign 'Correct' if equal.
            }
            else
                answerStatement = "Incorrect"; //Assign 'Incorrect' if not equal.
        }
        else //If the input is not valid.
        {
            Console.WriteLine("Please enter a number!"); 
            validInput = false;
        }

    } while (validInput == false);

    string expression = $"{x} {ope} {y}"; //Store as expression.

    //Checks if the length of the 'expression' is 10.
    int lengthDifference = 10 - expression.Length;
    if (lengthDifference != 0)
    {
        expression += string.Concat(Enumerable.Repeat(" ", lengthDifference)); //Add spaces to the expression based on the difference in length between the 'expression' and 10 characters.
    }

    gameHistory.Add([expression, $"{answerToProblem}", answerStatement + "  ", $"{userAnswer}"]); //Append to 'gameHistory' the expression, the correct answer, the evaluation, and the user's answer.

    return answerStatement;
}