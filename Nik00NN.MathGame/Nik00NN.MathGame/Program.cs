using System.Transactions;

Console.WriteLine("Enter your username :");
string username = Console.ReadLine();
var date = DateTime.UtcNow;
bool IsGameOn = true;
bool IsRandom = false;
bool RandomON = true;
var games = new List<string>();

Console.WriteLine(@"Set your level of difficulty(1-3):
                    1-Easy
                    2-Medium
                    3-Hard");

int difficulty = Convert.ToInt32(Console.ReadLine());

if (difficulty < 1 || difficulty > 3)
{
    while (difficulty < 1 || difficulty > 3)
    {
        Console.WriteLine("Value must be between 1 and 3");
        Console.WriteLine("Enter another value:");
        difficulty = Convert.ToInt32(Console.ReadLine());
    }

}
void Menu(string username)
{
    Console.Clear();
    Console.WriteLine($"Hello {username} , it's {date} ! What game would u like to play today ?\n");
    Console.WriteLine(@"Select one from the list below:
                      A-Addition
                      S-Substraction
                      M-Multiplication
                      D-Division
                      V-View Game History
                      Q-Quit the program");
    Console.WriteLine("--------------------------------------------");

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
        int firstnumber = new Random().Next(99) * (int)Math.Pow(10, difficulty) + new Random().Next(100);
        int secondnumber = new Random().Next(99) * (int)Math.Pow(10, difficulty) + new Random().Next(100);

        try
        {
            Console.WriteLine($"{firstnumber} + {secondnumber} = ");
            string result = Console.ReadLine();

            if (Convert.ToInt32(result) == firstnumber + secondnumber)
            {
                Console.WriteLine("your answer was correct ");
                score++;
            }
            else
                Console.WriteLine("your answer was incorrect");

            Console.WriteLine("--------");
            Console.WriteLine("Do you want to play again?(Yes/No)");

            string select = Console.ReadLine().ToLower();

            if (select == "no")
            {
                games.Add($"Date: {date} GameType: Addition Score:{score}");
                again = false;

                Console.WriteLine("Thank you for playing!");
                Console.WriteLine("Type any key to be redirected to main menu");
                Console.ReadKey();
            }
        }
        catch (Exception ex) { Console.WriteLine("You must enter a number"); }
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
        int firstnumber = new Random().Next(99) * (int)Math.Pow(10, difficulty) + new Random().Next(100);
        int secondnumber = new Random().Next(99) * (int)Math.Pow(10, difficulty) + new Random().Next(100); ;

        try
        {
            while (firstnumber % secondnumber != 0)
            {
                firstnumber = new Random().Next(99) * (int)Math.Pow(10, difficulty) + new Random().Next(100);
                secondnumber = new Random().Next(99) * (int)Math.Pow(10, difficulty) + new Random().Next(100);
            }

            Console.WriteLine($"{firstnumber} / {secondnumber} = ");

            string result = Console.ReadLine();

            if (Convert.ToInt32(result) == firstnumber / secondnumber)
            {
                Console.WriteLine("your answer is correct");
                score++;
            }
            else
                Console.WriteLine("your answer is incorrect");

            Console.WriteLine("-------");
            Console.WriteLine("Do you want to play again?(Yes/No)");

            string select = Console.ReadLine().ToLower();

            if (select == "no")
            {
                games.Add($"Date: {date} GameType: Division Score:{score}");
                again = false;
                Console.WriteLine("Thank you for playing");
                Console.WriteLine("Type any key to be redirected to main menu");
                Console.ReadKey();
            }
        }
        catch (Exception ex) { Console.WriteLine("You must enter a number"); }
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
        int firstnumber = new Random().Next(9) * (int)Math.Pow(10, difficulty) + new Random().Next(9);
        int secondnumber = new Random().Next(9) * (int)Math.Pow(10, difficulty) + new Random().Next(9);

        try
        {

            Console.WriteLine($"{firstnumber} * {secondnumber} = ");

            string result = Console.ReadLine();

            if (Convert.ToInt32(result) == firstnumber * secondnumber)
            {
                Console.WriteLine("your answer is correct");
                score++;
            }
            else
                Console.WriteLine("your answer is incorrect");

            Console.WriteLine("-------");
            Console.WriteLine("Do you want to play again?(Yes/No)");

            string select = Console.ReadLine().ToLower();
            if (select == "no")
            {
                games.Add($"Date: {date} GameType: Multiplication Score:{score}");
                again = false;
                Console.WriteLine("Thank you for playing");
                Console.WriteLine("Type any key to be redirected to main menu");
                Console.ReadKey();
            }
        }
        catch (Exception ex) { Console.WriteLine("You must enter a number"); }
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
        int firstnumber = new Random().Next(9) * (int)Math.Pow(10, difficulty) + new Random().Next(99);
        int secondnumber = new Random().Next(9) * (int)Math.Pow(10, difficulty) + new Random().Next(99);

        try
        {
            Console.WriteLine($"{firstnumber} - {secondnumber} = ");

            string result = Console.ReadLine();

            if (Convert.ToInt32(result) == firstnumber - secondnumber)
            {
                Console.WriteLine("your answer is correct");
                score++;
            }
            else
                Console.WriteLine("your answer is incorrect");

            Console.WriteLine("-------");
            Console.WriteLine("Do you want to play again?(Yes/No)");

            string select = Console.ReadLine().ToLower();

            if (select == "no")
            {
                games.Add($"Date: {date} GameType: Substraction Score:{score}");
                again = false;
                Console.WriteLine("Thank you for playing");
                Console.WriteLine("Type any key to be redirected to main menu");
                Console.ReadKey();
            }
        }
        catch (Exception ex) { Console.WriteLine("You must enter a number"); }
    }
}
void ViewGameHistory()
{
    Console.Clear();
    Console.WriteLine("Game History :");
    foreach (var game in games)
        Console.WriteLine(game);

    Console.WriteLine("Press enter to go back to main menu");
    Console.ReadLine();
}
while (IsGameOn)
{
    Menu(username);
}







