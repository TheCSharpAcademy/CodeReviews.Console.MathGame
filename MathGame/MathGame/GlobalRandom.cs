using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal sealed class GlobalRandom
    {
        private static readonly Random _random = new Random();
        private GlobalRandom() { }

        public static Random Instance
        {
            get
            {
                return _random;
            }
        }
    }
}
