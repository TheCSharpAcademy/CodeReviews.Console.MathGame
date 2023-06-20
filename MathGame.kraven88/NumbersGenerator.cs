using MathGame.Models;

namespace MathGame;

internal static class NumbersGenerator
{
    public static List<Equasion> GetEquasions(GameEntry game, int range)
    {
        var output = new List<Equasion>();
        for (int i = 0; i < game.NumberOfRounds; i++)
        {
            var eq = new Equasion(game.GameType);

            if (eq.Sign == '/')
                eq.SetNumbersForDivision(range);
            else
                eq.SetNumbers(range);

            output.Add(eq);
        }
        return output;
    }
}
