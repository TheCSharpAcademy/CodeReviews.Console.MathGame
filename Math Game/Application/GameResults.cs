using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Game.Application;

internal record GameResults
{
    public List<(int Points, double Time)> Results { get; set; } = new List<(int, double)>();
}
