using static System.Formats.Asn1.AsnWriter;

namespace MathGame {
    internal class Program {
        static void Main(string[] args) {

            Console.Write("Please, type in your name. \n" +
                          ">");
            string? name = Console.ReadLine();
            string date = DateTime.Now.ToString();
            Menu(name, date);

        }

        private static void Menu(string? name, string date) {
            Console.WriteLine("<--------------------------------->");
            Console.WriteLine($"Hello, {name}. It's {date}.\n" +
                              $"Welcome to the Math Game!");
            Console.Write("What game would you like to play now? Choose one of the options below:\n" +
                              "A -> Addition\n" +
                              "S -> Subtraction\n" +
                              "M -> Multiplication\n" +
                              "D -> Division\n" +
                              "Q -> Quit\n\n" +

                              ">");
            string selectedGame = Console.ReadLine().ToString().Trim().ToUpper();

            switch (selectedGame) {
                case "A":
                    Addition();
                    break;
                case "S":
                    Subtraction();
                    break;
                case "M":
                    Multiplication();
                    break;
                case "D":
                    Division();
                    break;
                case "Q":
                    Console.WriteLine("Goodbye! ;)");
                    break;
            }
        }

        //Start of methods

        static int GenerateRandomNumber(int min, int limit) {
            Random random = new Random();
            int randomNumber = random.Next(min, limit);

            return randomNumber;
        }

        private static int[] GetDivisionNumbers() {
            int firstNumber = GenerateRandomNumber(1, 99);
            int secondNumber = GenerateRandomNumber(1, 99);

            int[] result = new int[2];

            while(firstNumber % secondNumber != 0) {
                firstNumber = GenerateRandomNumber(1, 99);
                secondNumber = GenerateRandomNumber(1, 99);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        private static void Division() {
            Console.WriteLine("You choose division mode!");

            int score = 0;

            for (int i = 0; i <= 4; i++) {
                int[] divisionNumbers = GetDivisionNumbers();
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
                    Console.WriteLine("Your answer was incorrect! Type any key for the next question. Type any key for the next question.Type any key for the next question.");
                    Console.ReadLine();
                }
            }
        }
        

        private static void Multiplication() {
            int score = 0;

            for (int i = 0; i <= 4; i++) {
                Console.Clear();
                Console.WriteLine("You choose multiplication mode!");

                int firstNumber = GenerateRandomNumber(1, 9);
                int secondNumber = GenerateRandomNumber(1, 9);

                Console.WriteLine($"{firstNumber} * {secondNumber}");
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
            }
        }

        private static void Subtraction() {
            Console.WriteLine("You choose subtraction mode!");

            int score = 0;

            for (int i = 0; i <= 4; i++) {

                int firstNumber = GenerateRandomNumber(1, 9);
                int secondNumber = GenerateRandomNumber(1, 9);

                Console.WriteLine($"{firstNumber} - {secondNumber}");
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
            }
        }

        private static void Addition() {
            Console.WriteLine("You choose addition mode!");

            int score = 0;

            for (int i = 0; i <= 4; i++) {

                int firstNumber = GenerateRandomNumber(1, 9);
                int secondNumber = GenerateRandomNumber(1, 9);

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
            }
        }
        //End of methods
    }
}