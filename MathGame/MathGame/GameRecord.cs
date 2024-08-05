using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class GameRecord
    {
        public int Id {  get; set; }
        public int NumberOfOperations { get; set; }
        public int Result { get; set; }
        public int Seconds { get; set; }
        public Options GameMode { get; set; }
        public GameRecord(int id, int numOperations, int result, int seconds, Options gameMode) 
        { 
            Id = id;
            NumberOfOperations = numOperations;
            Result = result;
            Seconds = seconds;
            GameMode = gameMode;
        }
        public override string ToString()
        {
            return $"{Id}. {Enum.GetName(typeof(Options), GameMode)}: {Result} / {NumberOfOperations}, {Seconds}s";
        }
    }
}
