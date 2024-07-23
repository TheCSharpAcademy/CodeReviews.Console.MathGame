namespace MathGame
{
    public class GameRound(int difficulty = 11)
    {
        private int _firstOperand;
        private int _secondOperand;
        public string? OperatorSign = "+";
        public int _difficulty = difficulty;
        private int _answer;
        private int _correctResult;
        private bool _isCorrect;
        public TimeSpan Duration;

        public int FirstOperand { get { return _firstOperand; } }
        public int SecondOperand { get { return _secondOperand; } }
        public int CorrectResult { get { return _correctResult; } }
        public bool IsCorrect { get { return _isCorrect; } }
        public int Answer
        {
            get
            {
                return _answer;
            }
            set
            {
                _answer = value;
                _isCorrect = _answer == _correctResult;
            }
        }

        public string Difficulty
        {
            get
            {
                return _difficulty switch
                {
                    11 => "Easy",
                    51 => "Medium",
                    101 => "Hard",
                    _ => "Unknown",
                };
            }
            set
            {
                _difficulty = value switch
                {
                    "1" => 11,
                    "2" => 51,
                    "3" => 101,
                    _ => _difficulty
                };
            }
        }

        public void Calculate()
        {
            Random random = Random.Shared;
            _firstOperand = random.Next(0, _difficulty);
            _secondOperand = random.Next(0, _difficulty);

            switch (OperatorSign)
            {
                case "+":
                    _correctResult = FirstOperand + SecondOperand;
                    break;
                case "-":
                    _correctResult = FirstOperand - SecondOperand;
                    break;
                case "*":
                    _correctResult = FirstOperand * SecondOperand;
                    break;
                case "/":
                    while (FirstOperand % SecondOperand != 0 || SecondOperand < 1)
                    {
                        _secondOperand--;
                        if (SecondOperand < 1)
                        {
                            _secondOperand = FirstOperand - 1;
                        }
                    }
                    _correctResult = FirstOperand / SecondOperand;
                    break;
            };
        }
    }
}
