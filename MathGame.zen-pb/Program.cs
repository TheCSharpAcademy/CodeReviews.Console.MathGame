Random randomNumbers = new();

int x, y, answerToProblem;

List<List<string>> gameHistory = [];

bool validInput = false;
bool isDone = false;

string? userInput;

do
{
    Console.Clear();
    Console.WriteLine("Welcome to MATH GAME!\n");
    Console.WriteLine("Choose what type of game you want to play. Type 'exit' to close the program: ");
    Console.WriteLine("1. Multiplication");
    Console.WriteLine("2. Division");
    Console.WriteLine("3. Addition");
    Console.WriteLine("4. Subtraction");
    Console.WriteLine("5. Game History\n");

    userInput = Console.ReadLine();

    if (userInput != null)
    {
        if (userInput.ToLower() == "exit")
        {
            isDone = true;
        }

        validInput = int.TryParse(userInput, out int chosenGame);

        if (validInput)
            switch (chosenGame)
            {
                case 1:
                    gameHistory.Add(["Multiplication"]);
                    Multiplication();
                    break;

                case 2:
                    gameHistory.Add(["Division"]);
                    Division();
                    break;

                case 3:
                    gameHistory.Add(["Addition"]);
                    Addition();
                    break;

                case 4:
                    gameHistory.Add(["Subtraction"]);
                    Subtraction();
                    break;

                case 5:
                    ShowHistory();
                    break;
            }
    }

} while (isDone == false);

void Multiplication()
{
    string answerStatement = "Enter the correct answer";

    for (int i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine($"Multiplication({i + 1}/5) - {answerStatement}!");
        x = GenerateRandomNumber();
        y = GenerateRandomNumber();

        answerToProblem = x * y;
        Console.WriteLine($"{x} x {y}");

        answerStatement = CheckAnswer(x, 'x', y, answerToProblem);


    }

    Console.Clear();
    Console.WriteLine($"Multiplication(5/5) - {answerStatement}!");
    Console.WriteLine("\n\rPress Enter to return to the Main menu.");
    Console.ReadLine();
}

void Division()
{
    string answerStatement = "Enter the correct answer";

    for (int i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine($"Division({i + 1}/5) - {answerStatement}!");

        do
        {
            x = GenerateRandomNumber();
            y = GenerateRandomNumber();

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

int GenerateRandomNumber()
{
    return randomNumbers.Next(0, 101);
}

void ShowHistory()
{
    Console.Clear();
    Console.WriteLine("Game History:\n");

    if (gameHistory.Count != 0)
    {
        Console.WriteLine("\t\tExpression\t\tAnswer\t\tEvaluation\t\tYour Answer");

        foreach (var row in gameHistory)
        {
            if (row.Count != 1)
            {
                Console.Write("\t\t");
            }

            foreach (var element in row)
            {
                if (row.Count == 1)
                {
                    Console.Write(element);
                }
                else
                {
                    Console.Write(element + "\t\t");
                }
            }
            Console.WriteLine();
        }
    }
    else
        Console.WriteLine("No history.");

    Console.WriteLine("\n\rPress Enter to return to the Main menu.");
    Console.ReadLine();
}

string CheckAnswer(int x, char ope, int y, int answerToProblem)
{
    int userAnswer = 0;

    string answerStatement = "";

    userInput = Console.ReadLine();

    if (userInput != null)
    {
        validInput = int.TryParse(userInput, out userAnswer);

        if (userAnswer == answerToProblem)
        {
            answerStatement = "Correct";
        }
        else
            answerStatement = "Incorrect";
    }

    string expression = $"{x} {ope} {y}";

    int lengthDifference = 10 - expression.Length;

    if (lengthDifference != 0)
    {
        expression += string.Concat(Enumerable.Repeat(" ", lengthDifference));
    }

    gameHistory.Add([expression, $"{answerToProblem}", answerStatement + "  ", $"{userAnswer}"]);

    return answerStatement;
}