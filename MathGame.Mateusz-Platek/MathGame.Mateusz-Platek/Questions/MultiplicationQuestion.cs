namespace MathGame.Mateusz_Platek.Questions;

public class MultiplicationQuestion : Question
{
    public MultiplicationQuestion(DifficultyLevel difficultyLevel)
    {
        Random random = new Random();
        if (difficultyLevel == DifficultyLevel.Easy)
        {
            base.Value1 = random.Next(0, 11);
            base.Value2 = random.Next(0, 11);
        } else if (difficultyLevel == DifficultyLevel.Medium)
        {
            base.Value1 = random.Next(0, 51);
            base.Value2 = random.Next(0, 51);
        }
        else
        {
            base.Value1 = random.Next(0, 101);
            base.Value2 = random.Next(0, 101);
        }
        base.Result = Value1 * Value2;
    }

    public override string ToString()
    {
        return $"{Value1} * {Value2} = {Result}";
    }
}