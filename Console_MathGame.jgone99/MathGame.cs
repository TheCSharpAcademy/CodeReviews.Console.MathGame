using System.Diagnostics;

namespace Console_MathGame
{
    public class MathGame
    {
        private Random? random;
        private int b, target, result, rounds;
        private bool isGameRunning;
        private GameHistory gameHistory = new();
        private const int roundLimit = 5, winAccuracy = 5;

        private string instructions =
            "Goal:\n" +
            "  approximate the TARGET integer\n\n" +
            "How-to-play:\n" +
            "  each game begins with a TARGET integer, a RESULT integer, and two operand integers A and B.\n" +
            "  you must choose an operation to be applied to the two operands, the result of which will be\n" +
            "  stored in RESULT as well as be used in the next round as operand A. a new random integer will\n" +
            $"  become operand B. the game ends after {roundLimit} rounds of the RESULKT missing the TARGET or when RESULT\n" +
            $"  is within {winAccuracy} of the TARGET. if the former is true, then you lose. if the latter is true, then you\n" +
            "  win.";

        private const string mainScreen =
            "\nConsole Math Game\n\n" +
            "TARGET: {0}\n\n" +
            "RESULT: {1}\n\n" +
            "A: {2}\n\n" +
            "B: {3}\n\n" +
            "1. +\n" +
            "2. -\n" +
            "3. *\n" +
            "4. /\n" +
            "5. view game history\n" +
            "6. instructions\n\n" +
            "Esc to end game";

        // flash a message on screen until a key is read from input or until the
        // specified time interval has elapsed.
        private static void FlashMessage(string message, TimeSpan? interval = null)
        {
            Console.Clear();
            if (interval.HasValue)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                Console.Write("\n" + message + "\n");
                while (stopwatch.Elapsed < interval) ;
            }
            else
            {
                Console.Write("\n" + message + "\n\nPress any key to continue\n");
                while (!Console.KeyAvailable) ;
                _ = Console.ReadKey(true);
            }
            Console.Clear();
        }

        private void DisplayMainScreen()
        {
            Console.WriteLine(mainScreen, target, result, result, b);
        }

        public void Start()
        {
            while (true)
            {
                GameLoop();
            }
        }

        // main game loop
        private void GameLoop()
        {
            random = new();
            target = random.Next(101);
            result = random.Next(100);
            rounds = 0;
            ConsoleKey key;
            do
            {
                Console.Clear();
                b = random.Next(50);
                DisplayMainScreen();

                // input loop
                do
                {
                    key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }
                    else if (key == ConsoleKey.D1)
                    {
                        result += b;
                        break;
                    }
                    else if (key == ConsoleKey.D2)
                    {
                        result -= b;
                        break;
                    }
                    else if (key == ConsoleKey.D3)
                    {
                        result *= b;
                        break;
                    }
                    else
                    {
                        if (key == ConsoleKey.D4)
                        {
                            if (result < 0 || result > 100)
                            {
                                FlashMessage("dividend must be between 0 and 100");
                            }
                            else if (b <= 0)
                            {
                                FlashMessage("Cannot divide by zero");
                            }
                            else
                            {
                                result /= b;
                                break;
                            }
                        }
                        else if (key == ConsoleKey.D5)
                        {
                            gameHistory.View();
                        }
                        else if (key == ConsoleKey.D6)
                        {
                            FlashMessage(instructions);
                        }
                        else
                        {
                            // makes sure unrecognized inputs don't unnecessarily re-display the screen
                            continue;
                        }
                        DisplayMainScreen();
                    }
                }
                while (true);
                isGameRunning = ++rounds < roundLimit && Math.Abs(target - result) > winAccuracy;
            }
            while (isGameRunning);
            gameHistory.Add(new MathGameInfo(rounds, target, result, Math.Abs(target - result) <= winAccuracy));
            FlashMessage($"END OF GAME\nYOU {(Math.Abs(target - result) <= winAccuracy ? "WON" : "LOST")}");
        }

        // inner class to keep track of previous games
        private class GameHistory
        {
            private bool inGHView;
            private LinkedListNode<MathGameInfo>? gameNode;
            private int gameIndex;

            private const string gameHistoryScreen =
                "\nGame History View\n\n" +
                "game {0}/{1}\n\n" +
                "{2}\n\n" +
                "<- previous (left arrow)\tEsc to exit\tnext (right arrow) ->";

            private LinkedList<MathGameInfo> history = new();

            public void Add(MathGameInfo mathGameInfo)
            {
                history.AddFirst(mathGameInfo);
            }

            private void DisplayGameHistoryScreen()
            {
                Console.WriteLine(gameHistoryScreen, gameIndex, history.Count, gameNode.Value.ToString());
            }

            // game history view loop
            public void View()
            {
                if (history.Count == 0)
                {
                    FlashMessage("Game history is empty");
                    return;
                }
                ConsoleKey key;
                inGHView = true;
                gameNode = history.First;
                gameIndex = history.Count;
                do
                {
                    Console.Clear();
                    DisplayGameHistoryScreen();

                    // input loop
                    do
                    {
                        key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.LeftArrow && gameNode.Next != null)
                        {
                            gameNode = gameNode.Next;
                            gameIndex--;
                            break;
                        }
                        else if (key == ConsoleKey.RightArrow && gameNode.Previous != null)
                        {
                            gameNode = gameNode.Previous;
                            gameIndex++;
                            break;
                        }
                        else if (key == ConsoleKey.Escape)
                        {
                            inGHView = false;
                            break;
                        }
                    }
                    while (true);
                }
                while (inGHView);
                Console.Clear();
            }
        }
    }

    // representation of previous games
    struct MathGameInfo
    {
        private int rounds, target, result;
        private bool won;
        public MathGameInfo(int rounds, int target, int result, bool won)
        {
            this.rounds = rounds;
            this.target = target;
            this.result = result;
            this.won = won;
        }
        override public string ToString()
        {
            return $"won: {won}\n\nrounds: {rounds}\n\nTARGET: {target}\n\nRESULT: {result}";
        }
    }

}
