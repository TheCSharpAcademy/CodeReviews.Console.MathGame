using mathgame.Model;

namespace mathgame.GameModes;

/// <summary>
/// Represents a subtraction game mode where players solve subtraction problems.
/// </summary>
public class SubtractionGame : GameMode
{
    /// <summary>
    /// Generates a random subtraction question with non-negative results.
    /// </summary>
    /// <returns>A tuple containing the left operand, right operand, and the correct answer.</returns>
    protected override (int left, int right, int answer) GenerateQuestion()
    {
        
        int leftSide = _random.Next(1, 100);
        int rightSide = _random.Next(1, leftSide); // ensure no negative results
        return (leftSide, rightSide, leftSide - rightSide);
    }

    /// <summary>
    /// Gets the name of the game mode.
    /// </summary>
    /// <returns>The string "Subtraction".</returns>
    protected override string GetModeName() => "Subtraction";

    /// <summary>
    /// Gets the operator symbol for subtraction.
    /// </summary>
    /// <returns>The string "-".</returns>
    protected override string GetOperatorSymbol() => "-";
}
