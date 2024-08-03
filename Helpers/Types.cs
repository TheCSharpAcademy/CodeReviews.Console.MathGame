using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Math_Game.Helpers
{
    internal enum Types
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    internal static class TypesMethod
    {
        internal static Types GetType(string? type)
        {
            switch (type)
            {
                case "A":
                    return Types.Addition;
                    
                case "S":
                    return Types.Subtraction;
                    
                case "M":
                    return Types.Multiplication;
                    
                case "D":
                    return Types.Division;
                    
                default:
                    return default;
                    
            }
        }
    }
}
