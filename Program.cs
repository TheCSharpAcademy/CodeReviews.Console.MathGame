/*
1. You need to create a Math game containing the 4 basic operations
2. The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
3. Users should be presented with a menu to choose an operation
4. You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.
*/

using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
static void Main(string[] args)
{
        String history = "";
        List<string> gameHistory = new List<string> {history};
        Random random = new Random();
        int score = 0;
        int answer;
        bool stillPlaying = true;

        Console.WriteLine("Welcome to the Math Game!");
        while(stillPlaying)
        {

        Console.WriteLine("Enter an option from the menu below (1 - 6)");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. History");
        Console.WriteLine("6. Exit");
        
        string userInput = Console.ReadLine();
        int number;
        
        if(Int32.TryParse(userInput, out number))
        {
            switch (number)
            {
                case 1:
                    int firstNumber = random.Next(1, 101);
                    int secondNumber = random.Next(1, 101);
                    Console.WriteLine($"{firstNumber} + {secondNumber} = ?");
                    Int32.TryParse(Console.ReadLine(), out answer);
                    if (answer == (firstNumber + secondNumber))
                    {
                        Console.WriteLine("Correct!");
                        gameHistory.Add($"{firstNumber} + {secondNumber}: Answered correctly");
                        score += 5;
                    }
                    else
                    {
                        Console.WriteLine("Wrong!!!");
                        gameHistory.Add($"{firstNumber} + {secondNumber}: Answered incorrectly");
                    }
                    break;
                case 2:
                    firstNumber = random.Next(1, 101);
                    secondNumber = random.Next(1, 101);
                    Console.WriteLine($"{firstNumber} - {secondNumber} = ?");
                    Int32.TryParse(Console.ReadLine(), out answer);
                    if (answer == (firstNumber - secondNumber))
                    {
                        Console.WriteLine("Correct!");
                        gameHistory.Add($"{firstNumber} - {secondNumber}: Answered correctly");
                        score += 5;
                    }
                    else
                    {
                        Console.WriteLine("Wrong!!!");
                        gameHistory.Add($"{firstNumber} - {secondNumber}: Answered incorrectly");
                    }
                    break;
                case 3:
                    firstNumber = random.Next(1, 101);
                    secondNumber = random.Next(1, 101);
                    Console.WriteLine($"{firstNumber} * {secondNumber} = ?");
                    Int32.TryParse(Console.ReadLine(), out answer);
                    if (answer == (firstNumber * secondNumber))
                    {
                        Console.WriteLine("Correct!");
                        gameHistory.Add($"{firstNumber} * {secondNumber}: Answered correctly");
                        score += 5;
                    }
                    else
                    {
                        Console.WriteLine("Wrong!!!");
                        gameHistory.Add($"{firstNumber} * {secondNumber}: Answered incorrectly");
                    }
                    break;
                case 4:
                    bool divisible = false;
                    
                    while (!divisible)
                    {
                    firstNumber = random.Next(1, 101);
                    secondNumber = random.Next(1, 101);
                    if (firstNumber % secondNumber == 0)
                    {
                    Console.WriteLine($"{firstNumber} / {secondNumber} = ?");
                    Int32.TryParse(Console.ReadLine(), out answer);
                        if (answer == (firstNumber / secondNumber))
                        {  
                            Console.WriteLine("Correct!");
                            gameHistory.Add($"{firstNumber} / {secondNumber}: Answered correctly");
                            score += 5;
                        }
                        else
                        {
                            Console.WriteLine("Wrong!!!");
                            gameHistory.Add($"{firstNumber} / {secondNumber}: Answered incorrectly");
                        }
                        divisible = true;
                    }
                    }
                        break;
                case 5:
                    foreach(var i in gameHistory)
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine($"Your current score is {score}");
                        break;
                case 6:
                    Console.WriteLine($"Your total score was {score}");
                    Console.WriteLine("Goodbye");
                    stillPlaying = false;
                    break;

            }
        }
        }
}
}