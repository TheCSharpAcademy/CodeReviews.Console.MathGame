using System.Diagnostics;

namespace MathGame
{
    internal abstract class BaseGame
    { 
        public struct Round
        {
            public int left;
            public int right;

            public Round(int left, int right)
            {
                this.left = left;
                this.right = right;
            }
        }

        private int numRounds;
        private int correctAnswers;
        private string gameType;
        private Stopwatch stopwatch;

        protected char operation;
        protected Random rand;


        public BaseGame(int numRounds, char operation, string gameType)
        {
            this.numRounds = numRounds;
            this.operation = operation;
            this.gameType = gameType;

            rand = new Random(Environment.TickCount);
            stopwatch = new Stopwatch();
        }

        public void RunGame()
        {
            stopwatch.Start();
            for (int r = 0; r < numRounds; r++)
            {
                Round round = CreateRound();
                RunRound(round);
            }
            stopwatch.Stop();
            FinishGame();
        }

        protected virtual Round CreateRound()
        {
            GameSettings.Difficulty diff = GameSettings.GetDifficulty();
            return new Round(rand.Next(diff.min, diff.max), rand.Next(diff.min, diff.max));
        }

        private void RunRound(Round round)
        {
            Console.Clear();
            Console.WriteLine($"{round.left} {operation} {round.right} = ?");
            Console.WriteLine("Answer = ");
            int answer = GetAnswer();
            if(Evaluate(round, answer))
            {
                correctAnswers++;
                Console.WriteLine("Correct! Press any key to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Incorrect. Press any key to continue...");
                Console.ReadLine();
            }
        }

        private int GetAnswer()
        {
            string answer = Console.ReadLine();
            int answerInt = 0;

            while(!int.TryParse(answer, out answerInt))
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine("Invalid input, please enter a number...");
                answer = Console.ReadLine();
            }

            return answerInt;
        }

        protected void FinishGame()
        {
            float score = (correctAnswers / (float)numRounds) * 100f;
            Console.Clear();
            Console.WriteLine($"Game Complete! Congratulation, you scored {score.ToString("0.0")}%. Thanks for playing!");
            Console.ReadLine();
            GameHistory.AddGame(gameType, score, (float)stopwatch.Elapsed.TotalSeconds, numRounds, GameSettings.GetDifficulty().name);
        }

        protected abstract bool Evaluate(Round round, int answer);

    }
}
