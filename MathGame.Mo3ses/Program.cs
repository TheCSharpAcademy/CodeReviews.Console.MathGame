// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to Math-Game");

bool PlayGame = true;

while (PlayGame)
{

    Random random = new Random();

    int number1 = random.Next(0, 100);
    int number2 = random.Next(1, 100);
    int result = 0;
    int answerMenu = 0;
    int answer = 0;

    string actualOperation;

    Console.WriteLine("------------------ Menu ------------------");
    Console.WriteLine("1 - Addition");
    Console.WriteLine("2 - Subtraction");
    Console.WriteLine("3 - Multiplication");
    Console.WriteLine("4 - Division");
    Console.WriteLine("5 - Exit");
    Console.WriteLine("------------------------------------------");



    answerMenu = Convert.ToInt32(System.Console.ReadLine());



    switch (answerMenu)
    {
        case 1:
            actualOperation = $"{number1} + {number2}";
            System.Console.WriteLine(actualOperation);
            answer = Convert.ToInt32(System.Console.ReadLine());
            result = number1 + number2;
            break;
        case 2:
            actualOperation = $"{number1} - {number2}";
            System.Console.WriteLine(actualOperation);
            answer = Convert.ToInt32(System.Console.ReadLine());
            result = number1 - number2;
            break;
        case 3:
            actualOperation = $"{number1} * {number2}";
            System.Console.WriteLine(actualOperation);
            answer = Convert.ToInt32(System.Console.ReadLine());
            result = number1 * number2;
            break;
        case 4:
            actualOperation = $"{number1} / {number2}";
            System.Console.WriteLine(actualOperation);
            answer = Convert.ToInt32(System.Console.ReadLine());
            result = number1 / number2;
            break;
        case 5:
            PlayGame = false;
            break;
        default:
            System.Console.WriteLine("Invalid Option, Try Again.");
            break;
    }

    if (result == answer)   {
        System.Console.WriteLine("Correct Answer");
    } else {
        System.Console.WriteLine($"Incorrect Answer Correct Value = {result}");
    }
}
