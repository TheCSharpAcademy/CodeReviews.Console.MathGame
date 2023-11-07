namespace MathGame {
    internal class GameEngine {
        internal void Division() {

            int score = 0;

            for (int i = 0; i <= 4; i++) {
                Console.WriteLine("You choose division mode!");
                Console.Clear();

                int[] divisionNumbers = Helpers.GetDivisionNumbers();
                int firstNumber = divisionNumbers[0];
                int secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                int? result = int.Parse(Console.ReadLine());

                if (result == firstNumber / secondNumber) {
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

            Helpers.AddToHistory(score, "Division");
        }

        internal void Multiplication() {
            int score = 0;

            for (int i = 0; i <= 4; i++) {
                Console.Clear();
                Console.WriteLine("You choose multiplication mode!");

                int firstNumber = Helpers.GenerateRandomNumber(1, 9);
                int secondNumber = Helpers.GenerateRandomNumber(1, 9);

                Console.WriteLine($"{firstNumber} * {secondNumber}");
                int? result = int.Parse(Console.ReadLine());

                if (result == firstNumber * secondNumber) {
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

            Helpers.AddToHistory(score, "Multiplication");
        }

        internal void Subtraction() {

            int score = 0;

            for (int i = 0; i <= 4; i++) {
                Console.WriteLine("You choose subtraction mode!");
                Console.Clear();

                int firstNumber = Helpers.GenerateRandomNumber(1, 9);
                int secondNumber = Helpers.GenerateRandomNumber(1, 9);

                Console.WriteLine($"{firstNumber} - {secondNumber}");
                int? result = int.Parse(Console.ReadLine());

                if (result == firstNumber - secondNumber) {
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

            Helpers.AddToHistory(score, "Subtraction");
        }

        internal void Addition() {
            int score = 0;

            for (int i = 0; i <= 4; i++) {
                Console.WriteLine("You choose addition mode!");
                Console.Clear();

                int firstNumber = Helpers.GenerateRandomNumber(1, 9);
                int secondNumber = Helpers.GenerateRandomNumber(1, 9);

                Console.WriteLine($"{firstNumber} + {secondNumber}");
                int? result = int.Parse(Console.ReadLine());

                if (result == firstNumber + secondNumber) {
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

            Helpers.AddToHistory(score, "Addition");
        }
    }
}
