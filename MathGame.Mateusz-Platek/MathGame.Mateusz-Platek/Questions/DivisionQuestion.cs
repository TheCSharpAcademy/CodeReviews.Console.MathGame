namespace MathGame.Mateusz_Platek.Questions;

public class DivisionQuestion : Question
{
    public DivisionQuestion(DifficultyLevel difficultyLevel)
    {
        Random random = new Random();
        if (difficultyLevel == DifficultyLevel.Easy)
        {
            base.Value1 = random.Next(0, 11);
            do
            {
                base.Value2 = random.Next(1, Value1 + 1);
            } while (base.Value1 % base.Value2 != 0);
        } else if (difficultyLevel == DifficultyLevel.Medium)
        {
            base.Value1 = random.Next(0, 51);
            do
            {
                base.Value2 = random.Next(1, Value1 + 1);
            } while (base.Value1 % base.Value2 != 0);
        }
        else
        {
            base.Value1 = random.Next(0, 101);
            do
            {
                base.Value2 = random.Next(1, Value1 + 1);
            } while (base.Value1 % base.Value2 != 0);
        }
        base.Result = Value1 / Value2;
    }

    public override string ToString()
    {
        return $"{Value1} / {Value2} = {Result}";
    }
}