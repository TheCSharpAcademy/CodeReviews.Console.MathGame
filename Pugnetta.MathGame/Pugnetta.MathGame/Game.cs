using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pugnetta.MathGame.Game;

public record Game
{
    public int N1 { get; }
    public int N2 { get; }
    private Game(int n1, int n2) => (N1, N2) = (n1, n2);
    public static Game Create()
    {
        Random rnd = new Random();
        int n1 = rnd.Next(1, 100);
        int n2 = rnd.Next(1, 100);
        return new Game(n1, n2);
    }
}
public record Result(bool Win, int Guess);
public enum Operation
{
    Sum,
    Sub,
    Mol,
    Div
}