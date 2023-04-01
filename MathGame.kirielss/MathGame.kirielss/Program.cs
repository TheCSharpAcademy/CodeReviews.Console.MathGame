namespace MathGame.kirielss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool uptime = true;
            int score = 0;
            List<string> history = new List<string>();

            Console.WriteLine("WELCOME TO KIRIEL'S MATH GAME");
            Console.WriteLine();

            while (uptime)
            {
                Console.WriteLine("CURRENT SCORE: " + score);
                Console.WriteLine();

                Console.WriteLine("CHOOSE YOUR OPERATION");
                Console.WriteLine();

                Console.WriteLine("1 - ADDITION");
                Console.WriteLine("2 - SUBTRACTION");
                Console.WriteLine("3 - MULTIPLICATION");
                Console.WriteLine("4 - DIVISION");
                Console.WriteLine("9 - PREVIOUS RESULTS");
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
                        history.Add("WIN  // " + game.Question + answer);
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("TOO BAD! THE ANSWER IS " + game.Result);
                        history.Add("LOSE // " + game.Question + answer);
                        Console.ReadLine();
                        Console.Clear();
                    }

                }
                else if (selector == 9)
                {
                    Console.WriteLine("PREVIOUS GAMES:");
                    Console.WriteLine();
                    foreach (string result in history)
                    {
                        Console.WriteLine(result);
                    }
                    Console.WriteLine();
                    Console.WriteLine("CURRENT SCORE: " + score);

                    Console.ReadLine();
                    Console.Clear();
                }
                else if (selector != 0)
                {
                    Console.WriteLine("ERROR! PLEASE INSERT A VALID NUMBER OR 0 TO EXIT");
                    Console.WriteLine();
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