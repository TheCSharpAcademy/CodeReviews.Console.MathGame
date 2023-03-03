namespace MathGame_
{
    internal class Menu
    {
        GameEngine gameSelection = new();

        internal void ShowMenu()
        {
            var selection = true;

            do
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("Select a game mode: ");
                Console.WriteLine(@"0 - History
1 - Addition
2 - Subtraction
3 - Multiplication
4 - Division
5 - Random
Q - Quit Program");
                Console.WriteLine("-------------------------");
                var mode = Console.ReadLine();

                mode = Helpers.ValidateMode(mode);
                Console.WriteLine();

                switch (mode)
                {
                    case "0":
                        Helpers.PrintGames();
                        break;

                    case "1":
                        var diff = chooseDifficulty();
                        var numOfQs = numofQuestions();
                        var diffText = "Easy";

                        if (diff == 40)
                            diffText = "Medium";
                        else if (diff == 90)
                            diffText = "Hard";

                        gameSelection.AdditionGame("Addition Game", diffText, diff, numOfQs);
                        break;
                    case "2":
                        diff = chooseDifficulty();
                        numOfQs = numofQuestions();
                        diffText = "Easy";

                        if (diff == 40)
                            diffText = "Medium";
                        else if (diff == 90)
                            diffText = "Hard";

                        gameSelection.SubtractionGame("Subtraction Game", diffText, diff, numOfQs);
                        break;

                    case "3":
                        diff = chooseDifficulty();
                        numOfQs = numofQuestions();
                        diffText = "Easy";

                        if (diff == 40)
                            diffText = "Medium";
                        else if (diff == 90)
                            diffText = "Hard";

                        gameSelection.MultiplicationGame("Multiplication Game", diffText, diff, numOfQs);
                        break;
                    case "4":
                        diff = chooseDifficulty();
                        numOfQs = numofQuestions();
                        diffText = "Easy";

                        if (diff == 40)
                            diffText = "Medium";
                        else if (diff == 90)
                            diffText = "Hard";

                        gameSelection.DivisionGame("Division Game", diffText, diff, numOfQs);
                        break;
                    case "5":
                        Random random = new Random();
                        int[] difficulties = { 0, 40, 90 };
                        diff = difficulties[random.Next(0, 3)];
                        diffText = "Easy";
                        Console.ForegroundColor = ConsoleColor.Green;
                        if (diff == 40)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            diffText = "Medium";
                        }

                        else if (diff == 90)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            diffText = "Hard";
                        }


                        var randomNumOfQs = random.Next(1, 11);

                        gameSelection.RandomGame("Random Game", diffText, diff, randomNumOfQs);
                        break;
                    case "Q":
                    case "q":
                        Console.WriteLine("Goodbye");
                        selection = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection, press [enter] to try again.");
                        Console.ReadLine();
                        break;
                }

            } while (selection);
        }

        private int numofQuestions()
        {
            Console.Write("Select Number of Questions: 1 - 10.. ");
            var choice = Console.ReadLine();

            choice = Helpers.ValidateAns(choice);

            if (int.Parse(choice) < 0)
                return 1;
            else if (int.Parse(choice) > 10)
                return 10;

            return int.Parse(choice);
        }

        private int chooseDifficulty()
        {
            Console.WriteLine("Select Difficulty:\t1 - Easy\t2 - Medium\t3 - Hard");
            var difficulty = Console.ReadLine();

            difficulty = Helpers.ValidateDifficulty(difficulty);

            Console.WriteLine();
            switch (difficulty)
            {
                case "2":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return 40;
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Red;
                    return 90;
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            return 0;

        }

    }
}
