using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    static List<string> playerHistory = [];
    static Random random = new();
    static Stopwatch stopWatch = new();
    static List<int> basicDivisionNumbers = [];
    static List<int> hardDivisionNumbers = [];
    private static void Main(string[] args)
    {
        setupDivisionTables();
        LoadingScreen();
        while (true)
        {
            DisplayMenu();
        }
    }

    static void LoadingScreen()
    {
        var loadingTexts = new List<string>() { "Cheking system requirements", "Initializing CPU", "Heating up the GPU", "Diagnosing AI integrity", "Calculating Mars retro", "Feeding internal Bugs" };
        bool notcompleted = true;
        foreach (string s in loadingTexts)
        {
            Console.Write(s);
            stopWatch.Restart();
            while (notcompleted)
            {
                stopWatch.Stop();
                if (stopWatch.ElapsedMilliseconds > 500)
                    notcompleted = false;
                stopWatch.Start();
            }
            Console.Write("\t\tOK\n");
            notcompleted = true;
        }

        Console.WriteLine("Press Enter to start...");
        Console.ReadLine();
    }

    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine(@"    __  ___      __  __         ______                          __               ____             __ __ _________
   /  |/  /___ _/ /_/ /_       / ____/___ _____ ___  ___       / /_  __  __     / __ \____  _____/ // /<  / ____/
  / /|_/ / __ `/ __/ __ \     / / __/ __ `/ __ `__ \/ _ \     / __ \/ / / /    / / / / __ \/ ___/ // /_/ /___ \  
 / /  / / /_/ / /_/ / / /    / /_/ / /_/ / / / / / /  __/    / /_/ / /_/ /    / /_/ / /_/ / /__/__  __/ /___/ /  
/_/  /_/\__,_/\__/_/ /_/     \____/\__,_/_/ /_/ /_/\___/    /_.___/\__, /    /_____/\____/\___/  /_/ /_/_____/   
                                                                  /____/                                        ");
        Console.WriteLine(@"

                            Welcome to Math Game
                            Choose operation to play
                            ------------------------
                            A  Addition
                            S  Subtraction
                            M  Multiplication
                            D  Division
                            R  Random operation
                            H  History of the games you played  
                            Q  Quit game
                            ");
        var validSelection = false;
        while (!validSelection)
        {
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.A:
                    validSelection = true;
                    CallAddition();
                    break;
                case ConsoleKey.S:
                    validSelection = true;
                    CallSubtraction();
                    break;
                case ConsoleKey.M:
                    validSelection = true;
                    CallMultiplication();
                    break;
                case ConsoleKey.D:
                    validSelection = true;
                    CallDivision();
                    break;
                case ConsoleKey.R:
                    validSelection = true;
                    CallRandom();
                    break;
                case ConsoleKey.H:
                    validSelection = true;
                    ShowHistory();
                    break;
                case ConsoleKey.Q:
                    System.Environment.Exit(0);
                    break;
                default:
                    validSelection = false;
                    break;
            }
        }
    }

    static bool GetDifficulty()
    {
        var ValidSelection = false;
        while (!ValidSelection)
        {
            Console.Clear();
            Console.WriteLine(@"



                           Select difficulty level
                           -----------------------
                           A  Easy
                           B  Hard
                         ");
            var selection = Console.ReadKey(true).Key;
            switch (selection)
            {
                case ConsoleKey.A:
                    return false;
                case ConsoleKey.B:
                    return true;
                default:
                    ValidSelection = false;
                    break;
            }
        }
        return true;
    }

    static int GetQuestionCount()
    {
        bool validInput = false;
        while (!validInput)
        {
            Console.Clear();
            Console.WriteLine(@"



                           How many questions do you want me to ask?
                           -----------------------------------------
                           ");
            Console.Write("                           Enter number of questions:");
            string input = Console.ReadLine();
            var isInputInt = Int32.TryParse(input, out int number);
            if (isInputInt)
            {
                return number;
            }
            else
            {
                validInput = false;
            }

        }
        return 0;

    }
    static void CallAddition()
    {
        var difficult = GetDifficulty();
        int questionsNumber = GetQuestionCount();
        Console.Clear();
        string gameOperator = "Addition";
        int firstNumber;
        int secondNumber;
        TimeSpan reactionTime;
        for (int i = 0; i < questionsNumber; i++)
        {
            bool validInput = false;
            bool answer = false;
            if (difficult)
            {
                firstNumber = random.Next(1, 1000);
                secondNumber = random.Next(1, 1000);
            }
            else
            {
                firstNumber = random.Next(1, 100);
                secondNumber = random.Next(1, 100);
            }
            while (!validInput)
            {
                Console.Clear();
                Console.Write($@"




                                {firstNumber} + {secondNumber} = ");
                stopWatch.Restart();
                string input = Console.ReadLine();
                stopWatch.Stop();
                reactionTime = stopWatch.Elapsed;
                var isInputInt = Int32.TryParse(input, out int result);
                if (isInputInt)
                {
                    validInput = true;
                    if (result == firstNumber + secondNumber)
                    {
                        Console.WriteLine("\n\n\t\t\t\tCorrect!");
                        Console.WriteLine($"\n\n\t\t\t\tReaction time: {reactionTime.Seconds} sec.");
                        Console.WriteLine("\n\n\t\t\t\tPress Enter to continue.");
                        answer = true;
                    }
                    else
                    {
                        Console.WriteLine($"\n\n\t\t\tWrong answer. It should be {firstNumber + secondNumber}");
                        Console.WriteLine($"\n\n\t\t\tReaction time: {reactionTime.Seconds} sec.");
                        Console.WriteLine("\n\n\t\t\tPress Enter to continue.");
                        answer = false;
                    }
                    string difficulty = difficult ? "Hard" : "Easy";
                    string answered = answer ? "Correct" : "Wrong";
                    string history = string.Format("{0,-15} {1,-15} {2, -15} {3, -15} {4,-15} {5,-1} {6,-5}", gameOperator,
                    difficulty, $"{firstNumber} + {secondNumber} = ?", result, answered, reactionTime.Seconds,"sec");
                    playerHistory.Add(history);
                    Console.ReadLine();
                }
                else
                {
                    validInput = false;
                }

            }
        }

    }

    static void CallSubtraction()
    {
        var difficult = GetDifficulty();
        int questionsNumber = GetQuestionCount();
        Console.Clear();
        string gameOperator = "Subtraction";
        int firstNumber = 0;
        int secondNumber = 0;
        TimeSpan reactionTime;
        for (int i = 0; i < questionsNumber; i++)
        {
            bool validInput = false;
            bool answer = false;
            if (difficult)
            {
                bool notValidNumbers = true;
                while (notValidNumbers)
                {
                    firstNumber = random.Next(1, 1000);
                    secondNumber = random.Next(1, 1000);
                    notValidNumbers = (firstNumber - secondNumber <= 0);
                }
            }
            else
            {
                bool notValidNumbers = true;
                while (notValidNumbers)
                {
                    firstNumber = random.Next(1, 100);
                    secondNumber = random.Next(1, 100);
                    notValidNumbers = (firstNumber - secondNumber <= 0);
                }
            }
            while (!validInput)
            {
                Console.Clear();
                Console.Write($@"




                                {firstNumber} - {secondNumber} = ");
                stopWatch.Restart();
                string input = Console.ReadLine();
                stopWatch.Stop();
                reactionTime = stopWatch.Elapsed;
                var isInputInt = Int32.TryParse(input, out int result);
                if (isInputInt)
                {
                    validInput = true;
                    if (result == firstNumber - secondNumber)
                    {
                        Console.WriteLine("\n\n\t\t\t\tCorrect!");
                        Console.WriteLine($"\n\n\t\t\t\tReaction time: {reactionTime.Seconds} sec.");
                        Console.WriteLine("\n\n\t\t\t\tPress Enter to continue.");
                        answer = true;
                    }
                    else
                    {
                        Console.WriteLine($"\n\n\t\t\tWrong answer. It should be {firstNumber - secondNumber}");
                        Console.WriteLine($"\n\n\t\t\tReaction time: {reactionTime.Seconds} sec.");
                        Console.WriteLine("\n\n\t\t\tPress Enter to continue.");
                        answer = false;
                    }
                    string difficulty = difficult ? "Hard" : "Easy";
                    string answered = answer ? "Correct" : "Wrong";
                    string history = string.Format("{0,-15} {1,-15} {2, -15} {3, -15} {4,-15} {5,-1} {6,-5}", gameOperator,
                     difficulty, $"{firstNumber} - {secondNumber} = ?", result, answered, reactionTime.Seconds, "sec");
                    playerHistory.Add(history);
                    Console.ReadLine();
                }
                else
                {
                    validInput = false;
                }

            }
        }
    }

    static void CallMultiplication()
    {
        var difficult = GetDifficulty();
        int questionsNumber = GetQuestionCount();
        string gameOperator = "Multiplication";
        Console.Clear();
        int firstNumber;
        int secondNumber;
        TimeSpan reactionTime;
        for (int i = 0; i < questionsNumber; i++)
        {
            bool validInput = false;
            bool answer = false;
            if (difficult)
            {
                firstNumber = random.Next(2, 100);
                secondNumber = random.Next(2, 100);
            }
            else
            {
                firstNumber = random.Next(2, 10);
                secondNumber = random.Next(2, 10);
            }
            while (!validInput)
            {
                Console.Clear();
                Console.Write($@"




                                {firstNumber} x {secondNumber} = ");
                stopWatch.Restart();
                string input = Console.ReadLine();
                stopWatch.Stop();
                reactionTime = stopWatch.Elapsed;
                var isInputInt = Int32.TryParse(input, out int result);
                if (isInputInt)
                {
                    validInput = true;
                    if (result == firstNumber * secondNumber)
                    {
                        Console.WriteLine("\n\n\t\t\t\tCorrect!");
                        Console.WriteLine($"\n\n\t\t\t\tReaction time: {reactionTime.Seconds} sec.");
                        Console.WriteLine("\n\n\t\t\t\tPress Enter to continue.");
                        answer = true;
                    }
                    else
                    {
                        Console.WriteLine($"\n\n\t\t\tWrong answer. It should be {firstNumber * secondNumber}");
                        Console.WriteLine($"\n\n\t\t\tReaction time: {reactionTime.Seconds} sec.");
                        Console.WriteLine("\n\n\t\t\tPress Enter to continue.");
                        answer = false;
                    }
                    string difficulty = difficult ? "Hard" : "Easy";
                    string answered = answer ? "Correct" : "Wrong";
                    string history = string.Format("{0,-15} {1,-15} {2, -15} {3, -15} {4,-15} {5,-1} {6,-5}", gameOperator,
                     difficulty, $"{firstNumber} * {secondNumber} = ?", result, answered, reactionTime.Seconds, "sec");
                    playerHistory.Add(history);
                    Console.ReadLine();
                }
                else
                {
                    validInput = false;
                }

            }
        }
    }

    static void CallDivision()
    {
        var difficult = GetDifficulty();
        int questionsNumber = GetQuestionCount();
        string gameOperator= "Division";
        Console.Clear();
        int firstNumber;
        int secondNumber;
        TimeSpan reactionTime;
        for (int i = 0; i < questionsNumber; i++)
        {
            bool validInput = false;
            bool answer = false;
            if (difficult)
            {
                firstNumber = hardDivisionNumbers[random.Next(0, hardDivisionNumbers.Count)];
                secondNumber = getFromPrimeFactors(firstNumber);
            }
            else
            {
                firstNumber = basicDivisionNumbers[random.Next(0, basicDivisionNumbers.Count)];
                secondNumber = getFromPrimeFactors(firstNumber);
            }
            while (!validInput)
            {
                Console.Clear();
                Console.Write($@"




                                {firstNumber} / {secondNumber} = ");
                stopWatch.Restart();
                string input = Console.ReadLine();
                stopWatch.Stop();
                reactionTime = stopWatch.Elapsed;
                var isInputInt = Int32.TryParse(input, out int result);
                if (isInputInt)
                {
                    validInput = true;
                    if (result == firstNumber / secondNumber)
                    {
                        Console.WriteLine("\n\n\t\t\t\tCorrect!");
                        Console.WriteLine($"\n\n\t\t\t\tReaction time: {reactionTime.Seconds} sec.");
                        Console.WriteLine("\n\n\t\t\t\tPress Enter to continue.");
                        answer = true;
                    }
                    else
                    {
                        Console.WriteLine($"\n\n\t\t\tWrong answer. It should be {firstNumber / secondNumber}");
                        Console.WriteLine($"\n\n\t\t\tReaction time: {reactionTime.Seconds} sec.");
                        Console.WriteLine("\n\n\t\t\tPress Enter to continue.");
                        answer = false;
                    }
                    string difficulty = difficult ? "Hard" : "Easy";
                    string answered = answer ? "Correct" : "Wrong";
                    string history = string.Format("{0,-15} {1,-15} {2, -15} {3, -15} {4,-15} {5,-1} {6,-5}", gameOperator,
                    difficulty, $"{firstNumber} / {secondNumber} = ?", result, answered, reactionTime.Seconds, "sec");
                    playerHistory.Add(history);
                    Console.ReadLine();
                }
                else
                {
                    validInput = false;
                }

            }
        }
    }

    static void ShowHistory()
    {
        Console.Clear();
        Console.WriteLine(@"History
--------
        ");
        Console.WriteLine("Operation\tDifficulty\tQuestion asked\tYour answer\tCorrect/Wrong\tReaction time");
        Console.WriteLine("---------\t----------\t--------------\t-----------\t-------------\t-------------");

        foreach (string history in playerHistory)
        {
            Console.WriteLine(history);
        }
        Console.WriteLine("Press Enter to return menu.");
        Console.ReadLine();
    }

    static void CallRandom()
    {
        int selection = random.Next(0, 4);
        switch (selection)
        {
            case 0: CallAddition(); break;
            case 1: CallMultiplication(); break;
            case 2: CallDivision(); break;
            case 3: CallDivision(); break;
        }
    }

    static void setupDivisionTables()
    {
        for (int i = 4; i < 100; i++)     //prepare numbers list without prime numbers for basic level division
        {
            for (int j = 2; j <= i / 2; j++)
            {
                if (i % j == 0)
                {
                    if (!basicDivisionNumbers.Contains(i))
                        basicDivisionNumbers.Add(i);
                }
            }
        }

        for (int i = 4; i < 1000; i++)     //prepare numbers list without prime numbers for hard level division
        {
            for (int j = 2; j <= i / 2; j++)
            {
                if (i % j == 0)
                {
                    if (!hardDivisionNumbers.Contains(i))
                        hardDivisionNumbers.Add(i);
                }
            }
        }
    }

    static int getFromPrimeFactors(int number)
    {
        List<int> primeFactors = [];
        int i = 2;
        while (number != 1)
        {
            if (number % i == 0)
            {
                primeFactors.Add(i);
                number /= i;
            }
            else
                i++;
        }
        int selector = random.Next(0, primeFactors.Count);
        return primeFactors[selector];
    }
}