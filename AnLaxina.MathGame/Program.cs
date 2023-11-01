// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;


string[] validNumbers = new[] { "1", "2", "3", "4", "5", "6" };
List<string> pastGames = new List<string>();
Random random = new Random();

MainMenu();

// Create Individual Methods for each game mode
void MainMenu()
{
    DateTime fullDate = DateTime.Now;
    DateOnly today = DateOnly.FromDateTime(fullDate);
    TimeOnly currentTime = TimeOnly.FromDateTime(fullDate);
    
    Console.WriteLine("-----------------------------------------------------------------");
    Console.WriteLine(
        $@"Welcome to the math game! The date is {today.ToString("MMMM")} {today.Day}, {today.Year} and the time is: {currentTime}!");
    Console.WriteLine(
        "Please input the number based on the following options below and press the ENTER key once done: ");
    Console.WriteLine("1. Addition 2. Subtraction 3. Division 4. Multiplication 5. See past games 6. Quit");
    Console.WriteLine("-----------------------------------------------------------------");
    string userInput = Console.ReadLine();


// Checks to see if the user has inputted any invalid inputs
// If they did, the program loops until the user enters valid input
    while (!validNumbers.Contains(userInput))
    {
        Console.Write("Invalid input! Please try again: ");
        userInput = Console.ReadLine();
    }

    int userChoice = int.Parse(userInput);
    Console.Clear();
    Console.WriteLine("-----------------------------------------------------------------");
    switch (userChoice)
    {
        case 1:
            Console.WriteLine("Addition selected!");
            AdditionGame();
            break;
        case 2:
            Console.WriteLine("Subtraction selected!");
            SubtractionGame();
            break;
        case 3:
            Console.WriteLine("Division selected!");
            DivisionGame();
            break;
        case 4:
            Console.WriteLine("Multiplication selected!");
            MultiplicationGame();
            break;
        case 5:
            Console.WriteLine("Here are your past games:");
            if (pastGames.Count == 0)
            {
                Console.WriteLine("You have none!");
                MainMenu();
            }
            else
            {
                ShowHistory();
            }
            
            break;
        case 6:
            Console.WriteLine("See you next time!");
            Console.WriteLine("-----------------------------------------------------------------");
            Environment.Exit(0);
            break;
    }

    
}

void AdditionGame()
{
    var score = 0;
    Console.WriteLine("You will solve 4 questions total! Your score will be shown once you finish!");

    for (int i = 0; i < 4; i++)
    {
        var num1 = random.Next(1, 101);
        var num2 = random.Next(1, 101);
        Console.Write($"{num1} + {num2} = ");
        var userAnswer = Console.ReadLine();

        int number;
        bool isInt = int.TryParse(userAnswer, out number);
        
        // Checks to see if the user input is an integer
        // If not, the loop will repeat its current iteration and try again until the user inputs a valid one.
        if (!isInt)
        {
            Console.WriteLine("You have entered an incorrect input! Please try again.");
            i--;
            continue;
        }
        // Checks the user score
        if (num1 + num2 == number)
        {
            score++;
        }
    }
    // Adds the score to the past history of games
    pastGames.Add($"Addition Score: {score}/4");
    // Once the user finishes the quiz, the end screen appears
    Console.WriteLine($"Here is your score: {score}/4!");
    Console.WriteLine("-----------------------------------------------------------------");
    Console.WriteLine("Please input the following option: 1. Play again 2. Return to the menu 3. Exit");
    var finalInput = Console.ReadLine();
    string[] validInputs = new[] { "1", "2", "3" };
    // Checks to see if the input has entered one of the three options above
    // If not, it continues to loop until the user enters a valid input
    while (!validInputs.Contains(finalInput))
    {
        Console.Write("You entered an invalid input! Please try again: ");
        finalInput = Console.ReadLine();
    }
    
    switch (int.Parse(finalInput))
    {
        case 1:
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Welcome back!");
            AdditionGame();
            break;
        case 2:
            Console.Clear();
            MainMenu();
            break;
        case 3:
            Console.Clear();
            Console.Write("Thank you for playing!");
            Environment.Exit(0);
            break;
    }
    
}

void SubtractionGame()
{
    var score = 0;
    Console.WriteLine("You will solve 4 questions total! Your score will be shown once you finish!");

    for (int i = 0; i < 4; i++)
    {
        var num1 = random.Next(1, 101);
        var num2 = random.Next(1, 101);
        Console.Write($"{num1} - {num2} = ");
        var userAnswer = Console.ReadLine();

        int number;
        bool isInt = int.TryParse(userAnswer, out number);
        
        // Checks to see if the user input is an integer
        // If not, the loop will repeat its current iteration and try again until the user inputs a valid one.
        if (!isInt)
        {
            Console.WriteLine("You have entered an incorrect input! Please try again.");
            i--;
            continue;
        }
        // Checks the user score
        if (num1 - num2 == number)
        {
            score++;
        }
    }
    // Adds the score to the past history of games
    pastGames.Add($"Subtraction Score: {score}/4");
    // Once the user finishes the quiz, the end screen appears
    Console.WriteLine($"Here is your score: {score}/4!");
    Console.WriteLine("-----------------------------------------------------------------");
    Console.WriteLine("Please input the following option: 1. Play again 2. Return to the menu 3. Exit");
    var finalInput = Console.ReadLine();
    string[] validInputs = new[] { "1", "2", "3" };
    // Checks to see if the input has entered one of the three options above
    // If not, it continues to loop until the user enters a valid input
    while (!validInputs.Contains(finalInput))
    {
        Console.Write("You entered an invalid input! Please try again: ");
        finalInput = Console.ReadLine();
    }

    switch (int.Parse(finalInput))
    {
        case 1:
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Welcome back!");
            SubtractionGame();
            break;
        case 2:
            Console.Clear();
            MainMenu();
            break;
        case 3:
            Console.Clear();
            Console.Write("Thank you for playing!");
            Environment.Exit(0);
            break;
    }
}

void DivisionGame()
{
    var score = 0;
    Console.WriteLine("You will solve 4 questions total! Your score will be shown once you finish!");

    for (int i = 0; i < 4; i++)
    {
        var dividend = random.Next(0, 11);
        var divisor = random.Next(1, 11);
        var product = dividend * divisor;
        
        Console.Write($"{product} / {divisor} = ");
        var userAnswer = Console.ReadLine();

        int number;
        bool isInt = int.TryParse(userAnswer, out number);
        
        // Checks to see if the user input is an integer
        // If not, the loop will repeat its current iteration and try again until the user inputs a valid one.
        if (!isInt)
        {
            Console.WriteLine("You have entered an incorrect input! Please try again.");
            i--;
            continue;
        }
        // Checks the user score
        if (product / divisor == number)
        {
            score++;
        }
    }
    // Adds the score to the past history of games
    pastGames.Add($"Division Score: {score}/4");
    // Once the user finishes the quiz, the end screen appears
    Console.WriteLine($"Here is your score: {score}/4!");
    Console.WriteLine("-----------------------------------------------------------------");
    Console.WriteLine("Please input the following option: 1. Play again 2. Return to the menu 3. Exit");
    var finalInput = Console.ReadLine();
    string[] validInputs = new[] { "1", "2", "3" };
    // Checks to see if the input has entered one of the three options above
    // If not, it continues to loop until the user enters a valid input
    while (!validInputs.Contains(finalInput))
    {
        Console.Write("You entered an invalid input! Please try again: ");
        finalInput = Console.ReadLine();
    }

    switch (int.Parse(finalInput))
    {
        case 1:
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Welcome back!");
            DivisionGame();
            break;
        case 2:
            Console.Clear();
            MainMenu();
            break;
        case 3:
            Console.Clear();
            Console.Write("Thank you for playing!");
            Environment.Exit(0);
            break;
    }
}

void MultiplicationGame()
{
    var score = 0;
    Console.WriteLine("You will solve 4 questions total! Your score will be shown once you finish!");

    for (int i = 0; i < 4; i++)
    {
        var num1 = random.Next(1, 101);
        var num2 = random.Next(1, 101);
        Console.Write($"{num1} * {num2} = ");
        var userAnswer = Console.ReadLine();

        int number;
        bool isInt = int.TryParse(userAnswer, out number);
        
        // Checks to see if the user input is an integer
        // If not, the loop will repeat its current iteration and try again until the user inputs a valid one.
        if (!isInt)
        {
            Console.WriteLine("You have entered an incorrect input! Please try again.");
            i--;
            continue;
        }
        // Checks the user score
        if (num1 * num2 == number)
        {
            score++;
        }
    }
    // Adds the score to the past history of games
    pastGames.Add($"Multiplication Score: {score}/4");
    // Once the user finishes the quiz, the end screen appears
    Console.WriteLine($"Here is your score: {score}/4!");
    Console.WriteLine("-----------------------------------------------------------------");
    Console.WriteLine("Please input the following option: 1. Play again 2. Return to the menu 3. Exit");
    var finalInput = Console.ReadLine();
    string[] validInputs = new[] { "1", "2", "3" };
    // Checks to see if the input has entered one of the three options above
    // If not, it continues to loop until the user enters a valid input
    while (!validInputs.Contains(finalInput))
    {
        Console.Write("You entered an invalid input! Please try again: ");
        finalInput = Console.ReadLine();
    }

    switch (int.Parse(finalInput))
    {
        case 1:
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Welcome back!");
            MultiplicationGame();
            break;
        case 2:
            Console.Clear();
            MainMenu();
            break;
        case 3:
            Console.Clear();
            Console.Write("Thank you for playing!");
            Environment.Exit(0);
            break;
    }
}

void ShowHistory()
{
    int num = 1;
    foreach (var game in pastGames)
    {
        Console.WriteLine($"{num}. {game}");
        num++;
    }
    Console.WriteLine("-----------------------------------------------------------------");
    Console.WriteLine("Please input the following option: 1. Return to menu 2. Quit");
    var userInput = Console.ReadLine();
    
    
    string[] validInputs = new[] { "1", "2" };
    while (!validInputs.Contains(userInput))
    {
        Console.Write("Please input a valid number! Try again: ");
        userInput = Console.ReadLine();
    }

    switch (int.Parse(userInput))
    {
        case 1:
            Console.Clear();
            MainMenu();
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("See you next time!");
            Environment.Exit(0);
            break;
    }
}



