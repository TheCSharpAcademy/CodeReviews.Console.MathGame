using System.Diagnostics;
using MathGame.lilWe3zy;

Dictionary<string, int> gameConfig = new();
List<History> historyList = [];
Random rand = new();
Stopwatch watch = new();

int selection, score = 0;

Start:
UserInterfaces.DisplayUserMenu(true);

do
{
    selection = ValidateUserInput();

    if (selection is not (0 or > 3)) continue;
    UserInterfaces.DisplayUserMenu();
    Console.WriteLine("\nPlease input a valid number");
} while (selection is 0 or > 3);

if (selection == 1)
{
    NewGame:
    UserInterfaces.DisplayNewGameMenu(true);

    gameConfig.Clear();
    do
    {
        selection = ValidateUserInput();
        // Main menu jump
        if (selection == 6) goto Start;

        if (selection is not (0 or > 6)) continue;

        UserInterfaces.DisplayNewGameMenu();
        Console.WriteLine("\nPlease input a valid number");
    } while (selection is 0 or > 6);

    gameConfig.Add("operation", selection);

    UserInterfaces.DisplayDifficultySelection(true);

    do
    {
        selection = ValidateUserInput();
        // New game menu jump
        if (selection == 4) goto NewGame;

        if (selection is not (0 or > 4)) continue;

        UserInterfaces.DisplayDifficultySelection();
        Console.WriteLine("\nPlease input a valid number");
    } while (selection is 0 or > 4);

    gameConfig.Add("difficulty", selection);

    UserInterfaces.DisplayQuestionAmountSelection();

    do
    {
        selection = ValidateUserInput();

        if (selection is not (0 or > 100)) continue;

        Console.WriteLine(selection == 0 ? "\nPlease input a valid number" : $"No way I'm doing {selection}!");
    } while (selection is 0 or > 100);

    gameConfig.Add("length", selection);

    watch.Start();
    // Index at 1 to allow for easier question numbering
    for (int index = 1; index <= gameConfig["length"]; index++)
    {
        Console.Clear();
        int answer = GenerateOperation(gameConfig["operation"], gameConfig["difficulty"], index, rand);
        selection = ValidateUserInput();

        if (answer != selection) continue;
        score++;
    }

    watch.Stop();

    History entry = new(gameConfig["difficulty"], gameConfig["operation"], score, gameConfig["length"],
        watch.Elapsed);
    historyList.Add(entry);

    UserInterfaces.DisplayEndGameCard(score, gameConfig["length"]);

    do
    {
        selection = ValidateUserInput();

        if (selection is not (0 or > 4)) continue;

        UserInterfaces.DisplayDifficultySelection();
        Console.WriteLine("\nPlease input a valid number");
    } while (selection is 0 or > 4);

    switch (selection)
    {
        case 1:
            goto Start;

        case 2:
            UserInterfaces.DisplayHistory(historyList);

            do
            {
                selection = ValidateUserInput();

                if (selection is not (0 or > 3)) continue;

                UserInterfaces.DisplayDifficultySelection();
                Console.WriteLine("\nPlease input a valid number");
            } while (selection is 0 or > 3);

            switch (selection)
            {
                case 1:
                    goto Start;
                case 2:
                    return 0;
            }

            break;

        case 3:
            Console.WriteLine("Good - Bye!");
            return 0;
    }
}

if (selection == 2)
{
    UserInterfaces.DisplayHistory(historyList);

    do
    {
        selection = ValidateUserInput();

        if (selection is not (0 or > 3)) continue;

        UserInterfaces.DisplayDifficultySelection();
        Console.WriteLine("\nPlease input a valid number");
    } while (selection is 0 or > 3);

    switch (selection)
    {
        case 1:
            goto Start;
        case 2:
            Console.WriteLine("Good x Bye!");
            return 0;
    }
}

if (selection == 3) Console.WriteLine("Good + Bye!");

return 0;

int ValidateUserInput()
{
    string? input = Console.ReadLine();
    if (input == null) return 0;
    return int.TryParse(input, out selection) ? selection : 0;
}

(int, int) GenerateNumberRange(Random random, int difficulty)
{
    int firstOperand, secondOperand;

    switch (difficulty)
    {
        case 2:
            firstOperand = random.Next(1, 51);
            secondOperand = random.Next(1, 51);
            break;
        case 3:
            firstOperand = random.Next(1, 101);
            secondOperand = random.Next(1, 101);
            break;
        default:
            firstOperand = random.Next(1, 11);
            secondOperand = random.Next(1, 11);
            break;
    }

    return (firstOperand, secondOperand);
}

int GenerateOperation(int operand, int difficulty, int questionNumber, Random random)
{
    int answer = 0;
    (int, int) range;
    switch (operand)
    {
        case 1:
            range = GenerateNumberRange(random, difficulty);
            Console.WriteLine($"QUESTION {questionNumber}\n{range.Item1} + {range.Item2} = ?");
            answer = range.Item1 + range.Item2;
            break;
        case 2:
            range = GenerateNumberRange(random, difficulty);
            Console.WriteLine($"QUESTION {questionNumber}\n{range.Item1} - {range.Item2} = ?");
            answer = range.Item1 - range.Item2;
            break;
        case 3:
            range = GenerateNumberRange(random, difficulty);
            Console.WriteLine($"QUESTION {questionNumber}\n{range.Item1} x {range.Item2} = ?");
            answer = range.Item1 * range.Item2;
            break;
        case 4:
            do
            {
                range = GenerateNumberRange(random, difficulty);
            } while (range.Item1 % range.Item2 != 0);

            answer = range.Item1 / range.Item2;
            Console.WriteLine($"QUESTION {questionNumber}\n{range.Item1} / {range.Item2} = ?");
            break;
        case 5:
            int randomOperator = random.Next(1, 5);
            answer = GenerateOperation(randomOperator, difficulty, questionNumber, random);
            break;
    }

    return answer;
}