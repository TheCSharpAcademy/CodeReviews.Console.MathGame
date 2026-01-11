using System.Diagnostics;

namespace MathGame
{
    public class Game
    {
        public int Id { get; }
        public Player Player { get; }
        public Level Level { get; }
        public Example[] Examples { get; }

        private int score;
        public int Score { get { return score; } }

        private double time;
        public double Time { get { return time; } }

        public Game(int id, Player player)
        {
            Id = id;
            Player = player;
            Level = Randomizer.RandomLevel();
            Examples = new Example[new Random().Next(5, 10)];
            for (int i = 0; i < Examples.Count(); i++)
            {
                Examples[i] = new Example(Level);
            }
        }
        public Game(int id, Player player, Level level, List<Operation> operations)
        {
            Id = id;
            Player = player;
            Level = level;

            Examples = new Example[operations.Count()];
            for (int i = 0; i < Examples.Length; i++)
            {
                Examples[i] = new Example(Level, operations[i]);
            }
        }

        public void Play()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var example in Examples)
            {
                Console.Write(example.Description);
                var answer = Console.ReadLine();
                var correctAnswer = answer == example.Result.ToString();
                if (correctAnswer)
                {
                    score++;
                    Console.WriteLine("Это правильный ответ!");
                }
                else
                {
                    Console.WriteLine($"Это неверный ответ! Правильный ответ: {example.Result}");
                }
            }
            stopwatch.Stop();

            time = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine($"Игра окончена с результатом {Score}/{Examples.Count()}.");
        }
    }
}