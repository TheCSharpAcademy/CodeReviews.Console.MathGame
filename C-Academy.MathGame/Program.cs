/*

 You need to create a Math game containing the 4 basic operations

 The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100.
 Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.

 Users should be presented with a menu to choose an operation

 You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.

 You don't need to record results on a database. Once the program is closed the results will be deleted.

*/
using System.Buffers;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Transactions;
using System.Xml.XPath;
using MathGame;

List<string> records = new List<string>();
bool exit = false;
int selectedChallenge = -1;
string? menuSelection;
Level level;

do
{
    Console.Clear();
    ShowMenuOptions();

    // Loops continues until 'exit' or menu option number is entered
    do
    {
        menuSelection = Console.ReadLine();

        //Code Proceeds further when menu selected format is correct and in the range of(1 - 6)
        if (int.TryParse(menuSelection, out selectedChallenge))
        {
            if (selectedChallenge > 0 && selectedChallenge < 6)
            {
                // Level for the game is selected 
                level = SelectLevel();

                // Let's the user pick the number of question
                int numberOfQuestions = NumberOfQuestions();

                // Game is played from here
                PlayGame(selectedChallenge, level, numberOfQuestions);
            }
            else if(selectedChallenge == 6)
            {
                Console.Clear();
                foreach (var record in records)
                {
                    Console.WriteLine(record);
                    Console.WriteLine();
                }

                Console.ReadLine();
            }


        }
        else if (menuSelection?.ToLower() == "exit")
        {
            exit = true;
            break;
        }
        else
        {
            Console.WriteLine("Please select the valid option from 1 - 6");
        }

    } while (selectedChallenge < 1 || selectedChallenge > 6);
}
while (exit == false);



void ShowMenuOptions()
{
    Console.Clear();

    Console.WriteLine("\t\t--- MATH GAME ---".PadLeft(25) + "\n");
    Console.WriteLine("Press '1' for Addition Challenge.");
    Console.WriteLine("Press '2' for Subtraction Challenge.");
    Console.WriteLine("Press '3' for Multiplication Challenge.");
    Console.WriteLine("Press '4' for Division Challenge.");
    Console.WriteLine("Press '5' for Random Challenge.");
    Console.WriteLine("Press '6' for viewing a history of previous games.\n");
    Console.WriteLine("\t\tEnter 'exit' to exit the game.\n");
}

Level SelectLevel()
{
    Console.Clear();
    Console.WriteLine("Enter Difficulty Level: ");
    Console.WriteLine("Press '1' for Easy");
    Console.WriteLine("Press '2' for Medium");
    Console.WriteLine("Press '3' for Hard\n");

    int levelSelected = -1;

    do
    {
        string? level = Console.ReadLine();

        if (int.TryParse(level, out levelSelected))
        {
            switch (levelSelected)
            {
                case 1:
                    return Level.Easy;

                case 2:
                    return Level.Medium;

                case 3:
                    return Level.Hard;
            }

        }

        Console.WriteLine("\nPlease Enter value from 1 - 3");

    } while (levelSelected < 1 || levelSelected > 3);

    return Level.Easy;
}

void PlayGame(int selectedChallenge, Level level, int numOfQuestions)
{
    char operation;
    int score;

    //switch based on what kind of challenge Users want
    switch (selectedChallenge)
    {
        case 1:
            operation = '+';
            score = AskQuestions(level, numOfQuestions, operation);

            Console.WriteLine($"Your Total Score in this round = {score}");
            Console.ReadLine();

            break;

        case 2:
            operation = '-';
            score = AskQuestions(level, numOfQuestions, operation);
            
            Console.WriteLine($"Your Total Score in this round = {score}");
            Console.ReadLine();
            break;

        case 3:
            operation = '*';
            score = AskQuestions(level, numOfQuestions, operation);
            
            Console.WriteLine($"Your Total Score in this round = {score}");
            Console.ReadLine();
            break;

        case 4:
            operation = '/';
            score = AskQuestions(level, numOfQuestions, operation);
            
            Console.WriteLine($"Your Total Score in this round = {score}");
            Console.ReadLine();
            break;

        case 5:
            operation = 'r';
            
            score = AskQuestions(level, numOfQuestions, operation, true);
            
            Console.WriteLine($"Your Total Score in this round = {score}");
            Console.ReadLine();
            break;

    }
}

int AskQuestions(Level difficulty, int numOfQuestions, char operation, bool randomOperation = false)
{
    int score = 0;
    int i = 0;
    int firstInt = 0;
    int secondInt = 0;
    int answer = 0;
    int range = 0;

    int result = 0;
    Random random = new Random();
    Stopwatch stopwatch = new Stopwatch();

    switch (difficulty)
    {
        case Level.Easy:
            range = (int)Level.Easy; // for easy questions 'firstInt' and 'secondInt' are from with in the range of 1 - 10;
            break;

        case Level.Medium:
            range = (int)Level.Medium;// for easy questions 'firstInt' and 'secondInt' are from with in the range of 1 - 30;
            break;

        case Level.Hard:
            range = (int)Level.Hard;// for easy questions 'firstInt' and 'secondInt' are from with in the range of 1 - 60;
            break;
    }

    while (i < numOfQuestions)
    {
        Console.Clear();

        if(randomOperation)
        {
            //Generates the '+', '-', '*', '/' characters randomly
            operation = RandomOperation();
        }

        firstInt = random.Next(1, range);
        secondInt = random.Next(1, range);

        if (operation == '/')
        {
            //dividends should go from 0 to 100. 
            // result of the division from 2 integer should be integer
            while (firstInt < secondInt || (firstInt % secondInt != 0))
            {
                firstInt = random.Next(1, 100);
                secondInt = random.Next(1, range);

                if (firstInt > secondInt && (firstInt % secondInt == 0))
                {
                    break;
                }
            }
        }

        stopwatch.Start();
        Console.WriteLine($"{firstInt} {operation} {secondInt} = ??");

        switch (operation)
        {
            case '+':
                result = firstInt + secondInt;
                break;

            case '-':
                result = firstInt - secondInt;
                break;

            case '*':
                result = firstInt * secondInt;
                break;

            case '/':
                result = firstInt / secondInt;
                break;

        }

        string? userInput = Console.ReadLine();

        if (int.TryParse(userInput, out answer))
        {
            stopwatch.Stop();
            TimeSpan timeTaken = stopwatch.Elapsed;

            string time = $"Time Taken: {timeTaken.ToString(@"m\:ss\.fff")}";
            string status = "";

            if (result == answer)
            {
                score += 5;
                status = $"\nYour answer is right {firstInt} {operation} {secondInt} = {result}\n{time}\nYour Score: {score}";

                //Adding status in the records list for viewing history
                records.Add(status);

                Console.WriteLine(status);
                stopwatch.Reset();
                Console.ReadLine();
            }
            else
            {
                status = $"\nYou are Incorrect\nRight Answer is {result}\n{time}";

                // Adding status in the records list for viewing history

                records.Add(status);
                Console.WriteLine(status);

                stopwatch.Reset();
                Console.ReadLine();
            }
        }
        else
        {
            stopwatch.Stop();
            Console.WriteLine("Try Again!");
            stopwatch.Reset();
            Console.ReadLine();
            continue;
        }

        i++;
    }

    return score;
}

char RandomOperation()
{
    Random random = new Random();
    return random.Next(1, 5) switch
    {
        1 => '+',
        2 => '-',
        3 => '*',
        4 => '/',
        _ => '+'
    };
    
}

int NumberOfQuestions()
{
    int numOfQues = -1;
    Console.Clear();
    Console.WriteLine("--- PICK THE NUMBER OF QUESTION TO BE ASKED ---".PadLeft(10));

    do
    {

        string? userInput = Console.ReadLine();

        if (!int.TryParse(userInput, out numOfQues))
        {
            Console.WriteLine("Please Enter the value greater than 0");
        }

    }
    while (numOfQues <= 0);

    return numOfQues;
}