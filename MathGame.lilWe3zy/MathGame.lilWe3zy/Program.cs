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
 * [ ] - ! Challenge: Function to allow choosing number of questions
 * [x] - ! Challenge: Random game option, with random operations
 */

int selection = UserInterfaces.MainMenu();
Console.WriteLine(selection);
return 0;


(int, int) GenerateNumberRange(Random random, int difficulty)
{
    int firstNumber = 0, secondNumber = 0;

    switch (difficulty)
    {
        case 1:
            firstNumber = random.Next(1, 11);
            secondNumber = random.Next(1, 11);
            break;
        case 2:
            firstNumber = random.Next(1, 51);
            secondNumber = random.Next(1, 51);
            break;
        case 3:
            firstNumber = random.Next(1, 101);
            secondNumber = random.Next(1, 101);
            break;
    }

    return (firstNumber, secondNumber);
}

int GenerateOperation(int operand, int difficulty, Random random)
{
    int answer = 0;
    (int, int) range;
    switch (operand)
    {
        case 1:
            range = GenerateNumberRange(random, difficulty);
            Console.WriteLine($"{range.Item1} + {range.Item2} = ?");
            answer = range.Item1 + range.Item2;
            break;
        case 2:
            range = GenerateNumberRange(random, difficulty);
            Console.WriteLine($"{range.Item1} - {range.Item2} = ?");
            answer = range.Item1 - range.Item2;
            break;
        case 3:
            range = GenerateNumberRange(random, difficulty);
            Console.WriteLine($"{range.Item1} x {range.Item2} = ?");
            answer = range.Item1 * range.Item2;
            break;
        case 4:
            do
            {
                range = GenerateNumberRange(random, difficulty);
            } while (range.Item1 % range.Item2 != 0);

            answer = range.Item1 / range.Item2;
            Console.WriteLine($"{range.Item1} / {range.Item2} = ?");
            break;
        case 5:
            // Recursively call function with new operator within range
            int randomOperator = random.Next(1, 5);
            answer = GenerateOperation(randomOperator, difficulty, random);
            break;
    }

    return answer;
}