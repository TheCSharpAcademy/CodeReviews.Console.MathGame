
namespace MathGame
{
    internal class Operation
    {
        public int Addition(int num1, int num2)
        {
            return num1 + num2; 
        }

        public int Difference(int n1, int n2)
        {
            return n1 - n2;
        }

        public int Multiplication(int a, int b)
        {
            return a * b;
        }

        public int Division(int x, int y)
        {
            try
            {
                return x / y;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public void DisplayHistory(List<string> listItems)
        {
            foreach (string i in listItems)
            {
                Console.WriteLine(i);
            }
        }
    }
}