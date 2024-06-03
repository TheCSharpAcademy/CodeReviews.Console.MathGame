namespace MathGame.kjanos89
{
    public class AdditionGame
    {
        int c = 0;
        Start startObject = new Start();
        string selection = "";
        int points=GameData.Points;
        public void Result()
        {
            Random numberGen = new Random();
            int a = numberGen.Next(1, 101);
            int b = numberGen.Next(1, 101);
            Console.Clear();
            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine($"You currently have {GameData.Points} amount of points.");
            Console.WriteLine("Your choice was Addition Game mode. The rules are simple: type in the sum of the numbers below.");
            Console.WriteLine($"First number is {a}");
            Console.WriteLine($"Second number is {b}");
            Console.WriteLine("Pressing B will return you to the main menu.");
            Console.WriteLine("__________________________________________________________________");
            Validation(a, b);
        }

        public void Validation(int a, int b)
        {
            string input = Console.ReadLine();

            if (input.ToLower() == "b")
            {
                startObject.StartMenu();
            }
            else if (Int32.TryParse(input, out c))
            {
                if (c == a + b)
                {
                    Console.WriteLine("Nice one! You just earned one point for Gryffindor!");
                    Console.WriteLine("Starting again in 3 seconds!");
                    Thread.Sleep(3000);
                    GameData.Points++;
                    Result();
                }
                else
                {
                    Console.WriteLine("Not exactly, try again!");
                    Validation(a, b);
                }
            }
            else
            {
                Console.WriteLine("Not a number, try again!");
                Validation(a, b);
            }
        }
    }
}
