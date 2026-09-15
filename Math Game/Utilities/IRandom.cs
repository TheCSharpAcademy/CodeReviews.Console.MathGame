using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("MathGameTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Math_Game.Tools;

internal interface IRandom
{
    public int Next(int maxValue);
}
