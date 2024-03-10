using System.Diagnostics;

string? inputChoice;
string? inputNumber;
string? answer;
int points;
int numberOfQuestions = 3;
List<string> history = new List<string>();
Stopwatch stopWatch = new Stopwatch();
long timeSpan;

Dictionary<string, string> additionEasy = new Dictionary<string, string>
                    {
                        { "8 + 5?", "13" },
                        { "6 + 7?", "13" },
                        { "9 + 8?", "17" }
                    };

Dictionary<string, string> additionMedium = new Dictionary<string, string>
                    {
                        { "25 + 22?", "47" },
                        { "31 + 50?", "81" },
                        { "72 + 19?", "91" }
                    };

Dictionary<string, string> additionHard = new Dictionary<string, string>
                    {
                        { "794 + 100?", "894" },
                        { "216 + 500?", "716" },
                        { "392 + 300?", "692" }
                    };

Dictionary<string, string> subtractionEasy = new Dictionary<string, string>
                    {
                        { "8 - 5?", "3" },
                        { "7 - 6?", "1" },
                        { "10 - 2?", "8" }
                    };

Dictionary<string, string> subtractionMedium = new Dictionary<string, string>
                    {
                        { "25 - 22?", "3" },
                        { "50 - 31?", "19" },
                        { "72 - 19?", "53" }
                    };

Dictionary<string, string> subtractionHard = new Dictionary<string, string>
                    {
                        { "794 - 100?", "694" },
                        { "654 - 400?", "254" },
                        { "992 - 300?", "692" }
                    };

Dictionary<string, string> multiplicationEasy = new Dictionary<string, string>
                    {
                        { "6 * 1?", "6" },
                        { "2 * 5?", "10" },
                        { "2 * 4?", "8" }
                    };

Dictionary<string, string> multiplicationMedium = new Dictionary<string, string>
                    {
                        { "3 * 6?", "18" },
                        { "5 * 6?", "30" },
                        { "7 * 3?", "21" }
                    };

Dictionary<string, string> multiplicationHard = new Dictionary<string, string>
                    {
                        { "16 * 6?", "96" },
                        { "32 * 3?", "96" },
                        { "14 * 7?", "98" }
                    };

Dictionary<string, string> divisionEasy = new Dictionary<string, string>
                    {
                        { "10 / 5?", "2" },
                        { "6 / 3?", "2" },
                        { "9 / 3?", "3" }
                    };

Dictionary<string, string> divisionMedium = new Dictionary<string, string>
                    {
                        { "15 / 3?", "5" },
                        { "24 / 3?", "8" },
                        { "24 / 6?", "4" }
                    };

Dictionary<string, string> divisionHard = new Dictionary<string, string>
                    {
                        { "102 / 17?", "6" },
                        { "316 / 79?", "4" },
                        { "222 / 3?", "74" }
                    };

void PrintQuestions(Dictionary<string, string> questionsAndAnswers)
{
    do
    {
        Console.WriteLine("Specify the number of questions (max 3) or press \"Enter\" to continue: ");
        inputNumber = Console.ReadLine();
        if (inputNumber != "1" && inputNumber != "2" && inputNumber != "3" && inputNumber != "")
            Console.WriteLine("\nInvalid choice! Write a single number (max 3) or leave blank to continue.\n");
    }
    while (inputNumber != "1" && inputNumber != "2" && inputNumber != "3" && inputNumber != "");

    if (inputNumber == "")
        numberOfQuestions = 3;
    else if (inputNumber == "1")
        numberOfQuestions = 1;
    else if (inputNumber == "2")
        numberOfQuestions = 2;
    else if (inputNumber == "3")
        numberOfQuestions = 3;

    points = 0;
    stopWatch.Restart();

    int count = 1;
    foreach (string key in questionsAndAnswers.Keys)
    {
        Console.WriteLine(key);
        answer = Console.ReadLine();

        if (answer == questionsAndAnswers[key])
            points++;

        if (count >= numberOfQuestions)
            break;

        count++;
    }

    stopWatch.Stop();
    timeSpan = stopWatch.ElapsedMilliseconds / 1000;
    Console.WriteLine($"\nYour time: {timeSpan} Seconds");
    Console.WriteLine($"{points} points out of {numberOfQuestions}\n");
}

void GetRandomQuestion(Dictionary<string, string> chosenGroup)
{
    Random random = new Random();
    string randomKey = chosenGroup.Keys.ElementAt(new Random().Next(0, chosenGroup.Count));

    Console.WriteLine(randomKey);
    answer = Console.ReadLine();

    if (answer == chosenGroup[randomKey])
        points++;
}

Console.WriteLine("This is a Math game in which you will need to answer mathematical questions\n");
do
{
    Console.WriteLine("Choose an operation: ");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");
    Console.WriteLine("5. Random game");
    Console.WriteLine("6. History");
    Console.WriteLine("\"exit\" to close the program");

    inputChoice = Console.ReadLine();

    switch (inputChoice)
    {
        case "1":
            do
            {
                Console.WriteLine("Choose difficulty (easy, medium, hard): ");
                inputChoice = Console.ReadLine();
                if (inputChoice != "exit" && inputChoice != "easy" && inputChoice != "medium" && inputChoice != "hard")
                    Console.WriteLine("Invalid choice! Write a single word.\n");
            }
            while (inputChoice != "exit" && inputChoice != "easy" && inputChoice != "medium" && inputChoice != "hard");

            switch (inputChoice)
            {
                case "easy":

                    PrintQuestions(additionEasy);

                    history.Add($"Addition [easy]: {points}/{numberOfQuestions} pts ({timeSpan} seconds)");
                    break;

                case "medium":

                    PrintQuestions(additionMedium);

                    history.Add($"Addition [medium]: {points}/{numberOfQuestions} pts ({timeSpan} seconds)");
                    break;

                case "hard":

                    PrintQuestions(additionHard);

                    history.Add($"Addition [hard]: {points}/{numberOfQuestions} pts ({timeSpan} seconds)");
                    break;

                default:
                    if (inputChoice != "exit")
                        Console.WriteLine("Invalid choice! Write a single word.\n");
                    break;
            }
            break;

        case "2":
            do
            {
                Console.WriteLine("Choose difficulty (easy, medium, hard): ");
                inputChoice = Console.ReadLine();
                if (inputChoice != "exit" && inputChoice != "easy" && inputChoice != "medium" && inputChoice != "hard")
                    Console.WriteLine("Invalid choice! Write a single word.\n");
            }
            while (inputChoice != "exit" && inputChoice != "easy" && inputChoice != "medium" && inputChoice != "hard");

            switch (inputChoice)
            {
                case "easy":

                    PrintQuestions(subtractionEasy);

                    history.Add($"Subtraction [easy]: {points}/{numberOfQuestions} pts ({timeSpan} seconds)");
                    break;

                case "medium":

                    PrintQuestions(subtractionMedium);

                    history.Add($"Subtraction [medium]: {points}/{numberOfQuestions} pts ({timeSpan} seconds)");
                    break;

                case "hard":

                    PrintQuestions(subtractionHard);

                    history.Add($"Subtraction [hard]: {points}/{numberOfQuestions} pts ({timeSpan} seconds)");
                    break;

                default:
                    if (inputChoice != "exit")
                        Console.WriteLine("Invalid choice! Write a single word.\n");
                    break;
            }
            break;

        case "3":
            do
            {
                Console.WriteLine("Choose difficulty (easy, medium, hard): ");
                inputChoice = Console.ReadLine();
                if (inputChoice != "exit" && inputChoice != "easy" && inputChoice != "medium" && inputChoice != "hard")
                    Console.WriteLine("Invalid choice! Write a single word.\n");
            }
            while (inputChoice != "exit" && inputChoice != "easy" && inputChoice != "medium" && inputChoice != "hard");

            switch (inputChoice)
            {
                case "easy":

                    PrintQuestions(multiplicationEasy);

                    history.Add($"Multiplication [easy]: {points}/{numberOfQuestions} pts ({timeSpan} seconds)");
                    break;

                case "medium":

                    PrintQuestions(multiplicationMedium);

                    history.Add($"Multiplication [medium]: {points}/{numberOfQuestions} pts ({timeSpan} seconds)");
                    break;

                case "hard":

                    PrintQuestions(multiplicationHard);

                    history.Add($"Multiplication [hard]: {points}/{numberOfQuestions} pts ({timeSpan} seconds)");
                    break;

                default:
                    if (inputChoice != "exit")
                        Console.WriteLine("Invalid choice! Write a single word.\n");
                    break;
            }
            break;

        case "4":
            do
            {
                Console.WriteLine("Choose difficulty (easy, medium, hard): ");
                inputChoice = Console.ReadLine();
                if (inputChoice != "exit" && inputChoice != "easy" && inputChoice != "medium" && inputChoice != "hard")
                    Console.WriteLine("Invalid choice! Write a single word.\n");
            }
            while (inputChoice != "exit" && inputChoice != "easy" && inputChoice != "medium" && inputChoice != "hard");

            switch (inputChoice)
            {
                case "easy":

                    PrintQuestions(divisionEasy);

                    history.Add($"Subtraction [easy]: {points}/{numberOfQuestions} pts ({timeSpan} seconds)");
                    break;

                case "medium":

                    PrintQuestions(divisionMedium);

                    history.Add($"Subtraction [medium]: {points}/{numberOfQuestions} pts ({timeSpan} seconds)");
                    break;

                case "hard":

                    PrintQuestions(divisionHard);

                    history.Add($"Subtraction [hard]: {points}/{numberOfQuestions} pts ({timeSpan} seconds)");
                    break;

                default:
                    if (inputChoice != "exit")
                        Console.WriteLine("Invalid choice! Write a single word.\n");
                    break;
            }
            break;

        case "5":
            do
            {
                Console.WriteLine("Specify the number of questions (max 10): ");
                inputNumber = Console.ReadLine();
                Console.WriteLine();
                if (inputNumber != "1" && inputNumber != "2" && inputNumber != "3" && inputNumber != "4" && inputNumber != "5" && inputNumber != "6" && inputNumber != "7" && inputNumber != "8" && inputNumber != "9" && inputNumber != "10")
                    Console.WriteLine("Invalid choice! Write a number (max 10).\n");
            }
            while (inputNumber != "1" && inputNumber != "2" && inputNumber != "3" && inputNumber != "4" && inputNumber != "5" && inputNumber != "6" && inputNumber != "7" && inputNumber != "8" && inputNumber != "9" && inputNumber != "10");

            Random random = new Random();
            List<int> selectedGroups = new List<int>();

            numberOfQuestions = int.Parse(inputNumber);
            while (selectedGroups.Count < numberOfQuestions)
            {
                int randomNumber = random.Next(12);
                if (!selectedGroups.Contains(randomNumber))
                {
                    selectedGroups.Add(randomNumber);
                }
            }

            points = 0;
            stopWatch.Restart();

            foreach (int group in selectedGroups)
            {
                switch (group)
                {
                    case 0:
                        GetRandomQuestion(additionEasy);
                        break;
                    case 1:
                        GetRandomQuestion(additionMedium);
                        break;
                    case 2:
                        GetRandomQuestion(additionHard);
                        break;
                    case 3:
                        GetRandomQuestion(subtractionEasy);
                        break;
                    case 4:
                        GetRandomQuestion(subtractionMedium);
                        break;
                    case 5:
                        GetRandomQuestion(subtractionHard);
                        break;
                    case 6:
                        GetRandomQuestion(multiplicationEasy);
                        break;
                    case 7:
                        GetRandomQuestion(multiplicationMedium);
                        break;
                    case 8:
                        GetRandomQuestion(multiplicationHard);
                        break;
                    case 9:
                        GetRandomQuestion(divisionEasy);
                        break;
                    case 10:
                        GetRandomQuestion(divisionMedium);
                        break;
                    case 11:
                        GetRandomQuestion(divisionHard);
                        break;
                }
            }
            stopWatch.Stop();
            timeSpan = stopWatch.ElapsedMilliseconds / 1000;
            Console.WriteLine($"\nYour time: {timeSpan} Seconds");

            Console.WriteLine($"{points} points out of {numberOfQuestions}\n");
            history.Add($"Random Game [{numberOfQuestions} questions]: {points}/{numberOfQuestions} pts ({timeSpan} seconds)");
            break;

        case "6":
            Console.WriteLine("\nHistory:");
            if (history.Count() > 0)
            {
                foreach (string item in history)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine("Play a game first!\n");
            break;

        default:
            if (inputChoice != "exit")
                Console.WriteLine("Invalid choice! Write a single number.\n");
            break;
    }
} while (inputChoice != "exit");