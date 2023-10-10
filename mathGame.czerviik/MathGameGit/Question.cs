namespace mathGame.czerviik;

public class Question
{
	private int[] ranNoArray = new int[2];
    private readonly Random random = new Random();
    private Scoreboard scoreboard;
    public GameTypes GameType { get; private set; }
    public int Difficulty { get; private set; }
    public int Result { get; private set; }

    public Question(GameTypes gameType, int difficulty, Scoreboard scoreboard)
	{
        GameType = gameType;
        Difficulty = difficulty;
        this.scoreboard = scoreboard;
        RandomNumbersArray();
        Display(GameType);
	}

	private int[] RandomNumbersArray()
    {
        int number1;
        int number2;
        int highestNumber = 0;

        if (Difficulty == 1)
            highestNumber = 50;
        else if (Difficulty == 2)
            highestNumber = 100;
        else if (Difficulty == 3)
            highestNumber = 1000;

        number1 = random.Next(1, highestNumber);
        number2 = random.Next(1, highestNumber);
        ranNoArray[0] = number1;
        ranNoArray[1] = number2;
        return ranNoArray;
    }

    private void Display(GameTypes gameType)
    {
        var oper = "";

        switch (gameType)
        {
            case GameTypes.Addition:
                oper = "+";
                Result = ranNoArray[0] + ranNoArray[1];
                break;
            case GameTypes.Subtraction:
                oper = "-";
                Result = ranNoArray[0] - ranNoArray[1];
                break;
            case GameTypes.Multiplication:
                oper = "*";
                Result = ranNoArray[0] * ranNoArray[1];
                break;
            case GameTypes.Division:
                oper = "/";
                Result = DivisionSpecialCalc(ranNoArray);
                break;
            case GameTypes.Random:
                int randomType = random.Next(1, 5);
                switch (randomType)
                {
                    case 1:
                        oper = "+";
                        Result = ranNoArray[0] + ranNoArray[1];
                        break;
                    case 2:
                        oper = "-";
                        Result = ranNoArray[0] - ranNoArray[1];
                        break;
                    case 3:
                        oper = "*";
                        Result = ranNoArray[0] * ranNoArray[1];
                        break;
                    case 4:
                        oper = "/";
                        Result = DivisionSpecialCalc(ranNoArray);
                        break;
                }
                break;
        }
        Console.WriteLine($"{ranNoArray[0]} {oper} {ranNoArray[1]} = ");
    }

    private int DivisionSpecialCalc(int[] ranNoArray)
    {
        int result;

        while (ranNoArray[0] % ranNoArray[1] != 0)
        {
            ranNoArray = RandomNumbersArray();
        }

        result = ranNoArray[0] / ranNoArray[1];
        return result;
    }

    public bool CheckAnswer()
    {
        bool isValidInput = false;
        int userAnswer;

        do
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out userAnswer))
                isValidInput = true;
            else
            {
                Console.WriteLine("You didn't enter a number.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                Display(GameType);
            }
        } while (!isValidInput);
        Console.WriteLine();

        if (Result == userAnswer)
        {
            scoreboard.ScoreUp();
            Console.WriteLine("Correct answer!");
        }
        else
        {
            Console.WriteLine("Wrong! Correct answer is {0}", Result);
        }

        Console.WriteLine();
        return (Result == userAnswer);
    }
}