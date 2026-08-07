public static class QuestionGenerator
{
    private static Random random = new Random();
    public static Question EasyAddition()
    {
        int firstNumber = random.Next(1, 31);
        int secondNumber = random.Next(1, 31);

        return new Question
        {
            FirstNumber = firstNumber,
            SecondNumber = secondNumber,
            Operator = '+',
            CorrectAnswer = firstNumber + secondNumber
        };
    }
    public static Question HardAddition()
    {
        int firstNumber = random.Next(1, 151);
        int secondNumber = random.Next(1, 151);

        return new Question
        {
            FirstNumber = firstNumber,
            SecondNumber = secondNumber,
            Operator = '+',
            CorrectAnswer = firstNumber + secondNumber
        };
    }
    public static Question EasySubtraction()
    {
        int firstNumber = random.Next(1, 31);
        int secondNumber = random.Next(1, firstNumber + 1);

        return new Question
        {
            FirstNumber = firstNumber,
            SecondNumber = secondNumber,
            Operator = '-',
            CorrectAnswer = firstNumber - secondNumber
        };
    }
    public static Question HardSubtraction()
    {
        int firstNumber = random.Next(1, 151);
        int secondNumber = random.Next(1, firstNumber + 1);

        return new Question
        {
            FirstNumber = firstNumber,
            SecondNumber = secondNumber,
            Operator = '-',
            CorrectAnswer = firstNumber - secondNumber
        };
    }
    public static Question EasyMultiplication()
    {
        int firstNumber = random.Next(2, 15);
        int secondNumber = random.Next(2, 15);

        return new Question
        {
            FirstNumber = firstNumber,
            SecondNumber = secondNumber,
            Operator = '*',
            CorrectAnswer = firstNumber * secondNumber
        };
    }
    public static Question HardMultiplication()
    {
        int firstNumber = random.Next(1, 51);
        int secondNumber = random.Next(4, 15);

        return new Question
        {
            FirstNumber = firstNumber,
            SecondNumber = secondNumber,
            Operator = '*',
            CorrectAnswer = firstNumber * secondNumber
        };
    }
    public static Question EasyDivision()
    {
        int divisor = Random.Shared.Next(1, 11);
        int quotient = Random.Shared.Next(0, 11);

        int dividend = divisor * quotient;

        return new Question
        {
            FirstNumber = dividend,
            SecondNumber = divisor,
            Operator = '/',
            CorrectAnswer = quotient
        };
    }
    public static Question HardDivision()
    {
        int divisor = Random.Shared.Next(1, 31);
        int quotient = Random.Shared.Next(0, 31);

        int dividend = divisor * quotient;

        return new Question
        {
            FirstNumber = dividend,
            SecondNumber = divisor,
            Operator = '/',
            CorrectAnswer = quotient
        };
    }
}