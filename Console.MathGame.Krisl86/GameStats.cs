using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KristianLepka.MathGame;
class GameStats
{
    readonly List<MathGame> stats = new();
    public ReadOnlyCollection<MathGame> Stats => stats.AsReadOnly();
    
    public void Add(MathGame game) 
        => stats.Add(game);
}
