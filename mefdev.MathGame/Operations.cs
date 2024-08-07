using System;
namespace MathGame
{
	public class Operations
	{
       
        public Operations()
		{
		}

		public int Addition(int num1, int num2)
		{
			return num1 + num2;
		}
        public int Substraction(int num1, int num2)
        {
            return num1 - num2;
        }
        public int Multiplication(int num1, int num2)
        {
            return num1 * num2;
        }
        public int Division(int num1, int num2)
        {
            try
            {

                return (num1 % num2) == 0 ? (num1 / num2) : 0;
            }
            catch
            {
                Console.Error.WriteLine("Cannot divide by zero!");
                return 0;
            }
            
        }

    }
    
}

