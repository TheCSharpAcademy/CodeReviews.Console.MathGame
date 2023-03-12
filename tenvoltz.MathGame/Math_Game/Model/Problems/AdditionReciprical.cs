using Math_Game.Model.NumericalType;

namespace Math_Game.Model.Problems
{
    internal class AdditionReciprical : IProblem
    {
        public string Name => "Addition_Reciprical";
        public string Format => "Mixed Fraction [a b/c]";
        public string Description => 
@"Addition of fraction and its reciprical
a/b + b/a = 2 + (a-b)^2 / ab
Example:
2/3 + 3/2 = 2 + (3-2)^2 / (3*2) = 2 1/6";
        public ProblemType ProblemType => ProblemType.Addition_Reciprical;

        private Fraction firstFraction;
        private Fraction secondFraction;
        private Fraction answer;

        public void Generate()
        {
            var random = new Random();
            int numerator = random.Next(1, 20);
            int denominator;
            do
            {
                denominator = random.Next(2, 20);
            } while (denominator == numerator);
            firstFraction = new Fraction(numerator, denominator);
            firstFraction = firstFraction.Simplify();
            secondFraction = new Fraction(denominator, numerator);
            secondFraction = secondFraction.Simplify();

            answer = firstFraction + secondFraction;
            answer = answer.Simplify();
        }

        public String Display()
        {
            return $"{firstFraction.DisplayImproper()} + {secondFraction.DisplayImproper()}";
        }

        public Result Validate(string result)
        {
            if (string.IsNullOrEmpty(result))
            {
                return Result.Invalid;
            }
            if (result == answer.DisplayMixed())
                return Result.Correct;
            else return Result.Incorrect;

        }

        public string DisplayAnswer()
        {
            return answer.DisplayMixed();
        }
    }
}
