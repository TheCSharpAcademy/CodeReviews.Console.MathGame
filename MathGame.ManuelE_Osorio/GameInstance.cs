namespace MathGame.ManuelE_Osorio;

public class GameInstance
{
    public int DifficultyLevel;
    public int GameType;
    public int NumberOfQuestions;
    public int[] Operations;
    public long StartTime {get; set;}
    public long FinishTime {get; set;}
    public int[] Results;
    public int[] Operators;

    public GameInstance(int difficultyLevel, int numberOfQuestions, int[] operations, int[] operators, int gameType) 
    {
        DifficultyLevel = difficultyLevel;
        GameType = gameType;
        NumberOfQuestions = numberOfQuestions;
        StartTime = 0;
        FinishTime = 0;
        Operators = operators;
        Operations = operations;
        Results = new int[numberOfQuestions];
        for(int i=0; i<Operations.Length; i++)
        {
            switch(Operations[i])
            {
                case(1):
                    Results[i]=Operators[i*2]+Operators[i*2+1];
                    break;
                case(2):
                    Results[i]=Operators[i*2]-Operators[i*2+1];
                    break;
                case(3):
                    Results[i]=Operators[i*2]*Operators[i*2+1];
                    break;
                case(4):
                    Results[i]=Operators[i*2]/Operators[i*2+1];
                    break;
            }
        }   
    }
    
    public string SendRecords()
    {
        string DifficultyLevelString = "";
        string ElapsedTime = String.Format("{0:0}",(FinishTime - StartTime)/1000);
        string GameTypeString = "";

        switch(DifficultyLevel)
        {
            case(1):
                DifficultyLevelString = "Easy";
                break;
            case(2):
                DifficultyLevelString = "Medium";
                break;
            case(3):
                DifficultyLevelString = "Hard";
                break;
        }

        switch(GameType)
        {
            case(1):
                GameTypeString = "Addition";
                break;
            case(2):
                GameTypeString = "Subtraction";
                break;
            case(3):
                GameTypeString = "Multiplication";
                break;
            case(4):
                GameTypeString = "Division";
                break;
            case(5):
                GameTypeString = "Random Operation";
                break;
        }

        string Records = $"Difficulty Level: {DifficultyLevelString}" +
        $", Number of Questions: {NumberOfQuestions}" +
        $", Game Type: {GameTypeString}" +
        $", Elapsed Time: {ElapsedTime}s";

        return Records;   
    }
}