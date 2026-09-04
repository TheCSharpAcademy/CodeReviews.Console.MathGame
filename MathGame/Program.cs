//Variables
using System.Diagnostics;

var quiz = new List<(string Text, string Answer)>();

//Main program
Console.WriteLine("Welcome to the Math Game!\n");

PlayGame();

//Main Methods
void PlayGame()
{
    int difficulty = 0;

    while (difficulty != 6)
    {

        Console.WriteLine();
        Console.WriteLine("Starting the math game, please select a difficulty level:");
        Console.WriteLine("1. Easy, 1 minute per question");
        Console.WriteLine("2. Medium, 30 seconds per question");
        Console.WriteLine("3. Hard, 10 seconds per question");
        Console.WriteLine("4. Expert, random questions and 5 seconds per question");
        Console.WriteLine("5. View all the results");
        Console.WriteLine("6. Exit");


        difficulty = GetDifficultyLevel();

        Console.Clear();

        GetDifficultyDescription(difficulty);

        Console.WriteLine();

        switch (difficulty)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                StartGame(difficulty);
                break;
            case 5:
                //View all the results.
                ViewResults();
                break;
            case 6:
                Console.Clear();
                Console.WriteLine("Thank you for playing the Math Game!");
                break;

        }

        Console.WriteLine();
    }

}

void StartGame(int difficulty)
{

    int operation = 0;
    int min = 0;
    int max = 101;
    int timer = (difficulty == 1 ? 60 : difficulty == 2 ? 30 : difficulty == 3 ? 10 : 5);

    string operationSymbol = "";

    
    if (difficulty < 4)
    {
        Console.WriteLine($"You have selected difficulty level {difficulty}. You will have {(difficulty == 1 ? 60 : difficulty == 2 ? 30 : 10)} seconds to answer each question.");

        operation = ChooseOperation();

        GetOperationDescription(operation);

        Console.WriteLine();

        //Since the operation is selected, we can get the symbol for it

        try
        {
            operationSymbol = GetOperationSymbol(operation);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return;
        }

    }

    
    //Generate each question, just one at a time
    for (int i = 0; i < 5; i++)
    {

        bool validNumber = false;
        int[] randomNumbers = new int[2];

        //Diffculty 4 is random, so we need to randomly select an operation for each question
        if (difficulty == 4)
        {
            operation = new Random().Next(1, 5); // Randomly select an operation between 1 and 4
            operationSymbol = GetOperationSymbol(operation);
        }


        //If the operation is division, we need to make sure that the division is possible and returns a whole number
        randomNumbers = GenerateRandomNumber(min, max);

        if (operation == 4)
        {
            while (!validNumber)
            {
                randomNumbers = GenerateRandomNumber(min, max);

                if (IsDivisionPossible(randomNumbers[0], randomNumbers[1]))
                {
                    validNumber = true;
                }

 
            }
        }



        int number1 = randomNumbers[0];
        int number2 = randomNumbers[1];

        int result = operation switch
        {
            1 => number1 + number2,
            2 => number1 - number2,
            3 => number1 * number2,
            4 => number2 != 0 ? number1 / number2 : 0, // Avoid division by zero
            _ => throw new ArgumentException("Invalid operation"),
        };

        Console.WriteLine($"Question {i + 1}: {number1} {operationSymbol} {number2} = ? (You have {timer} seconds)");
        int userAnswer;

        string input = ReadLineWithTimeout(timer);

        if (input == null)
        {
            Console.WriteLine($"Time's up! The correct answer is {result}.");
            quiz.Add(($"Question {i + 1}: {number1} {operationSymbol} {number2}. Your Answer: (no answer)",
                      $"Incorrect (Timeout), Correct Answer: {result}"));
        }
        else if (int.TryParse(input, out userAnswer))
        {
            if (userAnswer == result)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer is {result}.");
            }

            quiz.Add(($"Question {i + 1}: {number1} {operationSymbol} {number2}. Your Answer: {userAnswer}",
                      userAnswer == result ? "Correct" : $"Incorrect, Correct Answer: {result}"));
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            quiz.Add(($"Question {i + 1}: {number1} {operationSymbol} {number2}. Your Answer: {input}",
                      $"Incorrect (Invalid input), Correct Answer: {result}"));
        }

    }


}

//Helpers
int GetDifficultyLevel()
{
    int difficulty;
    while (true)
    {
        Console.Write("Enter your choice (1, 2, 3, 4, or 5): ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out difficulty) && (difficulty >= 1 && difficulty <= 5))
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
        }
    }
    return difficulty;
}

void GetDifficultyDescription(int difficulty)
{
    switch (difficulty)
    {
        case 1:
            Console.WriteLine("You selected Easy difficulty.");
            break;
        case 2:
            Console.WriteLine("You selected Medium difficulty.");
            break;
        case 3:
            Console.WriteLine("You selected Hard difficulty.");
            break;
        case 4:
            Console.WriteLine("You selected Expert difficulty.");
            break;
        case 5:
            Console.WriteLine("You selected to view all results.");
            break;
    }
}

int ChooseOperation()
{
    Console.WriteLine("Please select an operation:");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");

    int operation;
    while (true)
    {
        Console.Write("Enter your choice (1, 2, 3, or 4): ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out operation) && (operation >= 1 && operation <= 4))
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
        }
    }
    return operation;
}

void GetOperationDescription(int operation)
{
    switch (operation)
    {
        case 1:
            Console.WriteLine("You selected Addition.");
            break;
        case 2:
            Console.WriteLine("You selected Subtraction.");
            break;
        case 3:
            Console.WriteLine("You selected Multiplication.");
            break;
        case 4:
            Console.WriteLine("You selected Division.");
            break;
    }
}

//View results
void ViewResults()
{


    if(quiz.Count > 0)
    {
        Console.WriteLine("Results:");
        int quizNumber = 1;

        foreach (var item in quiz)
        {
            if (item.Text.Contains("Question 1:"))
            {
                Console.WriteLine();
                Console.WriteLine("Quiz #" + quizNumber);
                quizNumber++;
            }
            Console.WriteLine($"{item.Text} - {item.Answer}");
        }
    }
    else
    {
        Console.WriteLine("You haven't take a quiz yet.");
    }


    Console.WriteLine();

}

//Generates a random number between the specified min and max values
int[] GenerateRandomNumber(int min, int max) 
{

    Random number = new Random();

    int number1 = number.Next(min, max);
    int number2 = number.Next(min, max);

    return new int[] {number1, number2};
}

//Returns the operation symbol based on the selected operation
string GetOperationSymbol(int operation)
{
    return operation switch
    {
        1 => "+",
        2 => "-",
        3 => "*",
        4 => "/",
        _ => throw new ArgumentException("Invalid operation"),
    };
}


//Check if the division is possible and returns a whole number
bool IsDivisionPossible(int number1, int number2)
{
    double result = (double)number1 / number2;

    if(result % 1 == 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}

//Timer, this method was done by IA
string ReadLineWithTimeout(int timeoutSeconds)
{
    var input = new System.Text.StringBuilder();
    var stopwatch = Stopwatch.StartNew();
    var timeout = TimeSpan.FromSeconds(timeoutSeconds);

    while (stopwatch.Elapsed < timeout)
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(intercept: true); // true = don't echo automatically

            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                return input.ToString();
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                if (input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                    Console.Write("\b \b"); // erase last char visually
                }
            }
            else if (!char.IsControl(key.KeyChar))
            {
                input.Append(key.KeyChar);
                Console.Write(key.KeyChar); // manually echo since intercept:true suppresses it
            }
        }
        else
        {
            Thread.Sleep(50); // small delay to avoid busy-waiting
        }
    }

    return null; // timed out, no dangling task left behind
}