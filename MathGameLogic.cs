
public class MathGameLogic
{
    public List<string> GameHistory { get; set; } = new List<string>();

    public void ShowMenu()
    {
        Console.WriteLine("Enter an option: ");
        Console.WriteLine("1. Sum");
        Console.WriteLine("2. Sub");
        Console.WriteLine("3. Mult");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Random");
        Console.WriteLine("6. Show History");
        Console.WriteLine("7. Change History");
        Console.WriteLine("8.Exit ");
    }

    public int MathOperation(int firstNumber, int secondNumber, char operation)
    {

        int result = 0;
        switch (operation)
        {

            case '+':
                GameHistory.Add($"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}");
                result = firstNumber + secondNumber;

                break;
            case '-':
                GameHistory.Add($"{firstNumber} - {secondNumber} = {firstNumber - secondNumber}");
                result = firstNumber - secondNumber;

                break;
            case '*':
                GameHistory.Add($"{firstNumber} * {secondNumber} = {firstNumber * secondNumber}");
                result = firstNumber + secondNumber;

                break;
            case '/':
                while (firstNumber < 0 || firstNumber > 100)
                {
                    try
                    {
                        Console.WriteLine("Use a number between 0 and 100.");
                        firstNumber = Convert.ToInt32(Console.ReadLine());
                        if (secondNumber == 0)
                        {
                            Console.WriteLine("Errore: Divisione per zero non permessa.");
                            return 0;
                        }
                    }
                    catch (System.Exception)
                    {

                    }
                }
                GameHistory.Add($"{firstNumber} / {secondNumber} = {firstNumber / secondNumber}");
                result = firstNumber / secondNumber;

                break;

            default:
                ShowMenu();
                break;
        }
        return result;
    }
}
