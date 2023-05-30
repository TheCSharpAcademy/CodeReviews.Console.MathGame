class SolutionChecker
{
    public void CheckSolution(int num1, string operatorSymbol, int num2, int userSolution)
    {
        int tries = 3;

        switch (operatorSymbol)
        {
            case "+":
                int computerSolutionAdd = num1 + num2;

                if (userSolution == computerSolutionAdd)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCorrect! Great Job! Next Question Incoming!");
                    PreviousHistory.AddHistory(num1, operatorSymbol, num2, computerSolutionAdd,true);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine(
                        "Incorrect!\n" +
                        "Computer Solution: " + computerSolutionAdd + "\n" +
                        "Your Solution: " + userSolution + "\n" +
                        "Next Question Incoming!\n"
                    );
                    PreviousHistory.AddHistory(num1, operatorSymbol, num2, computerSolutionAdd, false);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                break;

            case "-":
                int computerSolutionSub = num1 - num2;

                if (userSolution == computerSolutionSub)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCorrect! Great Job! Next Question Incoming!\n");
                    PreviousHistory.AddHistory(num1, operatorSymbol, num2, computerSolutionSub, true);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        "Incorrect!\n" +
                        "Computer Solution: " + computerSolutionSub + "\n" +
                        "Your Solution: " + userSolution + "\n" +
                        "Next Question Incoming!\n"
                    );
                    PreviousHistory.AddHistory(num1, operatorSymbol, num2, computerSolutionSub, false);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                break;

            case "*":
                int computerSolutionMult = num1 * num2;

                if (userSolution == computerSolutionMult)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCorrect! Great Job! Next Question Incoming!\n");
                    PreviousHistory.AddHistory(num1, operatorSymbol, num2, computerSolutionMult, true);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        "Incorrect!\n" +
                        "Computer Solution: " + computerSolutionMult + "\n" +
                        "Your Solution: " + userSolution + "\n" +
                        "Next Question Incoming!\n"
                    );
                    PreviousHistory.AddHistory(num1, operatorSymbol, num2, computerSolutionMult, false);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                break;

            case "/":
                int computerSolutionDiv = num1 / num2;

                if (userSolution == computerSolutionDiv)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCorrect! Great Job! Next Question Incoming!\n");
                    PreviousHistory.AddHistory(num1, operatorSymbol, num2, computerSolutionDiv, true);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        "Incorrect!\n" +
                        "Computer Solution: " + computerSolutionDiv + "\n" +
                        "Your Solution: " + userSolution + "\n" +
                        "Next Question Incoming!\n"
                    );
                    PreviousHistory.AddHistory(num1, operatorSymbol, num2, computerSolutionDiv, false);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    "Invalid Operation Checking Solution. Restarting Solution Checker. " +
                    "If This Problem Persists, Then Contact Support At: " +
                    "https://github.com/mekasu0124/MeksMathGame/issues"
                );

                Thread.Sleep(2000);

                tries--;

                if (tries > 0)
                {
                    CheckSolution(num1, operatorSymbol, num2, userSolution);
                }
                else
                {
                    Environment.Exit(0);
                };
                break;
        }
    }
}