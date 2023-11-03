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
            
            bool isGameOn = true;

            do {

                Console.WriteLine("<--------------------------------->");
                Console.WriteLine($"Hello, {name}. It's {date}.\n" +
                                  $"Welcome to the Math Game!");
                Console.WriteLine("\n");
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
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (isGameOn);
            

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

            int score = 0;

            for (int i = 0; i <= 4; i++) {
                Console.WriteLine("You choose division mode!");
                Console.Clear();

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
                    Console.WriteLine("Your answer was incorrect! Type any key for the next question.");
                    Console.ReadLine();
                }

                if (i == 4) {
                    Console.WriteLine($"Game over! Your final score is {score}.");
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

                if (i == 4) {
                    Console.WriteLine($"Game over! Your final score is {score}.");
                }
            }
        }

        private static void Subtraction() {

            int score = 0;

            for (int i = 0; i <= 4; i++) {
                Console.WriteLine("You choose subtraction mode!");
                Console.Clear();

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

                if (i == 4) {
                    Console.WriteLine($"Game over! Your final score is {score}.");
                }
            }
        }

        private static void Addition() {

            int score = 0;

            for (int i = 0; i <= 4; i++) {
                Console.WriteLine("You choose addition mode!");
                Console.Clear();

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

                if (i == 4) {
                    Console.WriteLine($"Game over! Your final score is {score}. Press any key to go back to main menu:");
                    Console.ReadLine();
                }
            }
        }
        //End of methods
    }
}