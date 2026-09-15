using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Game.Tools;

internal class RandomWrapper : IRandom
{
    private readonly Random _random;
    public RandomWrapper(Random random)
    {
        _random = random;
    }
    public int Next(int maxValue) => _random.Next(maxValue);

}
