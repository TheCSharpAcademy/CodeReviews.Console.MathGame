partial class Program
{
    static void AddtionGame( int numberOfQuestions, int difficulty )
    {
        var random = new Random();
        int firstNumber;
        int secondNumber;

        var score = 0;

        for (int i = 0; i < numberOfQuestions; i++)
        {

            firstNumber = random.Next(1, 9) * difficulty;
            secondNumber = random.Next(1, 9) * difficulty;

            Console.WriteLine($"{firstNumber} + {secondNumber}");
            var result = Console.ReadLine();
            Console.Clear();

            if (int.Parse(result) == firstNumber + secondNumber)
            {
                Console.WriteLine("Your answer was correct!\n");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect\n");
            }
        }
        Console.Clear();
        Console.WriteLine($"Game over. Final score is {score}");

        Menu($"{DateTime.Now.TimeOfDay} - Addition game - Score: {score}");
    }

    static void SubtractionGame( int numberOfQuestions, int difficulty )
    {
        var random = new Random();
        int firstNumber;
        int secondNumber;

        var score = 0;

        for (int i = 0; i < numberOfQuestions; i++)
        {

            firstNumber = random.Next(1, 9) * difficulty;
            secondNumber = random.Next(1, 9) * difficulty;

            Console.WriteLine($"{firstNumber} - {secondNumber}");
            var result = Console.ReadLine();
            Console.Clear();

            if (int.Parse(result) == firstNumber - secondNumber)
            {
                Console.WriteLine("Your answer was correct!\n");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect\n");
            }
        }
        Console.Clear();
        Console.WriteLine($"Game over. Final score is {score}");

        Menu($"{DateTime.Now.TimeOfDay} - Subtraction game - Score: {score}");
    }

    static void MultiplicationGame( int numberOfQuestions, int difficulty )
    {
        var random = new Random();
        int firstNumber;
        int secondNumber;

        var score = 0;

        for (int i = 0; i < numberOfQuestions; i++)
        {

            firstNumber = random.Next(1, 9) * difficulty;
            secondNumber = random.Next(1, 9) * difficulty;

            Console.WriteLine($"{firstNumber} * {secondNumber}");
            var result = Console.ReadLine();
            Console.Clear();

            if (int.Parse(result) == firstNumber * secondNumber)
            {
                Console.WriteLine("Your answer was correct!\n");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect\n");
            }
        }

        Console.Clear();
        Console.WriteLine($"Game over. Final score is {score}");

        Menu($"{DateTime.Now.TimeOfDay} - Multiplication game - Score: {score}");
    }

    static void DivisionGame( int numberOfQuestions, int difficulty )
    {
        var random = new Random();

        int firstNumber = random.Next(1, 9) * difficulty;
        int secondNumber = random.Next(1, 9) * difficulty;

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, 9) * difficulty;
            secondNumber = random.Next(1, 9) * difficulty;
        }

        var score = 0;

        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.WriteLine($"{firstNumber} / {secondNumber}");
            var result = Console.ReadLine();
            Console.Clear();

            if (int.Parse(result) == firstNumber / secondNumber)
            {
                Console.WriteLine("Your answer was correct!\n");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect\n");
            }
        }

        Console.Clear();
        Console.WriteLine($"Game over. Final score is {score}");

        Menu($"{DateTime.Now.TimeOfDay} - Division game - Score: {score}");
    }

    static int NumberOfQuestions()
    {
        Console.Clear();
        Console.WriteLine("How many questions you want to answer?");
        int number = int.Parse(Console.ReadLine());
        Console.Clear();

        return number;
    }

    static int PickDifficulty()
    {
        Console.Clear();
        Console.WriteLine("What difficulty would you like the game to be? Type 1 for easy, 2 for medium and 3 for hard.");
        int number = int.Parse(Console.ReadLine());
        Console.Clear();

        return number;
    }

    static void ShowPastGames( List<string> list )
    {
        Console.Clear();
        foreach (string game in list)
        {
            Console.WriteLine(game);
            Console.WriteLine("---");
        }

        Menu(null);
    }

    static int[] GetDivisionNumber()
    {
        var random = new Random();

        var firstNumber = random.Next(0, 99);
        var secondNumber = random.Next(0, 99);
        var result = new int[2];

        result[0] = firstNumber;
        result[1] = secondNumber;

        return result;
    }
}
