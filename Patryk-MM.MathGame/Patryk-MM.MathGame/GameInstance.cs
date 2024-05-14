using Patryk_MM.MathGame.Helpers;
using System;
using System.Buffers;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patryk_MM.MathGame {
    internal class GameInstance {
        public DateTime StartTime { get; set; }
        public TimeSpan GameDuration { get; set; }
        public char GameMode { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }

        static Dictionary<Func<int, int, int>, char> operations = new Dictionary<Func<int, int, int>, char>() {
            {(a,b) => a + b, '+'},
            {(a,b) => a - b, '-'},
            {(a,b) => a * b, '*'},
            {(a,b) => a / b, '/'},
        };


        public GameInstance(DateTime startTime, char gameMode, int maxScore) {
            StartTime = startTime;
            GameMode = gameMode;
            MaxScore = maxScore;
        }

        public void HandleGame(char gameMode) {
            Console.WriteLine("The game has started. Good luck!\n");
            for (int i = 1; i <= MaxScore; i++) {
                switch (gameMode) {
                    case '+':
                        HandleRound((a, b) => a + b, '+', i);
                        break;
                    case '-':
                        HandleRound((a, b) => a - b, '-', i);
                        break;
                    case '*':
                        HandleRound((a, b) => a * b, '*', i);
                        break;
                    case '/':
                        HandleRound((a, b) => a / b, '/', i);
                        break;
                    case 'r':
                        Random random = new Random();
                        int rand = random.Next(0, operations.Count);
                        KeyValuePair<Func<int, int, int>, char> pair = operations.ElementAt(rand);
                        HandleRound(pair.Key, pair.Value, i);
                        break;
                } 
            }
            GameDuration = DateTime.Now - StartTime;

            Console.WriteLine($"Score: {Score}/{MaxScore}   Time: {GameDuration.TotalSeconds:0.00} seconds");
        }

        public void HandleRound(Func<int, int, int> operation, char symbol, int roundNumber) {
                var (a, b) = NumberGenerator.GenerateNumbers(symbol);
                Console.WriteLine($"Round {roundNumber}/{MaxScore}");
                Console.Write($"{a} {symbol} {b} = ");
                int input;
                while (!int.TryParse(Console.ReadLine(), out input)) {
                    Console.WriteLine("Please provide a valid answer.");
                    Console.Write($"{a} {symbol} {b} = ");
                }
                if (input == operation(a, b)) {
                    Score++;
                    Console.WriteLine("Good answer!\n");
                } else {
                    Console.WriteLine($"Wrong! The answer was {operation(a, b)}.\n");
            }
        }
    }
}
