namespace csa_maths_game
{
    internal class Addition : IOperation
    {
        public int Execute(int operandA, int operandB)
        {
            return operandA + operandB;
        }
        public string GetTextString()
        {
            return "Addition";
        }
        public char GetSymbolChar()
        {
            return '+';
        }
        public bool IsValidOperands(int operandA, int operandB)
        {
            return true;
        }
    }
}
