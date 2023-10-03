namespace MathGame.vilvee
{
    public class Program
    {
        public static List<Game> Games = new List<Game>(); //Played games in one session

        public enum Operation
        {
            Addition,
            Subtraction,
            Division,
            Multiplication
        }


        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {


            string choice;

            do
            {
                Console.Clear();

                Console.WriteLine(@"
Choose an operation:

[A] ADDITION
[B] SUBTARCTION
[C] DIVISION
[D] MULTIPLICATION
[E] DISPLAY SCORES
[Q] QUIT");

                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "a":
                        Game(Operation.Addition);
                        break;
                    case "b":
                        Game(Operation.Subtraction);
                        break;
                    case "c":
                        Game(Operation.Division);
                        break;
                    case "d":
                        Game(Operation.Multiplication);
                        break;
                    case "e":
                        DisplayPreviousScores();
                        break;
                    case "q":
                        Console.WriteLine("Thank you for playing. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("The choice is not valid. Please select a valid option.");
                        break;
                }
            } while (choice != "q");
        }

        public static int RandomNumberGenerator()
        {
            const int MIN = 1;
            const int MAX = 100;
            Random rnd = new Random();
            int number = rnd.Next(MIN, MAX + 1);
            return number;
        }

        public static void DisplayPreviousScores()
        {
            Console.Clear();


            foreach (Game game in Games)
            {
                Console.WriteLine(game.ToString());
            }

            Console.WriteLine("\nPress any key to go back");

            Console.ReadKey();
        }

        public static void Game(Operation operation)
        {

            Game game = new Game(operation);

            string operationSymbol = "";

            Func<int, int, double> operationFunc = null;

            switch (operation)
            {
                case Operation.Addition:
                    operationSymbol = "+";
                    operationFunc = (a, b) => a + b;
                    break;
                case Operation.Subtraction:
                    operationSymbol = "-";
                    operationFunc = (a, b) => a - b;
                    break;
                case Operation.Division:
                    operationSymbol = "/";
                    operationFunc = (a, b) => a / (double)b;
                    break;
                case Operation.Multiplication:
                    operationSymbol = "*";
                    operationFunc = (a, b) => a * b;
                    break;
            }

            Console.WriteLine("How many questions do you want to answer?");

            bool correct = int.TryParse(Console.ReadLine(), out int number);

            while (!correct)
            {
                Console.WriteLine("Bad input\nHow many questions do you want to answer?");

                correct = int.TryParse(Console.ReadLine(), out number);
            }


            for (int i = 0; i < number; i++)
            {
                Console.Clear();

                double correctAnswer;
                int number1,
                    number2;

                do
                {
                    number1 = RandomNumberGenerator();
                    number2 = RandomNumberGenerator();

                    correctAnswer = operationFunc(number1, number2);

                } while (correctAnswer % 1 != 0);


                Console.WriteLine($"{operation}");
                Console.WriteLine($"{number1} {operationSymbol} {number2}");

                if (double.TryParse(Console.ReadLine(), out double userAnswer) && correctAnswer == userAnswer)
                {
                    game.Score++;
                }
            }
            game.Stopwatch.Stop();
            game.gameTime = game.Stopwatch.Elapsed.ToString(@"m\:ss");

            Console.WriteLine($"You finished the game with a score of {game.Score}\n" +
                $"Press Any Key to return to Main Menu");

            Games.Add(game);

            Console.ReadKey();

        }

    }
}