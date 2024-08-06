
namespace MathGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // List to store history of games played
            List<GameHistory> history = new List<GameHistory>();
            // Default number of questions per game
            int numQuestions = 5;
            // Default difficulty level
            string difficulty = "Easy";
            // Flag to control the main loop
            bool keepPlaying = true;

            // Main loop to keep the program running until the user chooses to exit
            while (keepPlaying)
            {
                Console.Clear(); // Clears the console screen
                Console.WriteLine("Welcome to the Math Game!");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Random Game");
                Console.WriteLine("6. View Game History");
                Console.WriteLine($"7. Set Difficulty (Current: {difficulty})");
                Console.WriteLine($"8. Set Number of Questions (Current: {numQuestions})");
                Console.WriteLine("9. Exit");

                // Read user's menu choice
                switch (Console.ReadLine())
                {
                    case "1":
                        MathGameLogic.PlayGame("Addition", history, numQuestions, difficulty);
                        break;
                    case "2":
                        MathGameLogic.PlayGame("Subtraction", history, numQuestions, difficulty);
                        break;
                    case "3":
                        MathGameLogic.PlayGame("Multiplication", history, numQuestions, difficulty);
                        break;
                    case "4":
                        MathGameLogic.PlayGame("Division", history, numQuestions, difficulty);
                        break;
                    case "5":
                        MathGameLogic.PlayRandomGame(history, numQuestions, difficulty);
                        break;
                    case "6":
                        MathGameLogic.DisplayHistory(history);
                        break;
                    case "7":
                        difficulty = SetDifficulty();
                        break;
                    case "8":
                        numQuestions = SetNumQuestions();
                        break;
                    case "9":
                        keepPlaying = false; // Exit the main loop
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Function to set the difficulty level
        static string SetDifficulty()
        {
            Console.Clear(); // Clears the console screen
            Console.WriteLine("Select Difficulty Level:");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");

            // Read user's difficulty choice
            switch (Console.ReadLine())
            {
                case "1":
                    return "Easy";
                case "2":
                    return "Medium";
                case "3":
                    return "Hard";
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Easy.");
                    return "Easy";
            }
        }

        // Function to set the number of questions
        static int SetNumQuestions()
        {
            Console.Clear(); // Clears the console screen
            Console.WriteLine("Enter the number of questions (1-20):");
            // Read and parse user's input
            if (int.TryParse(Console.ReadLine(), out int num) && num > 0 && num <= 20)
            {
                return num;
            }
            else
            {
                Console.WriteLine("Invalid input. Defaulting to 5 questions.");
                return 5;
            }
        }
    }
}
