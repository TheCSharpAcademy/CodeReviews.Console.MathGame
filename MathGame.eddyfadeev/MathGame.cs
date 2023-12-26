namespace MathGame.eddyfadeev;

internal class MathGame(GameOptions gameType, int rounds, int minRange, int maxRange)
{
    private readonly Random _randomNumber = new();
    private int Score { get; set; }
    private int MinRange { get; } = minRange;
    private int MaxRange { get; } = maxRange;
    private GameOptions GameType { get; } = gameType;
    private int Rounds { get; } = rounds;
    private int CorrectAnswer { get; set; }
    private string CurrentQuestion { get; set; }
    private int UserInput { get; set; }
    private string Correctness { get; set; }

    /**
     * <summary>
     * Starts the game.
     * </summary>
     */
    public void Start()
    {
        bool lastRound = false;

        GameUtils.AddToGameHistory(GameType);
        // Loop for the number of rounds.
        for (int i = 1; i <= Rounds; i++)
        {
            // Check if it is the last round.
            if (i == Rounds) lastRound = true;

            Console.Clear();
            Console.WriteLine($"Round {i} of {Rounds}");
            Console.WriteLine($"Score: {Score}");

            AskAQuestion(GameType, MinRange, MaxRange);

            UserInput = GameUtils.GetInput(-1_000_000, 1_000_000);

            Correctness = EvaluateAnswer(UserInput) ? "Correct!" : "Incorrect!";

            string continueMessage = lastRound ? "Press any key to return to the menu..." 
                                                : "Press any key to continue to the next round...";
            Console.WriteLine(Correctness);
            Console.WriteLine(continueMessage);
            Console.ReadKey();
            GameUtils.AddToGameHistory(i, CurrentQuestion, UserInput,
                                        CorrectAnswer, Correctness, Score, lastRound);
        } // end of for loop.

        GameUtils.TotalScore += Score;
    } // end of Start method.

    /**
     * <summary>
     * Calls needed method based on the passed operation and range.
     * </summary>
     * <param name="operation">Operation to generate a question for.</param>
     * <param name="fromNumber">Lower range of the question.</param>
     * <param name="toNumber">Upper range of the question.</param>
     */
    private void AskAQuestion(GameOptions operation, int fromNumber, int toNumber)
    {
        int firstNumber = _randomNumber.Next(fromNumber, toNumber + 1),
            secondNumber = _randomNumber.Next(fromNumber, toNumber + 1);

        switch (operation)
        {
            case GameOptions.Addition:
                AdditionProblemGenerator(firstNumber, secondNumber);
                break;
            case GameOptions.Subtraction:
                SubtractionProblemGenerator(firstNumber, secondNumber);
                break;
            case GameOptions.Multiplication:
                MultiplicationProblemGenerator(firstNumber, secondNumber);
                break;
            case GameOptions.Division:
                DivisionProblemGenerator();
                break;
            case GameOptions.Random:
                RandomProblemGenerator(firstNumber, secondNumber);
                break;
        } // end of switch statement.
    } // end of AskAQuestion method.

    /**
     * <summary>
     * Generates an addition question.
     * </summary>
     * <param name="firstNum">First number of the question.</param>
     * <param name="secondNum">Second number of the question.</param>
     */
    private void AdditionProblemGenerator(int firstNum, int secondNum)
    {
        CorrectAnswer = firstNum + secondNum;
        CurrentQuestion = $"{firstNum} + {secondNum} = ? ";
        Console.Write(CurrentQuestion);
    } // end of AdditionProblemGenerator method.

    /**
     * <summary>
     * Generates a subtraction question.
     * </summary>
     * <param name="firstNum">First number of the question.</param>
     * <param name="secondNum">Second number of the question.</param>
     */
    private void SubtractionProblemGenerator(int firstNum, int secondNum)
    {
        CorrectAnswer = firstNum - secondNum;
        CurrentQuestion = $"{firstNum} - {secondNum} = ? ";
        Console.Write(CurrentQuestion);
    } // end of SubtractionProblemGenerator method.

    /**
     * <summary>
     * Generates a multiplication question.
     * </summary>
     * <param name="firstNum">First number of the question.</param>
     * <param name="secondNum">Second number of the question.</param>
     */
    private void MultiplicationProblemGenerator(int firstNum, int secondNum)
    {
        CorrectAnswer = firstNum * secondNum;
        CurrentQuestion = $"{firstNum} * {secondNum} = ? ";
        Console.Write(CurrentQuestion);
    } // end of MultiplicationProblemGenerator method.

    /**
     * <summary>
     * Generates a division question.
     * </summary>
     */
    private void DivisionProblemGenerator()
    {
        int dividend, divisor, result;

        do
        {
            // Generate a divisor that is not 0.
            divisor = _randomNumber.Next(MinRange == 0 ? 1 : MinRange, MaxRange + 1);
            // Generate a result that is in the range. 
            result = _randomNumber.Next(MinRange, MaxRange + 1);
            // Calculate dividend by multiplying divisor and result.
            // This will ensure that division will be without remainder.
            dividend = divisor * result;
            // Loop until dividend is in the range. 
        } while (dividend > MaxRange);
        // Set question to result.
        CorrectAnswer = result;
        CurrentQuestion = $"{dividend} / {divisor} = ? ";
        Console.Write(CurrentQuestion);
    } // end of DivisionProblemGenerator method.

    private void RandomProblemGenerator(int firstNum, int secondNum)
    {
        int randomOperation = _randomNumber.Next(1, 5);
        switch (randomOperation)
        {
            case 1:
                AdditionProblemGenerator(firstNum, secondNum);
                break;
            case 2:
                SubtractionProblemGenerator(firstNum, secondNum);
                break;
            case 3:
                MultiplicationProblemGenerator(firstNum, secondNum);
                break;
            case 4:
                DivisionProblemGenerator();
                break;
        } // end of switch statement.
    } // end of RandomProblemGenerator method.

    /**
     * <summary>
     * Evaluates the answer and increments the score if it is correct.
     * </summary>
     * <param name="answer">Answer to evaluate.</param>
     * <returns>True if answer is correct, false otherwise.</returns>
     */
    private bool EvaluateAnswer(int answer)
    {
        if (answer != CorrectAnswer) return false;
        Score++;
        return true;
    }// end of EvaluateAnswer method.
} // end of MathGame class.