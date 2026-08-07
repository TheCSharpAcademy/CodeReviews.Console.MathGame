using System.Diagnostics;
List<GameRunRecording> runHistory = new List<GameRunRecording>();

GameStart();

void GameStart() // Main menu method to display an offer to the player to choose a language before continuing onto the game itself
{
    while (true)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to Numheroes!\n¡Bienvenido a Numheroes!");
        Console.ResetColor();
        Console.WriteLine("\nSelect your language:\nSelecciona tu idioma:\n");
        Console.WriteLine("\t1. 🇬🇧 English/Inglés\n\t2. 🇪🇸 Spanish/Español\n\t3. Exit/Salir");


        string? startupChoice = Console.ReadLine();

        switch (startupChoice)
        {
            case "1":
                Text.LoadEnglish();
                GameMenu();
                return;
            case "2":
                Text.LoadSpanish();
                GameMenu();
                return;
            case "3":
                Console.WriteLine("See you later!\n¡Nos vemos!");
                return;
            default:
                for (int i = 3; i > 0; i--) // inform the user that the input was not valid, prompts for correct input
                {
                    Console.Write($"\rInvalid selection. Try again in {i}...\tOpción incorrecta. Intenta de nuevo en {i}...");
                    Thread.Sleep(1000);
                }
                GameStart();
                return;
        }
    }
}

void GameMenu() // Actual main menu for the game, localized to one of the two language options
{
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("===  NUMHEROES === ");
    Console.ResetColor();

    Console.WriteLine(Text.MainMenu);
    Console.WriteLine($"\t1. {Text.EasyDifficulty}");
    Console.WriteLine($"\t2. {Text.HardDifficulty}");
    Console.WriteLine($"\t3. {Text.ChooseOperation}");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine($"\t\t{Text.OperationExplanation}");
    Console.ResetColor();
    Console.WriteLine($"\t4. {Text.PastResults}");
    Console.WriteLine($"\t5. {Text.MainExit}");

    string? gameMenuChoice = Console.ReadLine();

    switch (gameMenuChoice)
    {
        case "1":
            FiveQuestionsMode(false); // 'false' defaults to EASY mode
            break;
        case "2":
            FiveQuestionsMode(true); // 'true' switches to HARD mode
            break;
        case "3":
            PlayByOperation(); // displays a submenu for choosing specific operations to play through, all defaulting to Easy mode
            break;
        case "4":
            PastScores(); // shows a poorly formatted readout of the score for the past 10 runs
            break;
        default: // displays a goodbye message and closes the application with no confirmation
            Console.WriteLine(Text.OutMessage);
            Thread.Sleep(1500);
            return;

    }
}

void PlayByOperation()  // menu to select an operation and pass that choice along to both GameLoop and the FinishedOperationRunOptions menu display method
                        // FinishedOperationRunOptions should probably be merged with FinishedRunOptions, but I couldn't get it working without messing it up
{
    Console.WriteLine(Text.ChooseOperation);
    Console.WriteLine($"\t1. {Text.AdditionMode}");
    Console.WriteLine($"\t2. {Text.SubtractionMode}");
    Console.WriteLine($"\t3. {Text.MultiplicationMode}");
    Console.WriteLine($"\t4. {Text.DivisionMode}");

    string? selectedOperation = Console.ReadLine();

    List<Func<Question>> operationGenerators = selectedOperation switch
    {
        "1" => new List<Func<Question>> { QuestionGenerator.EasyAddition },
        "2" => new List<Func<Question>> { QuestionGenerator.EasySubtraction },
        "3" => new List<Func<Question>> { QuestionGenerator.EasyMultiplication },
        "4" => new List<Func<Question>> { QuestionGenerator.EasyDivision },
        _ => new List<Func<Question>> { QuestionGenerator.EasyAddition } // fallback, revisit later, should maybe add a message prompting the user to make a valid selection
    };

    string modeLabel = selectedOperation switch
    {
        "1" => Text.AdditionModeLabel,
        "2" => Text.SubtractionModeLabel,
        "3" => Text.MultiplicationModeLabel,
        "4" => Text.DivisionModeLabel,
        _ => "Addition"
    };

    GameLoop(operationGenerators, modeLabel);
    FinishedOperationRunOptions(operationGenerators, modeLabel);
}

void FiveQuestionsMode(bool selectedDifficulty)
{
    List<Func<Question>> generators = selectedDifficulty
    ? new List<Func<Question>> { QuestionGenerator.HardAddition, QuestionGenerator.HardSubtraction, QuestionGenerator.HardMultiplication, QuestionGenerator.HardDivision }
    : new List<Func<Question>> { QuestionGenerator.EasyAddition, QuestionGenerator.EasySubtraction, QuestionGenerator.EasyMultiplication, QuestionGenerator.EasyDivision };

    GameLoop(generators, selectedDifficulty ? Text.EasyModeLabel : Text.HardModeLabel);

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"\n\t1. {Text.Replay}");
    Console.WriteLine($"\t2. {Text.SwitchItUp}");
    Console.WriteLine($"\t3. {Text.BackToMenu}");
    Console.WriteLine($"\t4. {Text.MainExit}");
    Console.ResetColor();

    string? finishedGameChoice = Console.ReadLine();
    FinishedRunOptions(selectedDifficulty, finishedGameChoice);
}

void RoundStats(int correctAnswers, int bestStreak, int finalTime)
{
    if (correctAnswers >= 3)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n{string.Format(Text.CorrectAnswers, correctAnswers)}");
        Console.WriteLine($"{string.Format(Text.Streak, bestStreak)}");
        Console.WriteLine($"{string.Format(Text.Time, finalTime)}");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n{string.Format(Text.CorrectAnswers, correctAnswers)}");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{string.Format(Text.Streak, bestStreak)}");
        Console.ResetColor();
        Console.WriteLine($"{string.Format(Text.Time, finalTime)}");
    }
}

void FinishedRunOptions(bool selectedDifficulty, string? finishedGameChoice)
{
    switch (finishedGameChoice)
    {
        case "1":
            FiveQuestionsMode(selectedDifficulty);
            break;

        case "2":
            FiveQuestionsMode(!selectedDifficulty);
            break;
        case "3":
            GameMenu();
            break;
        default:
            Console.WriteLine(Text.OutMessage);
            Thread.Sleep(1500);
            return;

    }
}

void FinishedOperationRunOptions(List<Func<Question>> operationGenerators, string modeLabel) // displays a menu after finishing a Specific Operation run
{
    Console.WriteLine($"\n\t1. {Text.Replay}");
    Console.WriteLine($"\t2. {Text.BackToMenu}");
    Console.WriteLine($"\t3. {Text.MainExit}");

    string? userSelection = Console.ReadLine();

    switch (userSelection)
    {
        case "1":
            GameLoop(operationGenerators, modeLabel);
            FinishedOperationRunOptions(operationGenerators, modeLabel);
            break;
        case "2":
            GameMenu();
            break;
        default:
            Console.WriteLine(Text.OutMessage);
            Thread.Sleep(1500);
            return;

    }
}

void PastScores() // displays a list of up to ten runs (oldest one gets overwritten), could probably be renamed
{
    Console.Clear();

    if (runHistory.Count == 0)
    {
        Console.WriteLine(Text.NoResultsYet);
    }
    else
    {
        foreach (var run in runHistory)
        {
            Console.WriteLine(run.ToString());
        }
    }

    Console.WriteLine($"\n{Text.PressAnyKey}");
    Console.ReadKey();
    GameMenu();
}

void GameLoop(List<Func<Question>> generators, string modeLabel)    // main gameplay loop, generates the five questions based on the selected game mode
                                                                    // outputs all pertinent information to display on PastScores() and calculate the point total
{
    Console.WriteLine($"{Text.SolveThis}\n");
    Stopwatch timeElapsed = Stopwatch.StartNew();

    int correctAnswers = 0;
    int currentStreak = 0;
    int bestStreak = 0;

    for (int i = 1; i <= 5; i++)
    {
        int index = Random.Shared.Next(generators.Count);
        Question question = generators[index]();

        Console.WriteLine($"{Text.Question} {i}/5");
        Console.WriteLine($"{question.FirstNumber} {question.Operator} {question.SecondNumber} = ?");

        string? input = Console.ReadLine();

        if (int.TryParse(input, out int userAnswer))
        {
            if (userAnswer == question.CorrectAnswer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{Text.Correct}\n");
                Console.ResetColor();
                correctAnswers++;
                currentStreak++;

                if (currentStreak > bestStreak)
                    bestStreak = currentStreak;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Text.Wrong}\n");
                Console.ResetColor();
                currentStreak = 0;
            }
        }
        else
        {
            Console.WriteLine(Text.StopThat);
        }

        Console.WriteLine();
    }

    timeElapsed.Stop();
    int finalTime = (int)Math.Round(timeElapsed.Elapsed.TotalSeconds);

    RoundStats(correctAnswers, bestStreak, finalTime);
    int score = CalculateScore(correctAnswers, bestStreak, finalTime);

    int CalculateScore(int correctAnswers, int bestStreak, int finalTime)
    {
        int correctAnswersScore = correctAnswers;
        int streakScore = bestStreak;

        int timeScore;
        if (correctAnswers == 0)
            timeScore = 0;
        else if (finalTime < 30)
            timeScore = 5;
        else if (finalTime < 60)
            timeScore = 3;
        else if (finalTime < 90)
            timeScore = 1;
        else
            timeScore = 0;

        return correctAnswersScore + streakScore + timeScore;
    }

    runHistory.Add(new GameRunRecording
    {
        GamePlayMode = modeLabel,
        FinalTime = finalTime,
        CorrectAnswers = correctAnswers,
        BestStreak = bestStreak,
        Score = score
    });

    if (runHistory.Count > 10)
        runHistory.RemoveAt(0);
}