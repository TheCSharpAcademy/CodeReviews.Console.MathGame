while (true)
{
    showMainMenu();

    string menuSelection = Console.ReadLine();
    
    if (menuSelection == "1")
    {
        int result = playGame();
        Console.WriteLine($"You got {result} / 5 correct!");
    }
    else if (menuSelection == "2")
    {
        // TODO
    }
    else if (menuSelection == "x")
    {
        break;
    }
    else
    {
        Console.WriteLine("Incorrect menu selection. Please try again.");
    }
}



void showMainMenu()
{
    Console.WriteLine("Main Menu");
    Console.WriteLine("1. Play Math Game!");
    Console.WriteLine("2. Show Scores");
    Console.WriteLine("Enter x to exit");
}

int playGame()
{
    string[] questions = ["9 x 9", "5 + 3", "6 - 2", "8 / 4", "7 * 5"];
    int[] answers = [81, 8, 4, 2, 35];

    int correct = 0;

    // Gets input from user and increments correct if it matches the answer
    for (int i = 0; i < questions.Length; i++)
    {
        Console.Write($"What does {questions[i]} = ");
        int userInput = int.Parse(Console.ReadLine());

        if (userInput == answers[i])
        {
            Console.WriteLine("Correct!");
            correct++;
        }
        else
        {
            Console.WriteLine("Incorrect :(");
        }
    }

    return correct;
}