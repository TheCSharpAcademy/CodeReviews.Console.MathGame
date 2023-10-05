using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MathGame.vilvee.Program;

namespace MathGame.vilvee
{
    public class Game
    {
        public DateTime DateTime { get; set; }

        public int Score { get; set; }

        public Operation OperationName { get; set; }

        public string gameTime { get; set; }

        public Stopwatch Stopwatch { get; set; }

        public Game(Operation operation)
        {
            Stopwatch = new Stopwatch();
            Stopwatch.Start();
            DateTime = DateTime.Now;
            Score = 0;
            OperationName = operation;
            gameTime = "";

        }

        public override string ToString()
        {
            const string FORMAT = "{0, -15} Score: {1, -15} Time: {2, -15} {3, -15}";

            return String.Format(FORMAT, OperationName, this.Score, this.gameTime, this.DateTime);
        }
    }
}
