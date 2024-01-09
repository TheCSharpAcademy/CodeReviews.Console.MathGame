// MATH GAME

// Menu Options : +(add), -(subtract), *(multiply), /(divide), List(history), Exit
// Operaters: give random integers in an expression
//              let user guess, if correct; win message, back to menu. if incorrect; try again, option for menu.
//              only integer answers (prevent remainders and decimals specifically on division) 
// List: show user the expressions they have already completed
// Exit: end program

//Intro Message & Menu Format
using Microsoft.VisualBasic;

Console.WriteLine("Hello! Welcome to the Math Game!");
Console.WriteLine("\nIn this game, you will choose your math operator,\nand you will solve them to test your math skills.");
Console.WriteLine("\nPress any key to Continue");
Console.ReadLine();
Console.WriteLine("\nPlease select an option from our menu by typing the NUMBER of your choice:");
Console.WriteLine("\n[1] Addition\n[2] Subtraction\n[3] Multiplication\n[4] Division\n[5] Your History\n[6] Exit Game");

//Menu Choices

bool userMenuChoiceValid;
List<string> equations = new List<string>();

do
{
    string? userMenuChoice = Console.ReadLine();

    switch (userMenuChoice)
    {
        case "1":
            Addition();
            break;
        case "2":
            Subtraction();
            break;
        case "3":
            Multiplication();
            break;
        case "4":
            Division();
            break;
        case "5":
            Console.Clear();
            userMenuChoiceValid = true;
            foreach(string answer in equations)
            {
                Console.WriteLine(answer);
            }
            Console.WriteLine("\nWould you like to: \n[1]Return to menu?\n[2]Exit game");
            string? userReply = Console.ReadLine();
            if (userReply == "1")
            {
                userMenuChoiceValid = false;
            }
            else
            {
                break;
            }
            break;
        case "6":
            userMenuChoiceValid = true;
            break;
        default:
            userMenuChoiceValid = false;
            Console.WriteLine("Please enter the NUMBER of your choice");
            Console.WriteLine("\n[1] Addition\n[2] Subtraction\n[3] Multiplication\n[4] Division\n[5] Your History\n[6] Exit Game");
            break;
    }
} while (userMenuChoiceValid == false);

//Methods for equations and loops for menus
void Addition()
{
    var numberOne = new Random();
    var numberTwo = new Random();
    int firstInteger;
    int secondInteger;
    int result;
    userMenuChoiceValid = true;
    Console.Clear();
    Console.WriteLine("Addition!");
    firstInteger = numberOne.Next(1, 100);
    secondInteger = numberTwo.Next(1, 100);
    result = firstInteger + secondInteger;
    Console.WriteLine($"Solve the equasion:\n{firstInteger} + {secondInteger} =");
    string? additionInput = Console.ReadLine();
    if (result.ToString() == additionInput)
    {
        Console.WriteLine("Congratulations! You're Correct!\nWould you like to: \n[1]Try Another?\n[2]Return to Menu?\n[3]Exit Game?");
        equations.Add($"{firstInteger} + {secondInteger} = {result}");
        string? newUserChoice = Console.ReadLine();
        switch (newUserChoice)
        {
            case "1":
                Addition();
                break;

            case "2":
                userMenuChoiceValid = false;
                Console.WriteLine("Press any key");
                break;

            default:
                Console.WriteLine("GoodBye!");
                break;
        }
    }
    else
    {
        Console.WriteLine("Sorry, that is incorrect.\nPlease try again or press '0' to exit.");
        string? tryAgain = Console.ReadLine();
        do
        {
            if (result.ToString() == tryAgain)
            {
                tryAgain = "0";
                Console.WriteLine("Congratulations! You're Correct!\nWould you like to: \n[1]Try Another?\n[2]Return to Menu?\n[3]Exit Game?");
                equations.Add($"{firstInteger} + {secondInteger} = {result}");
                string? newUserChoice = Console.ReadLine();
                switch (newUserChoice)
                {
                    case "1":
                        Addition();
                        break;

                    case "2":
                        userMenuChoiceValid = false;
                        Console.WriteLine("Press any key");
                        break;

                    default:
                        Console.WriteLine("GoodBye!");
                        break;
                }
            }
            else if (tryAgain == "0")
            {
                break;
            }
            else
            {
                Console.WriteLine("Sorry, that is incorrect.\nPlease try again or press '0' to exit.");
                tryAgain = Console.ReadLine();
            }
        } while (tryAgain != "0");
    }
}
void Subtraction()
{
    var numberOne = new Random();
    var numberTwo = new Random();
    int firstInteger;
    int secondInteger;
    int result;
    userMenuChoiceValid = true;
    Console.Clear();
    Console.WriteLine("Subtraction!");
    firstInteger = numberOne.Next(51, 100);
    secondInteger = numberTwo.Next(1, 50);
    result = firstInteger - secondInteger;
    Console.WriteLine($"Solve the equasion:\n{firstInteger} - {secondInteger} =");
    string? subtractionInput = Console.ReadLine();
    if (result.ToString() == subtractionInput)
    {
        Console.WriteLine("Congratulations! You're Correct!\nWould you like to: \n[1]Try Another?\n[2]Return to Menu?\n[3]Exit Game?");
        equations.Add($"{firstInteger} - {secondInteger} = {result}");
        string? newUserChoice = Console.ReadLine();
        switch (newUserChoice)
        {
            case "1":
                Subtraction();
                break;

            case "2":
                userMenuChoiceValid = false;
                Console.WriteLine("Press any key");
                break;

            default:
                Console.WriteLine("GoodBye!");
                break;
        }
    }
    else
    {
        Console.WriteLine("Sorry, that is incorrect.\nPlease try again or press '0' to exit.");
        string? tryAgain = Console.ReadLine();
        do
        {
            if (result.ToString() == tryAgain)
            {
                tryAgain = "0";
                Console.WriteLine("Congratulations! You're Correct!\nWould you like to: \n[1]Try Another?\n[2]Return to Menu?\n[3]Exit Game?");
                equations.Add($"{firstInteger} - {secondInteger} = {result}");
                string? newUserChoice = Console.ReadLine();
                switch (newUserChoice)
                {
                    case "1":
                        Subtraction();
                        break;

                    case "2":
                        userMenuChoiceValid = false;
                        Console.WriteLine("Press any key");
                        break;

                    default:
                        Console.WriteLine("GoodBye!");
                        break;
                }
            }
            else if (tryAgain == "0")
            {
                break;
            }
            else
            {
                Console.WriteLine("Sorry, that is incorrect.\nPlease try again or press '0' to exit.");
                tryAgain = Console.ReadLine();
            }
        } while (tryAgain != "0");
    }
}
void Multiplication()
{
    var numberOne = new Random();
    var numberTwo = new Random();
    int firstInteger;
    int secondInteger;
    int result;
    userMenuChoiceValid = true;
    Console.Clear();
    Console.WriteLine("Multiplication!");
    firstInteger = numberOne.Next(1, 20);
    secondInteger = numberTwo.Next(1, 20);
    result = firstInteger * secondInteger;
    Console.WriteLine($"Solve the equasion:\n{firstInteger} * {secondInteger} =");
    string? multiplicationInput = Console.ReadLine();
    if (result.ToString() == multiplicationInput)
    {
        Console.WriteLine("Congratulations! You're Correct!\nWould you like to: \n[1]Try Another?\n[2]Return to Menu?\n[3]Exit Game?");
        equations.Add($"{firstInteger} * {secondInteger} = {result}");
        string? newUserChoice = Console.ReadLine();
        switch (newUserChoice)
        {
            case "1":
                Multiplication();
                break;

            case "2":
                userMenuChoiceValid = false;
                Console.WriteLine("Press any key");
                break;

            default:
                Console.WriteLine("GoodBye!");
                break;
        }
    }
    else
    {
        Console.WriteLine("Sorry, that is incorrect.\nPlease try again or press '0' to exit.");
        string? tryAgain = Console.ReadLine();
        do
        {
            if (result.ToString() == tryAgain)
            {
                tryAgain = "0";
                Console.WriteLine("Congratulations! You're Correct!\nWould you like to: \n[1]Try Another?\n[2]Return to Menu?\n[3]Exit Game?");
                equations.Add($"{firstInteger} * {secondInteger} = {result}");
                string? newUserChoice = Console.ReadLine();
                switch (newUserChoice)
                {
                    case "1":
                        Multiplication();
                        break;

                    case "2":
                        userMenuChoiceValid = false;
                        Console.WriteLine("Press any key");
                        break;

                    default:
                        Console.WriteLine("GoodBye!");
                        break;
                }
            }
            else if (tryAgain == "0")
            {
                break;
            }
            else
            {
                Console.WriteLine("Sorry, that is incorrect.\nPlease try again or press '0' to exit.");
                tryAgain = Console.ReadLine();
            }
        } while (tryAgain != "0");
    }
}
void Division()

{
    var numberOne = new Random();
    var numberTwo = new Random();
    int firstInteger;
    int secondInteger;
    int result;
    userMenuChoiceValid = true;
    Console.Clear();
    Console.WriteLine("Division!");

    do
    {
        firstInteger = numberOne.Next(50, 100);
        secondInteger = numberTwo.Next(1, 50);
    } while (firstInteger % secondInteger != 0);

    result = firstInteger / secondInteger;
    Console.WriteLine($"Solve the equasion:\n{firstInteger} / {secondInteger} =");
    string? divisionInput = Console.ReadLine();
    if (result.ToString() == divisionInput)
    {
        Console.WriteLine("Congratulations! You're Correct!\nWould you like to: \n[1]Try Another?\n[2]Return to Menu?\n[3]Exit Game?");
        equations.Add($"{firstInteger} / {secondInteger} = {result}");
        string? newUserChoice = Console.ReadLine();
        switch (newUserChoice)
        {
            case "1":
                Division();
                break;

            case "2":
                userMenuChoiceValid = false;
                Console.WriteLine("Press any key");
                break;

            default:
                Console.WriteLine("GoodBye!");
                break;
        }
    }
    else
    {
        Console.WriteLine("Sorry, that is incorrect.\nPlease try again or press '0' to exit.");
        string? tryAgain = Console.ReadLine();
        do
        {
            if (result.ToString() == tryAgain)
            {
                tryAgain = "0";
                Console.WriteLine("Congratulations! You're Correct!\nWould you like to: \n[1]Try Another?\n[2]Return to Menu?\n[3]Exit Game?");
                equations.Add($"{firstInteger} / {secondInteger} = {result}");
                string? newUserChoice = Console.ReadLine();
                switch (newUserChoice)
                {
                    case "1":
                        Division();
                        break;

                    case "2":
                        userMenuChoiceValid = false;
                        Console.WriteLine("Press any key");
                        break;

                    default:
                        Console.WriteLine("GoodBye!");
                        break;
                }
            }
            else if (tryAgain == "0")
            {
                break;
            }
            else
            {
                Console.WriteLine("Sorry, that is incorrect.\nPlease try again or press '0' to exit.");
                tryAgain = Console.ReadLine();
            }
        } while (tryAgain != "0");
    }
}
