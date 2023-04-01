namespace MathGame.kirielss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool uptime = true;
            int score = 0;

            Console.WriteLine("WELCOME TO KIRIEL'S MATH GAME");
            Console.WriteLine();

            while (uptime)
            {

                Console.WriteLine("CHOOSE YOUR OPERATION");
                Console.WriteLine();

                Console.WriteLine("1 - ADDITION");
                Console.WriteLine("2 - SUBTRACTION");
                Console.WriteLine("3 - MULTIPLICATION");
                Console.WriteLine("4 - DIVISION");
                Console.WriteLine("0 - EXIT");
                Console.WriteLine();

                int selector = int.Parse(Console.ReadLine());
                Console.Clear();

                if (selector >= 1 && selector <= 4)
                {
                    Game game = new Game(selector);
                    game.Operation();
                    int answer = int.Parse(Console.ReadLine());
                    if (answer == game.Result)
                    {
                        Console.WriteLine("CORRECT! YOU ROCK!!!");
                        score++;
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("CURRENT SCORE: " + score);
                        Console.WriteLine();
                    } else
                    {
                        Console.WriteLine("TOO BAD! THE ANSWER IS " + game.Result);
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("CURRENT SCORE: " + score);
                        Console.WriteLine();
                    }

                }
                else if (selector != 0)
                {
                    Console.WriteLine("ERROR! PLEASE INSERT A VALID NUMBER BETWEEN 1 - 4, OR 0 TO EXIT");
                }
                else
                {
                    Console.WriteLine("THANK YOU FOR PLAYING!");
                    uptime = false;
                }

            }
        }
    }
}