using System.Diagnostics;
using MathGame.lilWe3zy;

/*
 * Math game that contains 4 basic operations:
 *      1. - addition (+)
 *      2. - subtraction (-)
 *      3. - multiplication (*)
 *      4. - division (/)
 *
 * [x] - ! Division should result in an integer, and be done with integers in range of 1 - 100
 * [x] - ! Context menu to choose which operation to perform
 * [ ] - ! Keep record of previous games to view history
 *
 * [ ] - ! Challenge: Difficulty levels
 *         - Easy - range to 10, 5 questions
 *         - Medium - range to 50, 10 questions
 *         - Hard - range to 100, 15 questions
 * [ ] - ! Challenge: Timer to track how long game takes
 * [x] - ! Challenge: Function to allow choosing number of questions
 * [x] - ! Challenge: Random game option, with random operations
 */
Dictionary<string, int> gameConfig = new();
Random rand = new();
List<History> historyList = [];
int selection;

Start:
UserInterfaces.DisplayUserMenu(true);

do
{
    selection = ValidateUserInput(Console.ReadLine());

    if (selection is not (0 or > 3)) continue;
    UserInterfaces.DisplayUserMenu();
    Console.WriteLine("\nPlease input a valid number");
} while (selection is 0 or > 3);

// New Game
if (selection == 1)
{
    NewGame:
    UserInterfaces.DisplayNewGameMenu(true);
    do
    {
        selection = ValidateUserInput(Console.ReadLine());
        // On back selection, jump out to start of program execution
        if (selection == 6) goto Start;

        if (selection is not (0 or > 6)) continue;
        UserInterfaces.DisplayNewGameMenu();
        Console.WriteLine("\nPlease input a valid number");
    } while (selection is 0 or > 6);

    gameConfig.Add("operation", selection);
    // Difficulty selection for new game
    UserInterfaces.DisplayDifficultySelection(true);
    do
    {
        selection = ValidateUserInput(Console.ReadLine());
        // On back selection, jump out to new game screen, where changes can be made to operation selection.
        if (selection == 4) goto NewGame;

        if (selection is not (0 or > 4)) continue;
        UserInterfaces.DisplayDifficultySelection();
        Console.WriteLine("\nPlease input a valid number");
    } while (selection is 0 or > 4);

    gameConfig.Add("difficulty", selection);

    // Amount of questions
    UserInterfaces.DisplayQuestionAmountSelection();
    do
    {
        selection = ValidateUserInput(Console.ReadLine());
        if (selection is not (0 or > 100)) continue;
        Console.WriteLine(selection == 0 ? "\nPlease input a valid number" : $"No way I'm doing {selection}!");
    } while (selection is 0 or > 100);

    gameConfig.Add("length", selection);

    int correct = 0;
    // Index at 1 to allow for easier question numbering
    for (int i = 1; i <= gameConfig["length"]; i++)
    {
        Console.Clear();
        int answer = GenerateOperation(gameConfig["operation"], gameConfig["difficulty"], rand, i);
        int response = ValidateUserInput(Console.ReadLine());

        if (answer != response) continue;
        correct++;
    }

    // Add to list of games
    History entry = new(gameConfig["difficulty"], gameConfig["operation"], correct, gameConfig["length"]);
    historyList.Add(entry);

    UserInterfaces.DisplayEndGameCard(correct, gameConfig["length"]);
    UserInterfaces.DisplayHistory(historyList);
}

// View History
if (selection == 2) UserInterfaces.DisplayHistory(historyList);

return 0;


int ValidateUserInput(string? input)
{
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

int GenerateOperation(int operand, int difficulty, Random random, int questionNumber)
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
            // Recursively call function with new operator within range
            int randomOperator = random.Next(1, 5);
            answer = GenerateOperation(randomOperator, difficulty, random, questionNumber);
            break;
    }

    return answer;
}