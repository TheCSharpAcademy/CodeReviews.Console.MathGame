Random rand = new();
List<string> playedGames = [];
bool exitGame = false;
int gameRounds = 0;
int globalScore = 0;

//GameLoop
Greeting();
while (exitGame == false)
{
    Menu();
}

// -------------------- METHODS -------------------------------
void Greeting()
{
    Console.WriteLine("Welcome to the Math Game");
}

void Menu()
{
    Console.WriteLine($"Your score this session: {globalScore}");
    Console.WriteLine("Please choose the game: ");
    Console.WriteLine("A - Addition\nS - Substraction\nM - Multiplication\nD - Division\nP - Played Games\nE - Exit");

    bool legalInput = false;

    while (legalInput == false)
    {
        string userInput = Console.ReadLine()!.ToLower();
        switch (userInput)
        {
            case "a":
                gameRounds = SetNumberOfRounds();
                Addition(gameRounds);
                Console.WriteLine("Would you like to play another game? (Y/N): ");
                string playAgain = Console.ReadLine()!.ToLower();
                if (playAgain.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    Menu();
                }
                else
                {
                    exitGame = true;
                }
                break;

            case "s":
                gameRounds = SetNumberOfRounds();
                Substraction(gameRounds);
                Console.WriteLine("Would you like to play another game? (Y/N): ");
                playAgain = Console.ReadLine()!.ToLower();
                if (playAgain.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    Menu();
                }
                else
                {
                    exitGame = true;
                }
                break;

            case "m":
                gameRounds = SetNumberOfRounds();
                Multiplication(gameRounds);
                Console.WriteLine("Would you like to play another game? (Y/N): ");
                playAgain = Console.ReadLine()!.ToLower();
                if (playAgain.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    Menu();
                }
                else
                {
                    exitGame = true;
                }
                break;

            case "d":
                gameRounds = SetNumberOfRounds();
                Division(gameRounds);
                Console.WriteLine("Would you like to play another game? (Y/N): ");
                playAgain = Console.ReadLine()!.ToLower();
                if (playAgain.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    Menu();
                }
                else
                {
                    exitGame = true;
                }
                break;

            case "p":
                PrintPlayedGames();
                Console.WriteLine("Would you like to play another game? (Y/N): ");
                playAgain = Console.ReadLine()!.ToLower();
                if (playAgain.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    Menu();
                }
                else
                {
                    exitGame = true;
                }
                break;

            case "e":
                exitGame = true;
                break;

            default:
                Console.WriteLine("Incorrect input. Please choose again.");
                break;
        }
        break;
    }
}

void Addition(int rounds)
{
    Console.WriteLine("Let's play addition");
    int a = 0;
    int b = 0;
    int result = 0;
    int answerAsInt = 0;
    int counter = 1;
    int score = 0;
    while (counter <= rounds)
    {
        // Create variables
        a = rand.Next(1, 11);
        b = rand.Next(1, 11);
        result = a + b;

        //Display the question
        Console.WriteLine($"{a} + {b} = ");

        //Get answer
        answerAsInt = GetAnswerAsInt();

        //Check the result
        if (result == answerAsInt)
        {
            Console.WriteLine("Congrats. Your answer was right");
            score++;
        }
        else { Console.WriteLine("I'm sorry. You are wrong"); }

        counter++;
    }
    Console.WriteLine($"You answered {score} right out of {rounds}");
    globalScore += score;

    playedGames.Add($"Score: {score}/{gameRounds} Time: {DateTime.Now}");
}

void Substraction(int rounds)
{
    Console.WriteLine("Let's play Substraction.");
    int a = 0;
    int b = 0;
    int result = 0;
    int answerAsInt = 0;
    int counter = 1;
    int score = 0;

    while (counter <= rounds)
    {
        // Create variables
        a = rand.Next(1, 11);
        b = rand.Next(1, 11);
        result = a - b;

        //Display the question
        Console.WriteLine($"{a} - {b} = ");

        //Get answer
        answerAsInt = GetAnswerAsInt();

        //Check the result
        if (result == answerAsInt)
        {
            Console.WriteLine("Congrats. Your answer was right");
            score++;
        }
        else { Console.WriteLine("I'm sorry. You are wrong"); }
        counter++;
    }
    Console.WriteLine($"You answered {score} right out of {rounds}");
    globalScore += score;
    playedGames.Add($"Score: {score}/{gameRounds} Time: {DateTime.Now}");
}

void Multiplication(int rounds)
{
    Console.WriteLine("Let's play Multiplication");
    int a = 0;
    int b = 0;
    int result = 0;
    int answerAsInt = 0;
    int counter = 1;
    int score = 0;

    while (counter <= rounds)
    {
        // Create variables
        a = rand.Next(1, 11);
        b = rand.Next(1, 11);
        result = a * b;

        //Display the question
        Console.WriteLine($"{a} * {b} = ");

        //Get answer
        answerAsInt = GetAnswerAsInt();

        //Check the result
        if (result == answerAsInt)
        {
            Console.WriteLine("Congrats. Your answer was right");
            score++;
        }
        else { Console.WriteLine("I'm sorry. You are wrong"); }
        counter++;
    }
    Console.WriteLine($"You answered {score} right out of {rounds}");
    globalScore += score;
    playedGames.Add($"Score: {score}/{gameRounds} Time: {DateTime.Now}");
}

void Division(int rounds)
{
    // Create variables

    int result = 0;
    int answerAsInt = 0;
    int score = 0;

    Console.WriteLine("Let's play Division");

    for (int i = 1; i <= rounds; i++)
    {
        int a = rand.Next(1, 101);
        int b = rand.Next(1, 101);
        while (a % b != 0)
        {
            a = rand.Next(1, 101);
            b = rand.Next(1, 101);
        }
        result = a / b;
        //Display the question
        Console.WriteLine($"{a} / {b} = ");

        //Get Answer and convert to Int
        answerAsInt = GetAnswerAsInt();

        //Check the result
        if (result == answerAsInt)
        {
            Console.WriteLine("Congrats. Your answer was right");
            score++;
        }
        else { Console.WriteLine("I'm sorry. You are wrong"); }
    }
    Console.WriteLine($"You answered {score} right out of {rounds}");
    globalScore += score;
    playedGames.Add($"Score: {score}/{gameRounds} Time: {DateTime.Now}");
}

int GetAnswerAsInt()
{
    int answerAsInt = 0;
    bool numberChecker = false;
    while (numberChecker == false)
    {
        Console.Write("Please enter a number: ");
        string userAnswer = Console.ReadLine()!;
        bool parseResult = int.TryParse(userAnswer, out answerAsInt);
        if (parseResult)
        {
            numberChecker = true;
        }
        else { Console.WriteLine("You didn't enter an integer. Please try again."); }
    }
    return answerAsInt;
}

int SetNumberOfRounds()
{
    Console.WriteLine("Please set the number of rounds(1-10): ");
    int rounds = 0;

    while (rounds < 1 || rounds > 10)
    {
        rounds = GetAnswerAsInt();
    }
    return rounds;
}

void PrintPlayedGames()
{
    foreach (string game in playedGames)
    {
        Console.WriteLine(game);
    }
}