public class GameLog
{
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }

    public string GameOperator { get; set; }

    public double Result { get; set; }
    public double CorrectResult { get; set; }


    public override string ToString()
    {
        return $"User input: {FirstNumber} {GameOperator} {SecondNumber} = {Result}. Correct answer: {CorrectResult}";
    }
}