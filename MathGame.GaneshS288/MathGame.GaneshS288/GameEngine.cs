using MathGame;

namespace MathGame;

internal class GameEngine
{
    MathOperations mathOperations = new MathOperations();
    Menu menu = new Menu();
    Random random = new Random();

    int firstNum;
    int secondNum;
    int result = 0;

    List<string> gameRecords = new List<string>();
    int recordCounter = 0;

    internal string PlayGame(string? userInput, int index)
    {
        bool isValidInput = false;

        firstNum = random.Next(1, 101);
        secondNum = random.Next(1, 101);

        while (isValidInput != true)
        {
            switch (menu.gameName[index])
            {
                case "Addition":
                    result = mathOperations.Add(firstNum, secondNum);
                    break;

                case "Subtraction":
                    result = mathOperations.Subtract(firstNum, secondNum);
                    break;

                case "Multiplication":
                    result = mathOperations.Multiply(firstNum, secondNum);
                    break;

                case "Division":
                    GetValidDivisionNumbers();
                    result = mathOperations.Divide(firstNum, secondNum);
                    break;
            }

            menu.PrintCurrentGame(firstNum, secondNum, index);

            userInput = Console.ReadLine()?.Trim().ToLower();

            int userAnswer;
            isValidInput = int.TryParse(userInput, out userAnswer);

            if (isValidInput == true && result == userAnswer)
            {
                Console.WriteLine($"{result} was the right answer!(Press enter to continue)\n");
                Console.ReadLine();

                //retain index value to prevent indexOutOfRange error
                userInput = $"{index}";

                AddGameRecords(index, userAnswer);
            }

            else if (isValidInput == true && result != userAnswer)
            {
                Console.WriteLine($"{userAnswer} is not the right answer, the right answer is {result}. (press enter to continue)\n");
                Console.ReadLine();

                AddGameRecords(index, userAnswer);
            }

            else if (userInput == "exit")
                break;

            else
            {

                Console.WriteLine("Please enter a valid value.(Press Enter to continue)");
                Console.ReadLine();
            }
        }

        return userInput == null ? userInput = "exit" : userInput;
    }

    void GetValidDivisionNumbers()
    {
        while (true)
        {
            firstNum = random.Next(1, 101);
            secondNum = random.Next(1, 101);

            if (firstNum % secondNum == 0)
                break;
        }
    }

    void AddGameRecords(int index, int userAnswer)
    {
        recordCounter++;
        gameRecords.Add($"Game {recordCounter}: Problem: {firstNum} {menu.mathOperators[index]} {secondNum}, \tAnswer: {result}, \tUser answer: {userAnswer} ");
    }

    internal void DisplayGameRecords()
    {
        Console.Clear();

        if (!gameRecords.Any())
        {
            Console.WriteLine("No more records to display(Press enter to continue)");
            Console.ReadLine();
        }

        foreach (string record in gameRecords)
        {
            Console.WriteLine(record);

            if (gameRecords.IndexOf(record) == (gameRecords.Count - 1))
            {
                Console.WriteLine("\nNo more records to display(Press enter to continue)");
                Console.ReadLine();
            }

        }
    }
}
