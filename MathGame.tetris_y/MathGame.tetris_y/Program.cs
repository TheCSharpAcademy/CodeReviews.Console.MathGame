while (true)
{
    Console.WriteLine("===== Welcome to the Math Game! =====");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");
    Console.WriteLine("5. Exit");

    Console.Write("Enter your choice (1-5):");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            //PerformAddition();
            break;
        case 2:
            //PerformSubtraction();
            break;
        case 3:
            //PerformMultiplication();
            break;
        case 4:
            //PerformDivision();
            break;
        case 5:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thank you for playing! Goodbye!\n");
            Console.ResetColor();
            return;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid choice. Please try again.\n");
            Console.ResetColor();
            break;
    }
}