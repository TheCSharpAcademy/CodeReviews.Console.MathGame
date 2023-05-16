using System;

namespace Math_Game;

internal class GameLog
{
    enum GameType
    {
        addition,
        substraction,
        multiplication,
        division,
        total_gameTypes
    }
    struct History
    {
        int m_id;
        DateTime m_date;
        GameType m_gameType;
    }

    
}
