using System.Diagnostics;

namespace mathGame.bkohler93;

public class MathGame
{
    private Stopwatch watch = new();
    private int MaxNumber = 10; //easy mode has 10 questions
    private readonly int EasyModeNumberOfQuestions = 10;
    private readonly int MediumModeNumberOfQuestions = 50;
    private readonly int HardModeNumberOfQuestions = 100;
    private int GameTimeSeconds;
    private int NumberOfQuestions = 5;
    private int NumberOfQuestionsCorrect;
    private readonly Random random = new();
    private List<String> problemHistory = [];
    public void PlayRandomSelection()
    {
        watch.Start();
        while (true)
        {
            int numA = random.Next(MaxNumber);
            int numB = random.Next(MaxNumber);
            int solution = 0;
            string question = "";

            switch (random.Next(4))
            {
                case 0: //addition
                    solution = numA + numB;
                    question = $"{numA} + {numB} = ?";
                    break;
                case 1: //subtraction
                    solution = numA - numB;
                    question = $"{numA} - {numB} = ?";
                    break;
                case 2: //multiplication
                    solution = numA * numB;
                    question = $"{numA} * {numB} = ?";
                    break;
                case 3: //division
                    while (numB == 0 || numA % numB != 0)
                    {
                        numA = random.Next(MaxNumber);
                        numB = random.Next(MaxNumber);
                    }

                    solution = numA / numB;
                    question = $"{numA} / {numB} = ?";
                    break;
            }

            // ask question - get answer
            int userSolution = UI.GetIntSelection(question);

            // add solution to problemHistory
            string problemResult = question.Replace("?", userSolution.ToString()).PadRight(20);
            if (userSolution == solution)
            {
                NumberOfQuestionsCorrect++;
                problemResult += " - Correct";
            }
            else
            {
                problemResult += " - Incorrect";
            }

            problemHistory.Add(problemResult);

            if (NumberOfQuestionsCorrect == NumberOfQuestions)
            {
                break;
            }
        }
        watch.Stop();
        GameTimeSeconds = (int)(watch.ElapsedMilliseconds / 1000);
        UI.DisplayConfirmation($"Completed in {GameTimeSeconds} seconds");
    }

    public void PlaySelfSelection()
    {
        watch.Start();
        while (true)
        {
            int numA = random.Next(MaxNumber);
            int numB = random.Next(MaxNumber);
            int solution = 0;
            string question = "";

            int userSelection = UI.MenuSelection("Choose an operation:", ["Addition", "Subtraction", "Multiplication", "Division"]);

            switch (userSelection)
            {
                case 1: //addition
                    solution = numA + numB;
                    question = $"{numA} + {numB} = ?";
                    break;
                case 2: //subtraction
                    solution = numA - numB;
                    question = $"{numA} - {numB} = ?";
                    break;
                case 3: //multiplication
                    solution = numA * numB;
                    question = $"{numA} * {numB} = ?";
                    break;
                case 4: //division
                    while (numB == 0 || numA % numB != 0)
                    {
                        numA = random.Next(MaxNumber);
                        numB = random.Next(MaxNumber);
                    }

                    solution = numA / numB;
                    question = $"{numA} / {numB} = ?";
                    break;
            }

            int userSolution = UI.GetIntSelection(question);

            string problemResult = question.Replace("?", userSolution.ToString()).PadRight(20);
            if (userSolution == solution)
            {
                NumberOfQuestionsCorrect++;
                problemResult += " - Correct";
            }
            else
            {
                problemResult += " - Incorrect";
            }

            problemHistory.Add(problemResult);

            if (NumberOfQuestionsCorrect == NumberOfQuestions)
            {
                break;
            }
        }
        watch.Stop();
        GameTimeSeconds = (int)(watch.ElapsedMilliseconds / 1000);
        UI.DisplayConfirmation($"Completed in {GameTimeSeconds} seconds");
    }
    public void ConfigureGame()
    {
        int selection = UI.MenuSelection("Select game difficulty:", ["Easy", "Medium", "Hard"]);
        MaxNumber = selection switch
        {
            1 => EasyModeNumberOfQuestions,
            2 => MediumModeNumberOfQuestions,
            3 => HardModeNumberOfQuestions,
            _ => throw new Exception("Invalid selection")
        };

        NumberOfQuestions = UI.GetIntSelection("Set a number of questions to answer in game: ", minValue: 1);

        UI.DisplayConfirmation("Game configured");
    }

    public override string ToString()
    {
        string gameDifficulty = MaxNumber switch
        {
            10 => "Easy",
            50 => "Medium",
            100 => "Hard",
            _ => "", //unreachable
        };

        string gameString = $"{gameDifficulty} Game - {GameTimeSeconds} seconds - {NumberOfQuestions} Points to win";

        foreach (var problem in problemHistory)
        {
            gameString += "\n\t" + problem;
        }

        return gameString;
    }

    public void Reset()
    {
        problemHistory = [];
        NumberOfQuestionsCorrect = 0;
        GameTimeSeconds = 0;
        watch.Reset();
    }
}
