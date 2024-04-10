using Game;

var mathGame = new MathGame();

var gameOver = false;
int selection;
int result;
int firstNumber;
int secondNumber;
int userResponse;
int score = 0;
Random random = new Random();

while (!gameOver)
{
    mathGame.DisplayMenu();

    firstNumber = -1;
    secondNumber = -1;

    try
    {
        selection = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\n");
    }
    catch (Exception)
    {
        Console.WriteLine("Please Enter a Valid Value: 1 - 6");
        selection = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("\n");
    }

    firstNumber = random.Next(1, 101);
    secondNumber = random.Next(1, 101);

    switch (selection)
    {
        case 1:
            Console.WriteLine($"{firstNumber} + {secondNumber} = ??");
            result = mathGame.SummationOperation(firstNumber, secondNumber);
            userResponse = GetUserResponse();
            Console.WriteLine($"The correct result is: ");
            Console.WriteLine($"{firstNumber} + {secondNumber} = {result}");
            score = validateResult(result, userResponse, score);
            Console.WriteLine("\n");
            break;
        case 2:
            Console.WriteLine($"{firstNumber} - {secondNumber} = ??");
            result = mathGame.SubtractionOperation(firstNumber, secondNumber);
            userResponse = GetUserResponse();

            Console.WriteLine($"The correct result is: ");
            Console.WriteLine($"{firstNumber} - {secondNumber} = {result}");
            score = validateResult(result, userResponse, score);
            Console.WriteLine("\n");
            break;
        case 3:
            Console.WriteLine($"{firstNumber} * {secondNumber} = ??");
            result = mathGame.MultiplicationOperation(firstNumber, secondNumber);
            userResponse = GetUserResponse();
            Console.WriteLine($"The correct result is: ");
            Console.WriteLine($"{firstNumber} * {secondNumber} = {result}");
            score = validateResult(result, userResponse, score);

            Console.WriteLine("\n");
            break;
        case 4:
            Console.WriteLine($"{firstNumber} / {secondNumber} = ??");
            result = mathGame.DivisionOperation(firstNumber, secondNumber);
            if (result != int.MaxValue)
            {
                userResponse = GetUserResponse();
                Console.WriteLine($"The correct result is: ");
                Console.WriteLine($"{firstNumber} / {secondNumber} = {result}");
                score = validateResult(result, userResponse, score);
            }
            else
            {
                Console.WriteLine("The result was not an integer.");
            }
            Console.WriteLine("\n");
            break;
        case 5:
            Console.WriteLine("Previous Operations:");
            mathGame.RecordOfOperations.ForEach(Console.WriteLine);
            Console.WriteLine($"Your total score is: {score}");
            Console.WriteLine("\n");
            break;
        case 6:
            gameOver = true;
            Console.WriteLine("\n");
            break;
        default:
            Console.WriteLine("Please enter a valid option: 1 - 6");
            Console.WriteLine("\n");
            break;
    }


}

static int GetUserResponse()
{
    int response = 0;
    bool invalid = true;
    Console.WriteLine("Please enter your response.");
    while (invalid)
    {
        try
        {
            response = Convert.ToInt32(Console.ReadLine());
            invalid = false;
        }
        catch (Exception e)
        {
            Console.WriteLine("Please enter a valid Integer Value");
        }
    }
    return response;
}

Console.WriteLine("Thanks for playing this numbers game");

static int validateResult(int result, int userResponse, int score)
{
    if (userResponse == result)
    {
        Console.WriteLine("You answer correctly; You earned 5 pts.");
        score += 5;
    }
    else
    {
        Console.WriteLine($"Try again");
        score += 0;
    }

    return score;
}