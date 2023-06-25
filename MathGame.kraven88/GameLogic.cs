using MathGame.Models;
using static MathGame.NumbersGenerator;
using static MathGame.UI.UserMessages;

namespace MathGame;

internal class GameLogic
{
    int EasyRange = 10;
    int MediumRange = 100;
    int HardRange = 1000;

    internal GameEntry NewGame(GameEntry game)
    {
        var equasions = game.Difficulty switch
        {
            Difficulty.Easy => GetEquasions(game, EasyRange),
            Difficulty.Medium => GetEquasions(game, MediumRange),
            Difficulty.Hard => GetEquasions(game, HardRange),
        };

        foreach (var eq in equasions)
        {
            var isCorrectAnswer = PlayRound(eq);
            if (isCorrectAnswer)
            {
                PrintLine("Correct!\n");
                game.Score++;
            }
            else
                PrintLine("Sorry, that's incorrect.\n");
        }

        return game;
    }

    private bool PlayRound(Equasion eq)
    {
        Print($"{eq.A} {eq.Sign} {eq.B} = ");
        var answer = GetAndValidateInteger("The answer must be an Integer.");

        return answer == eq.Result;
    }

}
