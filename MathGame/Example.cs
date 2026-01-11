using System.Xml.Linq;

namespace MathGame
{
    public class Example
    {
        private int operand1;
        private int operand2;
        private Operation operation;
        public int Result
        {
            get
            {
                switch (operation)
                {
                    case Operation.Addition:
                        return (operand1 + operand2);
                    case Operation.Subtraction:
                        return (operand1 - operand2);
                    case Operation.Multiplication:
                        return (operand1 * operand2);
                    case Operation.Division:
                        return (operand1 / operand2);
                    default:
                        return 0;
                }
            }
        }
        public string Description
        {
            get
            {
                switch (operation)
                {
                    case Operation.Addition:
                        return $"{operand1} + {operand2} = ";
                    case Operation.Subtraction:
                        return $"{operand1} - {operand2} = ";
                    case Operation.Multiplication:
                        return $"{operand1} * {operand2} = ";
                    case Operation.Division:
                        return $"{operand1} / {operand2} = ";
                    default:
                        return "";
                }
            }
        }
        
        public Example(Level DifficultyLevel) : this(DifficultyLevel, Randomizer.RandomOperation())
        {
        }
        public Example(Level difficultyLevel, Operation operation)
        {
            var diapazoneRandomValue = DiapazoneRandomValue(difficultyLevel);
            var randomOperands = RandomOperandsForOperation(operation, diapazoneRandomValue);
            
            this.operand1 = randomOperands[0];
            this.operand2 = randomOperands[1];
            this.operation = operation;
        }
        public Example(Operation _operation, int _operand1, int _operand2)
        {
            operand1 = _operand1;
            operand2 = _operand2;
            operation = _operation;

            if (BadOperands(operation, operand1, operand2))
                throw new ArgumentException("Неверные операнды для примера");
        }
        
        private (int minValue, int maxValue) DiapazoneRandomValue(Level difficultyLevel)
        {
            if (difficultyLevel == Level.easy)
                return (1, 10);
            else if (difficultyLevel == Level.medium)
                return (1, 100);
            else if (difficultyLevel == Level.difficult)
                return (10, 100);
            return (1, 10);
        }
        private static bool BadOperands(Operation operation, int operand1, int operand2)
        {
            if (operation != Operation.Division)
                return false;

            if (operand2 == 0)
                return true;
            else if (operand1 % operand2 != 0)
                return true;
            return false;
        }
        private static int[] RandomOperandsForOperation(Operation operation, (int minValue, int maxValue) diapazoneRandomValue)
        {
            var randomizer = new Random();
            var result = new int[2];
            do
            {
                result[0] = randomizer.Next(diapazoneRandomValue.minValue, diapazoneRandomValue.maxValue);
                result[1] = randomizer.Next(diapazoneRandomValue.minValue, diapazoneRandomValue.maxValue);
            }
            while (BadOperands(operation, result[0], result[1]));
            return result;
        }
    }
}