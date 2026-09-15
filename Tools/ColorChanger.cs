using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class ColorChanger
    {
        public static void ChangeText(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        public static void ChangeBackground(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }
        public static void Reset()
        {
            Console.ResetColor();
        }
        public static void WriteColored(ConsoleColor color, string message)
        {
            ChangeText(color);
            Console.WriteLine(message);
            Reset();
        }
    }
}
