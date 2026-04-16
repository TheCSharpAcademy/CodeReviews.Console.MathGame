

namespace MathGame
{
    public class Quiz
    {
        public int Score { get; private set; }

        private Random random;

        private Dictionary<int, char> mathOperations { get; } = new()
        {
            [1] = '+',
            [2] = '-',
            [3] = '*',
            [4] = '/'
        };

        private List<string> History { get; set; }

        private int firstOperand;
        
        private int secondOperand;
        
        private char operation;
        
        private int result;

        public Quiz()
        {
            History = [];
            random = new Random();
        }

        public void PrintHistory()
        {
            if (History.Count == 0)
            {
                Console.WriteLine("You haven't played any games.");
                return;
            }

            Console.WriteLine("Game results:");
            foreach (var game in History)
            {
                Console.WriteLine(game);
            }
        }

        public string GenerateQuestion(int menuSelection)
        {
            operation = mathOperations[menuSelection];

            firstOperand = random.Next(0, 101);
            secondOperand = random.Next(0, 101);

            switch (operation)
            {
                case '+':
                    result = firstOperand + secondOperand;
                    break;
                case '-':
                    result = firstOperand - secondOperand;
                    break;
                case '*':
                    result = firstOperand * secondOperand;
                    break;
                case '/':
                    // Division's result must be a true integer, dividend must be between 0-100
                    int quotient = random.Next(0, 11);
                    int divisor = random.Next(1, 11);
                    int dividend = quotient * divisor;

                    result = quotient;
                    firstOperand = dividend;
                    secondOperand = divisor;
                    break;
                default:
                    throw new InvalidOperationException("This isn't what I signed up for");
            }

            return $"{firstOperand} {operation} {secondOperand} = ?";
        }

        public bool VerifyAnswer(int userResult)
        {
            LogResult();
            if (result == userResult)
            {
                Score += 1;
                return true;
            }

            return false;
        }

        public void LogResult()
        {
            string currentResult = $"{firstOperand} {operation} {secondOperand} = {result}";
            History.Add(currentResult);
        }
    }
}
