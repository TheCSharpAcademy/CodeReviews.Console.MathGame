/* BEM VINDO AO MEU JOGUINHO SILLY DE MATEMATICA!!!!! BY: MOTHNUE
    
    Se voce quiser entender a logica por tras dos metodos Somar(), Subtrair, etc.. 
    Apenas Leia os comentarios que deixei no metodo Somar(), nao deixei nos outros porque todos eles seguem o mesmo modelo, oque muda seria o operador.
    
    
*/


using System;
using System.Timers;

class Program
{
    // Random variable to generate numbers
    static Random random = new Random();
    static List<string> historyArray = new List<string>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Welcome to the math game. My first project in C# btw.");
            Menu();
            string userInput = Console.ReadLine().Trim();

            switch (userInput)
            {
                case "1":
                    Add();
                    break;
                case "2":
                    Subtract();
                    break;
                case "3":
                    Multiply();
                    break;
                case "4":
                    Divide();
                    break;
                case "9":
                    Console.WriteLine("History:");
                    foreach (string item in historyArray)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "0":
                    Console.WriteLine("Thank you for playing. See you soon!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }



    static void Add()
    {
        int score = 0;

        // Displays the difficulty menu and gets the user's choice
        DifficultyMenu();
        string input = Console.ReadLine();

        // Gets the difficulty based on the user's choice
        int diff = GetDifficulty(input);

        // Generates 10 questions and checks the user's answers
        for (int i = 0; i < 10; i++)
        {
            // Generates two random numbers within the difficulty range
            int x = random.Next(1, diff);
            int y = random.Next(1, diff);
            int result = x + y;

            // Displays the question to the user
            Console.WriteLine($"{x} + {y} = ?");

            int usr;

            // Loop to ensure that the user's input is a valid integer
            while (true)
            {
                Console.Write("Your answer: ");
                string userInput = Console.ReadLine();
                historyArray.Add($"{x} + {y} = {result} | Your answer: {userInput}");

                // Tries to convert the user's input to an integer
                if (int.TryParse(userInput, out usr))
                {
                    break; // Exits the loop if the conversion is successful
                }
                else
                {
                    Console.WriteLine("Please enter a valid numeric value.");
                }
            }

            // Checks if the user's answer is correct and updates the score
            if (usr == result)
            {
                score++;
            }
        }

        // Displays the final score to the user
        Console.WriteLine($"Your final score is {score}");
    }



    static void Subtract()
    {
        int score = 0;

        DifficultyMenu();
        string input = Console.ReadLine();

        int diff = GetDifficulty(input);

        for (int i = 0; i < 10; i++)
        {
            int x = random.Next(1, diff);
            int y = random.Next(1, diff);
            int result = x - y;

            Console.WriteLine($"{x} - {y} = ?");

            int usr;
            while (true)
            {
                Console.Write("Your answer: ");
                string userInput = Console.ReadLine();
                historyArray.Add($"{x} - {y} = {result} | Your answer: {userInput}");

                if (int.TryParse(userInput, out usr))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect value.");
                }
            }

            if (usr == result)
            {
                score++;
            }
        }

        Console.WriteLine($"Your Score is {score}");
    }


    static void Multiply()
    {
        int score = 0;

        DifficultyMenu();
        string input = Console.ReadLine();

        int diff = GetDifficulty(input);

        for (int i = 0; i < 10; i++)
        {
            int x = random.Next(1, diff);
            int y = random.Next(1, diff);
            int result = x * y;

            Console.WriteLine($"{x} x {y} = ?");

            int usr;
            while (true)
            {
                Console.Write("Your answer: ");
                string userInput = Console.ReadLine();

                historyArray.Add($"{x} x {y} = {result} | Your answer: {userInput}");

                if (int.TryParse(userInput, out usr))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect value.");
                }
            }

            if (usr == result)
            {
                score++;
            }
        }

        Console.WriteLine($"Your Score is {score}");
    }


    static void Divide()
    {
        int score = 0;

        DifficultyMenu();
        string input = Console.ReadLine();

        int diff = GetDifficulty(input);

        for (int i = 0; i < 10; i++)
        {
            int number1, number2;
            int result;
            do
            {
                number2 = random.Next(1, diff);
                number1 = number2 * random.Next(2, diff);
                result = number1 / number2;
            } while (number1 % 2 != 0 || number2 % 2 != 0);
            



            Console.WriteLine($"{number1} / {number2} = ?");

            int usr;
            while (true)
            {
                Console.Write("Your answer: ");
                string userInput = Console.ReadLine();

                historyArray.Add($"{number1} / {number2} = {result} | Your answer: {userInput}");

                if (int.TryParse(userInput, out usr))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect value.");
                }
            }

            if (usr == result)
            {
                score++;
            }
        }

        Console.WriteLine($"Your Score is {score}");
    }


    static int GetDifficulty(string input)
    {
        int diff = 0;

        switch (input)
        {
            case "1":
                diff = 10;
                break;
            case "2":
                diff = 20;
                break;
            case "3":
                diff = 30;
                break;
            default:
                Console.WriteLine("Invalid difficulty option. Setting to Easy by default.");
                diff = 10;
                break;
        }
        return diff;
    }

    static void Menu()
    {
        Console.WriteLine("╔═════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                       Choose an option:                     ║");
        Console.WriteLine("║                                                             ║");
        Console.WriteLine("║   1 - Add                                                    ║");
        Console.WriteLine("║   2 - Subtract                                               ║");
        Console.WriteLine("║   3 - Multiply                                               ║");
        Console.WriteLine("║   4 - Divide                                                 ║");
        Console.WriteLine("║   9 - History                                                ║");
        Console.WriteLine("║   0 - Exit                                                   ║");
        Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");
    }

    static void DifficultyMenu()
    {
        Console.WriteLine("---------------------------------------------------------------");
        Console.WriteLine("Choose a difficulty for the math operations:");
        Console.WriteLine("1 - Easy");
        Console.WriteLine("2 - Medium");
        Console.WriteLine("3 - Hard");
        Console.WriteLine("---------------------------------------------------------------");
    }
}