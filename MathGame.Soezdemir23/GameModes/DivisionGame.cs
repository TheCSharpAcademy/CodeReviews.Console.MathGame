using mathgame.Model;

namespace mathgame.GameModes;

/// <summary>
/// Represents a division game mode where players solve division problems.
/// </summary>
public class DivisionGame : GameMode
{
    /// <summary>
    /// Generates a division question with two random numbers where the division results in a whole number.
    /// </summary>
    /// <returns>A tuple containing the dividend, divisor, and quotient.</returns>
    protected override (int left, int right, int answer) GenerateQuestion()
    {
        
        int leftSide, rightSide;
        do
        {
            leftSide = _random.Next(1, 100);
            rightSide = _random.Next(1, 100);
            
        } while (leftSide % rightSide != 0); // ensure divisibility
        return (leftSide, rightSide, leftSide / rightSide);
    }

    /// <summary>
    /// Gets the name of this game mode.
    /// </summary>
    /// <returns>The string "Division".</returns>
    protected override string GetModeName()=> "Division";

    /// <summary>
    /// Gets the operator symbol for division.
    /// </summary>
    /// <returns>The division operator "/".</returns>
    protected override string GetOperatorSymbol() => "/";
}
