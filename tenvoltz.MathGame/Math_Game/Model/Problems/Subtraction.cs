namespace Math_Game.Model.Problems
{
    internal class Subtraction : IProblem
    {
        public string Name => "Subtraction";
        public string Format => "Integer";
        public string Description => "Subtraction of two numbers from 1 to 100";
        public ProblemType ProblemType => ProblemType.Subtraction;

        private int firstNumber;
        private int secondNumber;

        public void Generate()
        {
            var random = new Random();
            firstNumber = random.Next(1, 99);
            secondNumber = random.Next(1, 99);
        }
        public String Display()
        {
            return $"{firstNumber} - {secondNumber}";
        }

        public Result Validate(string resultStr)
        {
            int result;
            if (string.IsNullOrEmpty(resultStr) ||
                !Int32.TryParse(resultStr, out result))
            {
                return Result.Invalid;
            }

            if (result == firstNumber - secondNumber)
                return Result.Correct;
            else return Result.Incorrect;
        }

        public string DisplayAnswer()
        {
            return $"{firstNumber - secondNumber}";
        }
    }
}
