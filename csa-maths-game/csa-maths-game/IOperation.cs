namespace csa_maths_game
{
    public interface IOperation
    {
        public int Execute(int operandA, int operandB);
        public string GetTextString();
        public char GetSymbolChar();
        public bool IsValidOperands(int operandA, int operandB);
    }
}
