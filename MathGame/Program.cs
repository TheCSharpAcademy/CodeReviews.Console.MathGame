namespace MathGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the C# Academy Math Game!\nThere are several game modes to choose from. Each game run will contain 5 questions.");
            bool playing = true;

            while (playing)
            {
                Console.WriteLine("Please choose a game mode. Your options are;\n1) Addition\n2) Subtraction\n3) Multiplication\n4) Division");

                bool validInput = Int32.TryParse(Console.ReadLine(), out int userChoice);
                if (!validInput)
                {
                    Console.WriteLine("Invalid input provided. Please make sure you choose an existing game mode.");
                    continue;
                }
                Console.WriteLine($"Entering game mode {userChoice}");
            }


        }
    }
}