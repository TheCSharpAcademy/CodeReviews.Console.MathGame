

namespace MathGame
{
    public class Quiz
    {
        public int Score { get; private set; }

        private Random _random;

        private Dictionary<int, char> _operations { get; } = new()
        {
            [1] = '+',
            [2] = '-',
            [3] = '*',
            [4] = '/'
        };

        private List<string> History { get; set; }

        private int _firstOperand;
        
        private int _secondOperand;
        
        private char _operation;
        
        private int _result;

        public Quiz()
        {
            History = [];
            _random = new Random();
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
            _operation = _operations[menuSelection];

            _firstOperand = _random.Next(0, 100);
            _secondOperand = _random.Next(0, 100);

            switch (_operation)
            {
                case '+':
                    _result = _firstOperand + _secondOperand;
                    break;
                case '-':
                    _result = _firstOperand - _secondOperand;
                    break;
                case '*':
                    _result = _firstOperand * _secondOperand;
                    break;
                case '/':
                    double quotient;
                    do
                    {
                        _firstOperand = _random.Next(0, 100);
                        _secondOperand = _random.Next(1, _firstOperand);
                        quotient = (double) _firstOperand / _secondOperand;
                    } while (quotient != (int) quotient); // ensures the result is an int
                    _result = (int)quotient;
                    break;
                default:
                    throw new InvalidOperationException("This isn't what I signed up for");
            }

            return $"{_firstOperand} {_operation} {_secondOperand} = ?";
        }

        public bool VerifyAnswer(int userResult)
        {
            LogResult();
            if (_result == userResult)
            {
                Score += 1;
                return true;
            }

            return false;
        }

        public void LogResult()
        {
            string currentResult = $"{_firstOperand} {_operation} {_secondOperand} = {_result}";
            History.Add(currentResult);
        }
    }
}
