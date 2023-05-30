using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.Parabeiium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To the Math Game , Where you choose type of Game and answer questions accordingly");
            var game = new Runner();
            game.Run();
        }
    }
}
