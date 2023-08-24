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

            firstNumber = random.Next(1, 99) * difficulty;
            secondNumber = random.Next(1, 99) * difficulty;

            Console.WriteLine($"{firstNumber} + {secondNumber}");

            int result = ValidateResponse(Console.ReadLine());
            Console.Clear();

            if (result == firstNumber + secondNumber)
            {
                Console.WriteLine("Your answer was correct!\n");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect\n");
            }
        }
        EndGame(score);
    }

    static void SubtractionGame( int numberOfQuestions, int difficulty )
    {
        var random = new Random();
        int firstNumber;
        int secondNumber;

        var score = 0;

        for (int i = 0; i < numberOfQuestions; i++)
        {

            firstNumber = random.Next(1, 99) * difficulty;
            secondNumber = random.Next(1, 99) * difficulty;

            Console.WriteLine($"{firstNumber} - {secondNumber}");

            int result = ValidateResponse(Console.ReadLine());
            Console.Clear();

            if (result == firstNumber - secondNumber)
            {
                Console.WriteLine("Your answer was correct!\n");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect\n");
            }
        }
        EndGame(score);
    }

    static void MultiplicationGame( int numberOfQuestions, int difficulty )
    {
        var random = new Random();
        int firstNumber;
        int secondNumber;

        var score = 0;

        for (int i = 0; i < numberOfQuestions; i++)
        {

            firstNumber = random.Next(1, 99) * difficulty;
            secondNumber = random.Next(1, 99) * difficulty;

            Console.WriteLine($"{firstNumber} * {secondNumber}");

            int result = ValidateResponse(Console.ReadLine());
            Console.Clear();

            if (result == firstNumber * secondNumber)
            {
                Console.WriteLine("Your answer was correct!\n");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect\n");
            }
        }
        EndGame(score);
    }

    static void DivisionGame( int numberOfQuestions, int difficulty )
    {
        var random = new Random();

        //Make sure numbers are divisible with remain zero.
        int firstNumber = random.Next(1, 99) * difficulty;
        int secondNumber = random.Next(1, 99) * difficulty;

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, 99) * difficulty;
            secondNumber = random.Next(1, 99) * difficulty;
        }

        var score = 0;

        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.WriteLine($"{firstNumber} / {secondNumber}");

            int result = ValidateResponse(Console.ReadLine());
            Console.Clear();

            if (result == firstNumber / secondNumber)
            {
                Console.WriteLine("Your answer was correct!\n");
                score++;
            }
            else
            {
                Console.WriteLine("Incorrect\n");
            }
        }
        EndGame(score);
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

        Console.WriteLine("Press enter to go back");
        var a = Console.ReadKey(true);
        Console.Clear();

        Menu(null);
    }

    static int ValidateResponse(string input)
    {
        while (!int.TryParse(input, out _))
        {
            Console.WriteLine("That was not a valid answer, try again.\n");
            input = Console.ReadLine();
        }

        return int.Parse(input);
    }
}
