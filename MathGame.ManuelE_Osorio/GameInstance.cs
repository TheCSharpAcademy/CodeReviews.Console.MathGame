using System;

namespace MathGame.ManuelE_Osorio;
public class GameInstance
{
    public int DifficultyLevel;
    public int NumberOfQuestions;
    public int[] Operations;
    public int StartTime;
    public int FinishTime;
    public int[] Results;
    public int[] Operators;

    public GameInstance(int difficultyLevel, int numberOfQuestions, int[] operations, int[] operators) 
    {
        DifficultyLevel = difficultyLevel;
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

    public void UpdateStartTime(int startTime)
    {
        StartTime = startTime;
    }

    public void UpdateFinishTime(int finishTime)
    {
        FinishTime = finishTime;
    }

    public string SendRecords()
    {

        return Convert.ToString(DifficultyLevel);
    }

}