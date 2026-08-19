// Difficulty based questions

string[,] beginnerQuestions = {{"1 + 5", "6"}, {"2 * 2", "4"}, {"21 + 3", "24"}};
string[,] moderateQuestions = {{"22/3", "7"}, {"17 * 2", "34"}, {"125 - 56", "69"}};
string[,] advancedQuestions = {{"147/6", "24"}, {"13 ^ 2", "169"}, {"23 * 25", "575"}};

string entry = "";


while (entry != "exit")
{
    Console.WriteLine("Please enter a difficulty: b (beginner), m (moderate), a (advanced)");
    entry = Console.ReadLine();
    switch (entry)
    {
        case "b":
            askQuestion(Difficulty.Beginner);
            break;
        case "m":
            askQuestion(Difficulty.Moderate);
            break;
        case "a":
            askQuestion(Difficulty.Advanced);
            break;
        default:
            Console.WriteLine("Invalid input.");
            break;
    }
    Console.WriteLine("Do you want to play again? Press Enter to continue or type \"exit\" to quit.");
    entry = Console.ReadLine();
}

void askQuestion(Difficulty difficulty)
{
    System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
    Tuple<string, string> question = createQuestion(difficulty);

    timer.Start();
    Console.WriteLine(question.Item1);
    entry = Console.ReadLine();
    timer.Stop();

    TimeSpan ts = timer.Elapsed;
    string elapsedTime = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
    if (entry != null && entry.Equals(question.Item2))
    {
        Console.WriteLine($"Correct! Your time to answer is: {elapsedTime} min");
    }
    else
    {
        Console.WriteLine($"That was the wrong answer. The correct answer is: {question.Item2}");
    }
}

Tuple<String, String> createQuestion(Difficulty difficulty)
{
    Random rand = new Random();
    int num1 = rand.Next(1, 51);
    int num2 = rand.Next(1, 51);
    int operand = 0;
    int result;

    switch (difficulty)
    {
        case Difficulty.Beginner:
            operand = rand.Next(0, 2);
            break;
        case Difficulty.Moderate:
            operand = rand.Next(0, 4);
            break;
        case Difficulty.Advanced:
            num1 = rand.Next(51, 201);
            num2 = rand.Next(51, 201);
            operand = rand.Next(2, 5);
            if (operand == 4)
            {
                num1 = rand.Next(1, 51);
                num2 = rand.Next(1, 5);
            }
            break;
    }

    switch (operand)
    {
        case 0:
            result = num1 + num2;
            return new Tuple<string, string>(num1 + " + " + num2, Convert.ToString(result));
        case 1:
            result = num1 - num2;
            return new Tuple<string, string>(num1 + " - " + num2, Convert.ToString(result));
        case 2:
            result = num1 * num2;
            return new Tuple<string, string>(num1 + " * " + num2, Convert.ToString(result));
        case 3:
            result = num1 / num2;
            return new Tuple<string, string>(num1 + " / " + num2, Convert.ToString(result));
        case 4:
            result = Convert.ToInt32(Math.Pow(num1, num2));
            return new Tuple<string, string>(num1 + " ^ " + num2, Convert.ToString(result));
    }

    return null;
}

enum Difficulty
{
    Beginner,
    Moderate,
    Advanced
}