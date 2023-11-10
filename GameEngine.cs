using MathGame.Models;

namespace MathGame {
    internal class GameEngine {
        internal void Division() {
            int score = 0;

            string operationType = GameType.Division.ToString();
            Helpers.Selectors(operationType);

            Console.WriteLine("You chose division mode!");
            Console.ReadLine();

            int questionNum = Helpers.NumberOfQuestions();

            for (int i = 0; i <= questionNum; i++) {
                Console.Clear();

                int[] divisionNumbers = Helpers.GetDivisionNumbers();
                int firstNumber = divisionNumbers[0];
                int secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");

                string? result = Console.ReadLine();
                result = Helpers.ValidateResult(result); ;

                if (int.Parse(result) == firstNumber / secondNumber) {
                    Console.WriteLine("Your answer was correct! Type any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else {
                    Console.WriteLine("Your answer was incorrect! Type any key for the next question.");
                    Console.ReadLine();
                }

                if (i == 4) {
                    Console.WriteLine($"Game over! Your final score is {score}.");
                }
            }

            Helpers.AddToHistory(score, GameType.Division);
        }

        internal void Multiplication() {
            int score = 0;

            Console.WriteLine("You choose multiplication mode!");
            Console.ReadLine();

            int questionNum = Helpers.NumberOfQuestions();

            for (int i = 0; i <= questionNum; i++) {
                Console.Clear();

                int firstNumber = Helpers.GenerateRandomNumber(1, 9);
                int secondNumber = Helpers.GenerateRandomNumber(1, 9);

                Console.WriteLine($"{firstNumber} * {secondNumber}");

                string? result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber) {
                    Console.WriteLine("Your answer was correct! Type any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else {
                    Console.WriteLine("Your answer was incorrect! Type any key for the next question.");
                    Console.ReadLine();
                }

                if (i == 4) {
                    Console.WriteLine($"Game over! Your final score is {score}.");
                }
            }

            Helpers.AddToHistory(score, GameType.Multiplication);
        }

        internal void Subtraction() {

            int score = 0;

            Console.WriteLine("You choose subtraction mode! Press any key to continue:");
            Console.ReadLine();

            int questionNum = Helpers.NumberOfQuestions();

            for (int i = 0; i <= questionNum; i++) {
                Console.Clear();

                int firstNumber = Helpers.GenerateRandomNumber(1, 9);
                int secondNumber = Helpers.GenerateRandomNumber(1, 9);

                Console.WriteLine($"{firstNumber} - {secondNumber}");

                string? result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber - secondNumber) {
                    Console.WriteLine("Your answer was correct! Type any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else {
                    Console.WriteLine("Your answer was incorrect! Type any key for the next question.");
                    Console.ReadLine();
                }

                if (i == 4) {
                    Console.WriteLine($"Game over! Your final score is {score}.");
                }
            }

            Helpers.AddToHistory(score, GameType.Subtraction);
        }

        internal void Addition() {
            int score = 0;

            Console.WriteLine("You choose addition mode! Press any key to continue:");
            Console.ReadLine();

            int questionNum = Helpers.NumberOfQuestions();

            for (int i = 0; i <= questionNum; i++) {
                Console.Clear();

                int firstNumber = Helpers.GenerateRandomNumber(1, 9);
                int secondNumber = Helpers.GenerateRandomNumber(1, 9);

                Console.WriteLine($"{firstNumber} + {secondNumber}");

                string? result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber + secondNumber) {
                    Console.WriteLine("Your answer was correct! Type any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else {
                    Console.WriteLine("Your answer was incorrect! Type any key for the next question.");
                    Console.ReadLine();
                }

                if (i == 4) {
                    Console.WriteLine($"Game over! Your final score is {score}. Press any key to go back to main menu:");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Addition);
        }
    }
}
