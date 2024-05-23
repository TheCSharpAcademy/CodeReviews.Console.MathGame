using System.Numerics;

public class UserInteraction
{
    public Operation OperationsMenu()
    {
        do
        {
            Console.WriteLine("What would you like to do:");
            Console.WriteLine("1. Add (+)");
            Console.WriteLine("2. Subtract (-)");
            Console.WriteLine("3. Multiply (*)");
            Console.WriteLine("4. Divide (/)");
            var input = Console.ReadLine();

            if (int.TryParse(input, out int result) && result is >= 1 and <= 4)
            {
                switch (result)
                {
                    case 1: return Operation.Add;
                    case 2: return Operation.Subtract;
                    case 3: return Operation.Multiply;
                    case 4: return Operation.Divide;
                }
            }

            Console.WriteLine("Invalid input. Please any key to continue and try again.");
            Console.ReadKey();
            Console.WriteLine();

        } while (true);
    }
}