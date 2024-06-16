class Menu
{


    public static int DisplayMainMenu()
    {
        Console.WriteLine($@"
        Welcome to Math Game!
            1. Addition             2. Subtraction
            3. Multiplication       4. Division
            5. Randomized       
            ---
            6. View history         7. Set difficulty
            8. Set num questions    9. Exit
    ");

        return Util.ReadNumericalInput();
    }



    public static Difficulty ReadDifficultyInput()
    {
        while (true)
        {
            Console.WriteLine("\nEnter difficulty (1 - Easy   2 - Medium  3 - Hard):\n");

            int difficulty = Util.ReadNumericalInput();

            if (difficulty > 0 && difficulty < 4)
            {
                return (Difficulty)difficulty;
            }

            Console.WriteLine("Please enter valid difficulty.");
        }
    }

    public static int ReadNumQuestionsPerGame()
    {
        Console.WriteLine("Enter number of questions per game:\t");

        int numberOfQuestions = Util.ReadNumericalInput();

        return numberOfQuestions;

    }
}