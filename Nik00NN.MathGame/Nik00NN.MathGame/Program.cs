using Nik00NN.MathGame;
Console.WriteLine("Enter your username :");
string username = Console.ReadLine();
var date = DateTime.UtcNow;
bool IsGameOn = true;
var games = new List<string>();
Validator validator = new Validator();
int difficulty = validator.SetDifficultyLevel();

while (IsGameOn)
{
    Menu(username);
}

void Menu(string username)
{
    Console.Clear();
    Console.WriteLine($"Hello {username}, it's {date} ! What game would u like to play today ?\n");
    Console.WriteLine(@"Select one from the list below:
                      A-Addition
                      S-Substraction
                      M-Multiplication
                      D-Division
                      V-View Game History
                      Q-Quit the program");
    Console.WriteLine("--------------------------------------------");
    SelectGame(difficulty);
   
}
void SelectGame(int difficulty)
{
    string select = Console.ReadLine().ToUpper().Trim();

    switch (select)
    {
        case "A":
            AdditionGame(difficulty);
            break;
        case "S":
            SubstractionGame(difficulty);
            break;
        case "M":
            MultiplicationGame(difficulty);
            break;
        case "D":
            DivisionGame(difficulty);
            break;
        case "Q":
            Console.WriteLine("GoodBye");
            IsGameOn = false;
            break;
        case "V":
            ViewGameHistory();
            break;
        default:
            Console.WriteLine("Invalid input");
            break;
    }

}
void AdditionGame(int difficulty)
{
    Console.Clear();
    Console.WriteLine("Addition game selected ");

    int score = 0;
    bool again = true;

    while (again)
    {
        int firstNumber = new Random().Next(99) * (int)Math.Pow(10, difficulty) + new Random().Next(100);
        int secondNumber = new Random().Next(99) * (int)Math.Pow(10, difficulty) + new Random().Next(100);
        int result;
       
            Console.WriteLine($"{firstNumber} + {secondNumber} = ");
        
            if (int.TryParse(Console.ReadLine(), out result))
            {
                if (result == firstNumber + secondNumber)
                {
                    Console.WriteLine("your answer is correct");
                    score++;
                }
                else
                {
                    Console.WriteLine("your answer is incorrect");
                    Console.WriteLine($"Answer was : {firstNumber + secondNumber}");
                }
            }
            else
            {
                Console.WriteLine("You must enter a valid number");
            }

            Console.WriteLine("--------");
            Console.WriteLine("Type Yes if you want to play again");
            Console.WriteLine("Type anything else and press enter  to quit.");

            string select = Console.ReadLine().ToLower();

            if (select != "yes")
            {
                games.Add($"Date: {date} GameType: Addition Score:{score}");
                again = false;

                Console.WriteLine("Thank you for playing!");
                Console.WriteLine("Type any key to be redirected to main menu");
                Console.ReadKey();
            }
    }
}
void DivisionGame(int difficulty)
{
    Console.Clear();
    Console.WriteLine("Division Game selected ");
    int score = 0;
    bool again = true;
    while (again)
    {
        int firstNumber = new Random().Next(99) * (int)Math.Pow(10, difficulty) + new Random().Next(100);
        int secondNumber = new Random().Next(99) * (int)Math.Pow(10, difficulty) + new Random().Next(100);
        int result;
        
            while (firstNumber % secondNumber != 0 && firstNumber != secondNumber)
            {
                firstNumber = new Random().Next(99) * (int)Math.Pow(10, difficulty) + new Random().Next(100);
                secondNumber = new Random().Next(99) * (int)Math.Pow(10, difficulty) + new Random().Next(100);
            }

            Console.WriteLine($"{firstNumber} / {secondNumber} = ");
            if(int.TryParse(Console.ReadLine(), out result))
            {
                if(result == firstNumber /secondNumber)
                {
                    Console.WriteLine("your answer is correct");
                    score++;
                } 
                else 
                {
                    Console.WriteLine("your answer is incorrect");
                    Console.WriteLine($"Answer was : {firstNumber / secondNumber}");
                }
            }
            else
            {
                Console.WriteLine("You must enter a valid number");
            }
            Console.WriteLine("-------");
            Console.WriteLine("Type Yes if you want to play again");
            Console.WriteLine("Type anything else and press enter  to quit.");

        string select = Console.ReadLine().ToLower();

        if (select != "yes")
        {
            games.Add($"Date: {date} GameType: Division Score:{score}");
            again = false;

            Console.WriteLine("Thank you for playing!");
            Console.WriteLine("Type any key to be redirected to main menu");
            Console.ReadKey();
        }

    }
}
void MultiplicationGame(int difficulty)
{
    Console.Clear();
    Console.WriteLine("Multiplication Game selected ");
    int score = 0;
    bool again = true;
   
    while (again)
    {
        int firstNumber = new Random().Next(9) * (int)Math.Pow(10, difficulty) + new Random().Next(9);
        int secondNumber = new Random().Next(9) * (int)Math.Pow(10, difficulty) + new Random().Next(9);
        int result;

        Console.WriteLine($"{firstNumber} * {secondNumber} = ");

        if (int.TryParse(Console.ReadLine(), out result))
        {
            if (result == firstNumber * secondNumber)
            {
                Console.WriteLine("your answer is correct");
                score++;
            }
            else
            {
                Console.WriteLine("your answer is incorrect");
                Console.WriteLine($"Answer was : {firstNumber * secondNumber}");
            }
        }
        else
        {
            Console.WriteLine("You must enter a valid number");
        }

        Console.WriteLine("-------");
        Console.WriteLine("Type Yes if you want to play again");
        Console.WriteLine("Type anything else and press enter  to quit.");

        string select = Console.ReadLine().ToLower();
        if (select != "yes")
        {
            games.Add($"Date: {date} GameType: Multiplication Score:{score}");
            again = false;

            Console.WriteLine("Thank you for playing!");
            Console.WriteLine("Type any key to be redirected to main menu");
            Console.ReadKey();
        }

    }
}
void SubstractionGame(int difficulty)
{
    Console.Clear();
    Console.WriteLine("Substraction Game selected ");
    int score = 0;
    bool again = true;

    while (again)
    {
        int firstNumber = new Random().Next(9) * (int)Math.Pow(10, difficulty) + new Random().Next(99);
        int secondNumber = new Random().Next(9) * (int)Math.Pow(10, difficulty) + new Random().Next(99);
        int result;
        
            Console.WriteLine($"{firstNumber} - {secondNumber} = ");



            if (int.TryParse(Console.ReadLine(), out result))
            {
                if (result == firstNumber - secondNumber)
                {
                    Console.WriteLine("your answer is correct");
                    score++;
                }
                else
                {
                    Console.WriteLine("your answer is incorrect");
                    Console.WriteLine($"Answer was : {firstNumber - secondNumber}");
                }
            }
            else
            {
                Console.WriteLine("You must enter a valid number");
            }

            Console.WriteLine("-------");
            Console.WriteLine("Type Yes if you want to play again");
            Console.WriteLine("Type anything else and press enter to quit.");

        string select = Console.ReadLine().ToLower();

        if (select != "yes")
        {
            games.Add($"Date: {date} GameType: Substraction Score:{score}");
            again = false;

            Console.WriteLine("Thank you for playing!");
            Console.WriteLine("Type any key to be redirected to main menu");
            Console.ReadKey();
        }

    }
}
void ViewGameHistory()
{
    Console.Clear();
    Console.WriteLine("Game History :");
    foreach (var game in games)
    {
        Console.WriteLine(game);
    }
    Console.WriteLine("Press enter to go back to main menu");
    Console.ReadLine();
}






