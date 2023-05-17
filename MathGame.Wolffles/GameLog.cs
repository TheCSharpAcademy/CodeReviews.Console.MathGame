using System;

namespace Math_Game;

internal class GameLog
{
    private static List<History> list = new List<History>();
    static int m_logIndex = 1;

    internal enum GameType
    {
        Addition,
        Substraction,
        Multiplication,
        Division,
        total_gameTypes
    }

    internal struct History
    {
        internal int m_index;
        internal GameType m_typeS;
        internal int m_score;
        internal DateTime m_time;

        internal History(GameType type, int score)
        {
            m_time = DateTime.Now;
            m_index = m_logIndex;
            m_typeS = type;
            m_score = score;
            ++m_logIndex;
        }      
    }
  
    public void LogEntry(char operand,int score)
    {
        GameType type = new GameType();
        switch (operand)
        {
            case '-':
                type = GameType.Substraction;
                break;
            case '+':
                type = GameType.Substraction;
                break;
            case '*':
                type = GameType.Substraction;
                break;
            case '/':
                type = GameType.Substraction;
                break;
        }
        History entry = new History(type, score);      
        list.Add(entry);
    }
    
    public void ReadLog()
    {
        Console.Clear();
        foreach (History game in list)
        {
            Console.WriteLine($"Game#{game.m_index} Date/Time: {game.m_time} Type:{game.m_typeS} Score: {game.m_score} \n");
        }
        Console.WriteLine("Press any key to return to menu");
        Console.ReadKey();
        Console.Clear();
    }

    
}
