namespace MathGame.Logic
{
    public class DivisionValidation()
    {
        public bool IsValid(int n1, int n2)
        {
            bool areDividendsNotEqual = n1 != n2;
            bool isQuotientAnInteger = n1 % n2 == 0;

            return areDividendsNotEqual
                && isQuotientAnInteger;
        }
    }
}
