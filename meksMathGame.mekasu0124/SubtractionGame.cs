class SubtractionGame
{
    private static readonly Random rng = new();

    public void StartGame(string difficulty, int numOfQues)
    {
        int tries = 3;

        SolutionChecker checkSolution = new();
        EndGame endGame = new();

        if (difficulty == "easy")
        {
            for (int i = 0; i < numOfQues; i++)
            {
                int num1 = rng.Next(1, 34);
                int num2 = rng.Next(1, 34);

                int userSolution = PresentQuestion(num1, num2);

                checkSolution.CheckSolution(num1, "-", num2, userSolution);
            }
            endGame.EndGameScreen();
        }
        else if (difficulty == "medium")
        {
            for (int i = 0; i < numOfQues; i++)
            {
                int num1 = rng.Next(33, 67);
                int num2 = rng.Next(33, 67);

                int userSolution = PresentQuestion(num1, num2);

                checkSolution.CheckSolution(num1, "-", num2, userSolution);
            }
            endGame.EndGameScreen();
        }
        else if (difficulty == "hard")
        {
            for (int i = 0; i < numOfQues; i++)
            {
                int num1 = rng.Next(66, 101);
                int num2 = rng.Next(66, 101);

                int userSolution = PresentQuestion(num1, num2);

                checkSolution.CheckSolution(num1, "-", num2, userSolution);
            }
            endGame.EndGameScreen();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
                "Invalid Operation Launching Desired Game. " +
                "If This Problem Persists, Then Contact Support At: " +
                "https://github.com/mekasu0124/MeksMathGame/issues"
            );

            Thread.Sleep(2000);

            tries--;

            if (tries > 0)
            {
                StartGame(difficulty, numOfQues);
            }
            else
            {
                Environment.Exit(0);
            };
        }
    }

    static int PresentQuestion(int num1, int num2)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nWhat Is The Summation Of:");
        Console.WriteLine("   " + num1);
        Console.WriteLine(" - " + num2);
        Console.WriteLine("-----");

        int userSolution = Convert.ToInt32(Console.ReadLine());
        return userSolution;
    }
}