namespace MathGame.DzemalKurtic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please type your name");
            var name = Console.ReadLine();
            Console.WriteLine($"Hello {name} this is your Math game");

            Console.WriteLine($@"What game would you like to play? Choose from options below:
            A - Addition
            S - Subtraction
            M - Multiplication
            D - Division
            Q - Quit the program");

            Console.WriteLine();

            var gameSelected = Console.ReadLine()?.Trim().ToLower();

            if (gameSelected == "a")
            {
                AdditionGame("Addition game selected");
            }
            else if (gameSelected == "s")
            {
                SubtractionGame("Subtraction game selected");
            }
            else if (gameSelected == "m")
            {
                MultiplicationGame("Multiplication game selected");
            }
            else if (gameSelected == "d")
            {
                DivisionGame("Division game selected");
            }
            else if (gameSelected == "q")
            {
                Console.WriteLine("Goodbye");
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        private static void DivisionGame(string message)
        {
            Console.WriteLine(message);
        }

        private static void MultiplicationGame(string message)
        {
            Console.WriteLine(message);
        }

        private static void SubtractionGame(string message)
        {
        }

        static void AdditionGame(string message)
        {
            Console.WriteLine(message);

        }
    }
}