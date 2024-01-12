namespace MathGame;

sealed class MainActivity {
    private static List<Round> _playedRounds = new();

    static void Main() {
        while (true) {
            Console.Clear();
            UiLoop();

            string? input;
            var parsedInput = -1;
            var isValidInput = false;
            while (!isValidInput) {
                input = Console.ReadLine();
                isValidInput = input != null && int.TryParse(input, out parsedInput) || parsedInput == -1 ||
                               parsedInput > 3;
            }

            switch (parsedInput) {
                case 1: {
                    Console.Clear();
                    // ReSharper disable once EmptyEmbeddedStatement
                    while (ChallengePlayer()) ;
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                }
                case 2: {
                    Console.Clear();
                    Console.WriteLine("============================ Game     Rounds. ============================");
                    for (var i = 0; i < _playedRounds.Count; i++) {
                        var gameNumber = i + 1; // +1 for user friendly stuffs.
                        var round = _playedRounds[i];

                        Console.WriteLine("========================================================");
                        Console.WriteLine($" * Round number     -> {gameNumber}");
                        Console.WriteLine($" * Operation        -> {round.PlayedOperation.GetOperationName()}");
                        Console.WriteLine($" * Left Operator    -> {round.LeftOperand}");
                        Console.WriteLine($" * Right Operator   -> {round.RightOperand}");
                        Console.WriteLine($" * Did you win?     -> {(round.Won ? "Yes" : "No")}");
                        Console.WriteLine(
                            $" * Operation Render -> {round.PlayedOperation.RenderAsText(round.LeftOperand, round.RightOperand)}");
                        Console.WriteLine("========================================================");
                    }

                    Console.WriteLine("============================ End Game Rounds. ============================");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                }
                case 3: {
                    Environment.ExitCode = 0;
                    return;
                }
            }
        }
    }

    private static bool ChallengePlayer() {
        //  Behavior note:
        //      - True == Player Won. | False == Player lost, idiot.


        var operation = AskForOperation();

        if (operation == null) {
            return false; // Go back option.
        }

        var leftNumber = Random.Shared.Next(1, 100);
        var rightNumber = Random.Shared.Next(1, 100);

        if (operation is Division) {
            //  NOTE: To avoid 0/0 conditions, the min num must be 1, NOT 0.
            // Apply the extra rule.
            // All divisions must result on an integer. Meaning the module between L and R must be zero.

            while (leftNumber % rightNumber != 0) { // Gamble till you make it.
                leftNumber = Random.Shared.Next(1, 101);
                rightNumber = Random.Shared.Next(1, 101);
            }
        }

        var result = operation.Operate(leftNumber, rightNumber);

        Console.WriteLine($"Operation -> {operation.RenderAsText(leftNumber, rightNumber)}");
        Console.Write("Please submit your answer: ");
        var unparsedInput = Console.ReadLine();
        var didPlayerWon = false;
        var userNum = int.MinValue;
        if (unparsedInput == null) {
            Console.WriteLine("Wrong.");
            goto Register_Game;
        }

        if (!int.TryParse(unparsedInput, out userNum)) {
            Console.WriteLine("Wrong.");
            goto Register_Game;
        }

        if (userNum == result) {
            Console.WriteLine("That is correct.");
            didPlayerWon = true;
        }

        Register_Game:
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        _playedRounds.Add(
            new Round {
                PlayedOperation = operation,
                LeftOperand = leftNumber,
                RightOperand = rightNumber,
                ComputedResult = result,
                Won = didPlayerWon,
            });
        return didPlayerWon;
    }


    private static IOperation? AskForOperation() {
        Console.Clear();
        Console.WriteLine("Choose an operation to play:");
        Console.WriteLine("\t 1: Division");
        Console.WriteLine("\t 2: Substraction");
        Console.WriteLine("\t 3: Multiplication");
        Console.WriteLine("\t 4: Sum");
        Console.WriteLine("\t 5: Go back");

        var x = Console.ReadLine();
        if (!int.TryParse(x, out var num))
            return null; // Shut the compiler (lol)

        return num switch {
            // Boxing my beloved.
            1 => new Division(),
            2 => new Substraction(),
            3 => new Multiplication(),
            4 => new Sum(),
            _ => null
        };
    }

    static void UiLoop() {
        Console.Clear();
        Console.WriteLine("\t=============");
        Console.WriteLine("\t= Math game =");
        Console.WriteLine("\t=============");
        Console.WriteLine("Available options: ");
        Console.WriteLine("1: Start");
        Console.WriteLine("2: See previous games");
        Console.WriteLine("3: Exit");
    }
}