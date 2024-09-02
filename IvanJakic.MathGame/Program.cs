
string? userInput;
string userChoice = "";
List<int> numbersCollection = new List<int>();

System.Console.WriteLine("\nWelcome to the Math Game!");

do
{
    System.Console.WriteLine("\nChose your opereation: ");
    System.Console.WriteLine("1 - Addition");
    System.Console.WriteLine("2 - Subtraction");
    System.Console.WriteLine("3 - Multiplication");
    System.Console.WriteLine("4 - Division");
    System.Console.WriteLine("5 - Show all results in a list");
    System.Console.WriteLine("x - Close the Game\n");

    userInput = Console.ReadLine();
    Console.Clear();
    int[] userNumbers;
    int result;
    if (userInput != null)
    {
        userChoice = userInput;
    }

    switch (userChoice)
    {
        case "1":
            userNumbers = GetNumbers();
            result = userNumbers[0] + userNumbers[1];
            numbersCollection.Add(result);
            System.Console.WriteLine($"The addition of two given numbers is {result}");
            break;

        case "2":
            userNumbers = GetNumbers();
            result = userNumbers[0] - userNumbers[1];
            numbersCollection.Add(result);
            System.Console.WriteLine($"The subtraction of two given numbers is {result}");
            break;

        case "3":
            userNumbers = GetNumbers();
            result = userNumbers[0] * userNumbers[1];
            numbersCollection.Add(result);
            System.Console.WriteLine($"The subtraction of two given numbers is {result}");
            break;

        case "4":
            userNumbers = GetNumbers();
            while (!(userNumbers[0] >= 0 && userNumbers[0] <= 100))
            {
                System.Console.WriteLine("The first number must be bewtween 0 and 100, Try again: ");
                userNumbers = GetNumbers();
            }
            while (!(userNumbers[0] % userNumbers[1] == 0))
            {
                System.Console.WriteLine("The result is not a whole number. Try entering numbers again: ");
                userNumbers = GetNumbers();
            }

            result = userNumbers[0] / userNumbers[1];
            numbersCollection.Add(result);
            System.Console.WriteLine($"The division of two given numbers is {result}");
            break;

        case "5":
            PrintResults(numbersCollection);
            break;
        // default:
        //     System.Console.WriteLine("Please choose a valid menu option.");
        //     break;
    }
} while (userChoice.ToLower() != "x");



static void PrintResults(List<int> results)
{
    string resultString = string.Join(", ", results);
    System.Console.Write(resultString + "\n");
}

static int[] GetNumbers()
{
    string? userInput;
    int firstNumber = 0;
    int secondNumber = 0;
    bool isNumber = true;
    int[] numbers = new int[2];
    do
    {
        System.Console.Write("Please provide the first number: ");
        userInput = Console.ReadLine();
        if (userInput != null)
        {
            if (int.TryParse(userInput, out var intValue))
            {
                firstNumber = intValue;
                numbers[0] = firstNumber;
                isNumber = true;
            }
            else
            {
                System.Console.WriteLine("Enter a real number");
                isNumber = false;
            }
        }
    } while (!isNumber);

    do
    {
        System.Console.Write("Please provide the second number: ");
        userInput = Console.ReadLine();
        if (userInput != null)
        {
            if (int.TryParse(userInput, out var intValue))
            {
                secondNumber = intValue;
                numbers[1] = secondNumber;
                isNumber = true;
            }
            else
            {
                System.Console.WriteLine("Enter a real number");
                isNumber = false;
            }
        }
    } while (!isNumber);

    return numbers;
}