using System.Diagnostics;

namespace MathGame
{
    public static class MathGameLogic
    {
        public static void PlayGame(string operation, List<GameHistory> history, int numQuestions, string difficulty)
        {
            Random rand = new Random(); // Random number generator
            Stopwatch stopwatch = new Stopwatch(); // Timer to track game duration
            stopwatch.Start(); // Start the timer

            // Loop through the number of questions
            for (int i = 0; i < numQuestions; i++)
            {
                int num1, num2, userAnswer, correctAnswer;

                // Generate operands based on the operation and difficulty
                (num1, num2) = GenerateOperands(operation, difficulty, rand);

                // Calculate the correct answer based on the operation
                correctAnswer = operation switch
                {
                    "Addition" => num1 + num2,
                    "Subtraction" => num1 - num2,
                    "Multiplication" => num1 * num2,
                    "Division" => num1 / num2,
                    _ => throw new InvalidOperationException("Invalid operation")
                };

                Console.WriteLine($"What is {num1} {GetOperator(operation)} {num2}?");
                // Read and parse user's answer
                int.TryParse(Console.ReadLine(), out userAnswer);

                // Add the game details to history
                history.Add(new GameHistory
                {
                    Operation = operation,
                    Operand1 = num1,
                    Operand2 = num2,
                    UserAnswer = userAnswer,
                    CorrectAnswer = correctAnswer,
                    IsCorrect = userAnswer == correctAnswer,
                    TimeTaken = stopwatch.Elapsed
                });

                // Display feedback to the user
                if (userAnswer == correctAnswer)
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}.");
                }
            }

            stopwatch.Stop(); // Stop the timer
            Console.WriteLine($"Game completed in {stopwatch.Elapsed.TotalSeconds} seconds.");
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey(); // Wait for user input before returning to the menu
        }

        // Function to generate operands based on the opeartion and level of difficult

        private static (int, int) GenerateOperands(string operation, string difficulty, Random rand)
        {
            int min = 0, max = 10;

            if (difficulty == "Medium")
            {
                max = 50;
            }
            else if (difficulty == "Hard")
            {
                max = 100;
            }

            int num1, num2;
            switch (operation)
            {
                case "Addition":
                case "Subtraction":
                case "Multiplication":
                    num1 = rand.Next(min, max + 1);
                    num2 = rand.Next(min, max + 1);
                    break;
                case "Division":
                    do
                    {
                        num1 = rand.Next(min, max + 1);
                        num2 = rand.Next(1, max + 1); // avoid division by zero
                    }
                    while (num1 % num2 != 0); break;
                default:
                    throw new InvalidOperationException("InvalidOperation");
            }

            return (num1, num2); // Return the generated operands

        }

        public static void DisplayHistory(List<GameHistory> history)
        {
            Console.Clear();
            Console.WriteLine("Game History");

            //Loop through each game in history and display details

            foreach(var game in history)
            {
                Console.WriteLine($"{game.Operation}: {game.Operand1} {GetOperator(game.Operation)} {game.Operand2} = {game.UserAnswer} (Correct: {game.CorrectAnswer}) - {(game.IsCorrect ? "Correct" : "Incorrect")} (Time: {game.TimeTaken.TotalSeconds} seconds)");
            }

             Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey(); // Wait for user input before returning to the menu
        }

          // Function to get the operator symbol based on the operation name
        private static string GetOperator(string operation)
        {
            return operation switch
            {
                "Addition" => "+",
                "Subtraction" => "-",
                "Multiplication" => "*",
                "Division" => "/",
                _ => ""
            };
        }

         // Function to play a random game with mixed operations
        public static void PlayRandomGame(List<GameHistory> history, int numQuestions, string difficulty)
        {
            string[] operations = { "Addition", "Subtraction", "Multiplication", "Division" }; // Array of operations
            Random rand = new Random(); // Random number generator

            // Loop through the number of questions
            for (int i = 0; i < numQuestions; i++)
            {
                string randomOperation = operations[rand.Next(operations.Length)]; // Pick a random operation
                PlayGame(randomOperation, history, 1, difficulty); // Play a game with the random operation
            }
        }

    }
}