using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    internal class GameSession
    {
        public int Score { get; set; }
        public string? Name { get; set; }
        public List<string> History { get; set; } = new List<string>();
        private Stopwatch stopwatch = new Stopwatch();

        public void ResetScore() => Score = 0;
        public void SaveGameData(string mode, string difficulty) 
        {
            History.Add($"| {Name, -8} |   {Score.ToString()}   | {difficulty,-10} | {DateTime.Now.ToString("dd/MM/yyyy")} | {GetElapsedTime()} | {mode, - 14} |");
        }
        public void StartTimer()
        {
            stopwatch.Start();
        }
        public void StopTimer()
        {
            stopwatch.Stop();
        }
        public void ResetTimer()
        {
            stopwatch.Reset();
        }
        public string GetElapsedTime()
        {
            TimeSpan elapsedTime = stopwatch.Elapsed;
            return $"{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}";
        }
    }
}
