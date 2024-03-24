using System.Linq.Expressions;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello there! welcome to a math game");

        bool isActive = true;
        bool error = false;
        int output = 0;
        int convertedFirstNum = 0;
        int convertedSecondNum = 0;
        //List<> history = new List<T>();

        while (isActive)
        {
            Console.WriteLine("What operation would you love to perform?");
            Console.WriteLine("\nA.'+'\nB.'-'\nC.'x'\nD.'÷'\n ");
            string? operation = Console.ReadLine();

            Console.Write("Enter your first number: ");
            string? firstNum = Console.ReadLine();

            Console.Write("Enter your second number: ");
            string? secondNum = Console.ReadLine();

            try
            {
                convertedFirstNum = Convert.ToInt32(firstNum);
                convertedSecondNum = Convert.ToInt32(secondNum);
            }
            catch
            {
                Console.WriteLine("Invalid first or second number, first num and second num must be an integer");
                Console.WriteLine($"firstNum: {firstNum}, secondNum; {secondNum}");
                error = true;
            }

            //try
            //{
            //    operation = operation.ToUpper();
            //}
            //catch
            //{
            //    Console.WriteLine("Invalid operation supplied, operation must be one of the items in the list");
            //    Console.WriteLine($"operation: {operation}");
            //    error = true;
            //}

            //if (operation != "A" || operation != "B" || operation != "C" || operation != "D")
            //{
            //    Console.WriteLine("Invalid operation supplied, operation must be one of the items in the list");
            //    Console.WriteLine($"operation: {operation}");
            //    error = true;
            //}

            if (!error)
            {
                switch (operation?.ToUpper())
                {
                    case "A":
                        output = convertedFirstNum + convertedSecondNum;
                        break;
                    case "B":
                        output = convertedFirstNum - convertedSecondNum;
                        break;
                    case "C":
                        output = convertedFirstNum * convertedSecondNum;
                        break;
                    case "D":
                        output = convertedFirstNum / convertedSecondNum;
                        break;
                    default:
                        Console.WriteLine("Invalid operation passed, please select one of A. B. C. D.");
                        break;
                }
            }

            Console.Write($"ANSWER: {output}\n");

            Console.WriteLine($"Would you love to continue? Enter 'Y' for yes or 'N' for no: ");
            string? continueCalculation = Console.ReadLine();

            if (continueCalculation == "Y" || continueCalculation == "y")
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }

        }
        Console.WriteLine("Exiting application...");
    }
}
