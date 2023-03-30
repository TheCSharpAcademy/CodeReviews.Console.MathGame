using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGameLibrary.sadklouds.Models
{
    public class GameSessionModel
    {
        public int Score { get; set; }
        public string GameType { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan TimeTaken { get; set; }
    }
}
