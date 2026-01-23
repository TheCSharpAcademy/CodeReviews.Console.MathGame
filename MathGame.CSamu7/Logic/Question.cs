using MathGame.Utils;

namespace MathGame.Logic
{
    public class Question
    {
        private readonly OperationGenerator _operationGenerator;
        public Question(OperationGenerator operationGenerator)
        {
            _operationGenerator = operationGenerator;
        }
        public int Prompt(string operation)
        {
            Console.Clear();
            Operation op = _operationGenerator.Generate(operation);

            Console.WriteLine($"What's the result of {op.N1} {op.Operator} {op.N2}?");
            int answer = GetAnswer();

            return answer == op.Calculate() ? 1 : 0;
        }
        private int GetAnswer()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int answer))
                    return answer;

                ConsoleUtils.Error("You need to enter a number");
            }
        }
    }
}
