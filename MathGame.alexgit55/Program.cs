/*
 * This is a simple math game that asks the user to solve a series of math problems.
 * The user can select the type of math operation they want to focus on (addition, subtraction, multiplication, division, random).
 * The user is asked if they want to play again after each round.
 */

//Set initial variables, and create a loop to keep the game running until the user decides to exit.
bool keepPlaying = true;
var history = new List<string>();
string[] operations = { "Addition", "Subtraction", "Multiplication", "Division", "Random" };
int totalQuestions = 10;
int difficulty = 1;

while (keepPlaying)
{
    Console.Clear();
    Console.WriteLine("Welcome to the Math Game!\n");
    char userSelection = GameMenu();
    int menuSelection = userSelection - '0';

    switch (menuSelection)
    {
        case 6:
            Console.WriteLine("You selected History");
            ViewGameHistory();
            break;
        case 7:
            Console.WriteLine("Thanks for Playing! Goodbye!");
            Console.WriteLine("Press any key to exit");
            keepPlaying = false;
            break;
        default:
            Console.WriteLine($"You've selected {operations[menuSelection - 1]}");
            CustomGameSettings();
            GameRound(menuSelection, difficulty, totalQuestions);
            break;
    }
}

Console.ReadKey();

char GameMenu()
// Display the game menu and return the user's selection
// verify that the user's selection is valid
{
    char selection = '0';
    char[] validSelections = { '1', '2', '3', '4', '5', '6', '7' };

    while (Array.IndexOf(validSelections, selection) == -1)
    {
        Console.WriteLine("Please select the math operation(s) you want to focus on: ");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Random");
        Console.WriteLine("6. History");
        Console.WriteLine("7. Exit");

        selection = Console.ReadKey().KeyChar;
        Console.WriteLine();
    }
    return selection;
}

void CustomGameSettings()
{
    Console.Clear();
    Console.WriteLine("Custom Game Settings");
    Console.WriteLine("--------------------");
    Console.WriteLine("Enter the number of questions you want to answer (1-20): ");
    while (!int.TryParse(Console.ReadLine(), out totalQuestions) || totalQuestions < 1 || totalQuestions > 20)
    {
        Console.WriteLine("Please enter a valid number between 1 and 20.");
    }

    Console.WriteLine("Enter the difficulty level (1-3): ");
    while (!int.TryParse(Console.ReadLine(), out difficulty) || difficulty < 1 || difficulty > 3)
    {
        Console.WriteLine("Please enter a valid number between 1 and 3.");
    }
}

void GameRound(int selection, int difficulty = 1, int totalQuestions = 10)
// Play a round of the game with the selected math operation
// If the user selects random, a random operation will be chosen for each question
{
    int lowerRange = 1;
    int upperRange = 10;
    int playerScore = 0;
    int operation = 0;
    DateTime startTime = DateTime.Now;

    switch (difficulty)
    {
        case 1:
            lowerRange = 1;
            upperRange = 10;
            break;
        case 2:
            lowerRange = 1;
            upperRange = 30;
            break;
        case 3:
            lowerRange = 1;
            upperRange = 50;
            break;
    }

    for (int i = 1; i <= totalQuestions; i++)
    {
        if (selection == 5)
        {
            Random rand = new Random();
            operation = rand.Next(1, 5);
        }
        else
        {
            operation = selection;
        }

        Console.WriteLine($"Question {i} of {totalQuestions}");
        playerScore += MathQuestion(lowerRange, upperRange, operation);
    }

    Console.WriteLine($"Your final score was {playerScore} out of {totalQuestions} correct.");
    DateTime endTime = DateTime.Now;
    TimeSpan timeElapsed = endTime - startTime;
    Console.WriteLine($"Time Elapsed: {timeElapsed.Minutes} minutes {timeElapsed.Seconds} seconds");
    SaveGameScore(selection, playerScore, difficulty, timeElapsed);
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();

}

void SaveGameScore(int selection, int playerScore, int difficulty, TimeSpan timeElapsed)
// Save the player's score for the round in the game history
{
    string historyEntry = "";

    historyEntry = $"{operations[selection - 1]}, difficulty-{difficulty}, {playerScore} points, Time Elapsed: {timeElapsed.Minutes} minutes {timeElapsed.Seconds} seconds";
    history.Add(historyEntry);
}

void ViewGameHistory()
// Display scores from each round played
{
    if (history.Count == 0)
        Console.WriteLine("\nNo history available. Please play a round of the game!");
    else
    {
        Console.WriteLine("\nGame History");
        Console.WriteLine("-------------");
        for (int i = 0; i < history.Count; i++)
        {
            Console.WriteLine($"Round {i + 1}: {history[i]}");
        }
    }
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

int MathQuestion(int lowerRange, int upperRange, int selection)
//Used to generate a math question based on the user's selection and return whether the user's answer was correct
{
    bool correct = false;
    switch (selection)
    {
        case 1:
            correct = Addition(lowerRange, upperRange);
            break;
        case 2:
            correct = Subtraction(lowerRange, upperRange);
            break;
        case 3:
            correct = Multiplication(lowerRange, upperRange);
            break;
        case 4:
            correct = Division(lowerRange, upperRange);
            break;
    }

    if (correct)
        return 1;
    else
        return 0;
}

bool Addition(int lowerRange, int upperRange)
// Generate the addition problem and check if the user's answer is correct
{
    int userAnswer;
    // Generate two random numbers between lower range and upper range
    Random rand = new Random();
    int num1 = rand.Next(lowerRange, upperRange);
    int num2 = rand.Next(lowerRange, upperRange);

    //Ask the user to solve the addition problem
    Console.WriteLine($"What is the sum of {num1} + {num2}?");

    while (!int.TryParse(Console.ReadLine(), out userAnswer))
    {
        Console.WriteLine("Please enter a valid number.");
    }

    // Check if the user's answer is correct
    int correctAnswer = num1 + num2;
    if (userAnswer == correctAnswer)
    {
        Console.WriteLine("Correct! Good job!\n");
        return true;
    }
    else
    {
        Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}\n");
        return false;
    }

}

bool Subtraction(int lowerRange, int upperRange)
// Generate the subtraction problem and check if the user's answer is correct
{
    // Generate two random numbers between lowerRange and upperRange
    int num1;
    int num2;
    int userAnswer;
    do
    {
        Random rand = new Random();
        num1 = rand.Next(lowerRange, upperRange);
        num2 = rand.Next(lowerRange, upperRange);
    } while (num1 <= num2);

    // Ask the user to solve the subtraction problem
    Console.WriteLine($"What is the difference of {num1} - {num2}?");

    while (!int.TryParse(Console.ReadLine(), out userAnswer))
    {
        Console.WriteLine("Please enter a valid number.");
    }

    // Check if the user's answer is correct
    int correctAnswer = num1 - num2;
    if (userAnswer == correctAnswer)
    {
        Console.WriteLine("Correct! Good job!\n");
        return true;
    }
    else
    {
        Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}\n");
        return false;
    }
}

bool Multiplication(int lowerRange, int upperRange)
// Generate the multiplication problem and check if the user's answer is correct
{
    int userAnswer;
    // Generate two random numbers between lowerRange and upperRange

    Random rand = new Random();
    int num1 = rand.Next(lowerRange, upperRange);
    int num2 = rand.Next(lowerRange, upperRange);

    // Ask the user to solve the multiplication problem
    Console.WriteLine($"What is the product of {num1} * {num2}?");

    while (!int.TryParse(Console.ReadLine(), out userAnswer))
    {
        Console.WriteLine("Please enter a valid number.");
    }

    // Check if the user's answer is correct
    int correctAnswer = num1 * num2;
    if (userAnswer == correctAnswer)
    {
        Console.WriteLine("Correct! Good job!\n");
        return true;
    }
    else
    {
        Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}\n");
        return false;
    }
}

bool Division(int lowerRange, int upperRange)
// Generate the division problem and check if the user's answer is correct
{
    int userAnswer;
    int num1 = 0;
    int num2 = 1;
    // Generate two random numbers between lowerRange and upperRange
    // Ensure that num1 is divisible by num2
    do
    {
        Random rand = new Random();
        num1 = rand.Next(lowerRange, upperRange);
        num2 = rand.Next(lowerRange, upperRange);
    } while (num1 % num2 != 0);

    // Ask the user to solve the addition problem
    Console.WriteLine($"What is the quotient of {num1} / {num2}?");

    while (!int.TryParse(Console.ReadLine(), out userAnswer))
    {
        Console.WriteLine("Please enter a valid number.");
    }

    // Check if the user's answer is correct
    int correctAnswer = num1 / num2;
    if (userAnswer == correctAnswer)
    {
        Console.WriteLine("Correct! Good job!\n");
        return true;
    }
    else
    {
        Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}\n");
        return false;
    }
}