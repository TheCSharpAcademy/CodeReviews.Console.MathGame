namespace MathGame.kirielss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO KIRIEL'S MATH GAME");
            Console.WriteLine();

            Console.WriteLine("CHOOSE YOUR OPERATION");
            Console.WriteLine();

            Console.WriteLine("1 - ADDITION");
            Console.WriteLine("2 - SUBTRACTION");
            Console.WriteLine("3 - MULTIPLICATION");
            Console.WriteLine("4 - DIVISION");
            Console.WriteLine("0 - EXIT");
            Console.WriteLine();

            int selection = int.Parse(Console.ReadLine());

            switch (selection)
            {
                case 1:
                    Console.WriteLine();
                    break;
            }

        }
    }
}