using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace STUDY.MathGame
{
    internal static class GameList
    {
        private static List<GameResults> resultsList = new List<GameResults>();

        public static void Add(GameResults result)
        {
            resultsList.Add(result);
        }

        public static void Show()
        {
            if (resultsList.Count>0)
            {
                foreach (GameResults result in resultsList)
                {
                    result.Display();
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Нет записей для вывода.\nНажмите любую клавишу для продолжения.");
                Console.ReadKey();
            }
        }
    }
}
