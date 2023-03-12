namespace Math_Game.Model.Problems
{
    internal class SubtractionReverse : IProblem
    {
        public string Name => "Subtraction_Reverse";
        public string Format => "Integer";
        public string Description =>
@"Subtracting a number with its palindrome:
1. Take the difference between the most significant and the least significant digit and
multiply by the 10^number of digits in the number.
2. Then subtract from that result the difference between the digits.
For 4 digits and above, the middle must be all 0";
        public ProblemType ProblemType => ProblemType.Substraction_Reverse;

        private int firstNumber;
        private int secondNumber;

        public void Generate()
        {
            var random = new Random();
            var digits = random.Next(3, 6);
            if(digits == 3)
            {
                firstNumber = random.Next(100, 999);
            }
            else
            {
                firstNumber = random.Next(1, 9) * (int)Math.Pow(10, digits) + random.Next(1, 9);
            }
            secondNumber = reverse(firstNumber);
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
            else    return Result.Incorrect;
        }

        private int reverse(int number)
        {
            int result = 0;
            while (number > 0)
            {
                result = result * 10 + number % 10;
                number /= 10;
            }
            return result;
            
        }

        public string DisplayAnswer()
        {
            return $"{firstNumber - secondNumber}";
        }
    }
}
