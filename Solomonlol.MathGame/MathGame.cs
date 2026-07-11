using System;
using System.Collections.Generic;
using System.Text;
using static STUDY.MathGame.Enums;

namespace STUDY.MathGame
{
    internal class MathGame
    {
        private Difficulty Difficulty { get; set; }
        private Operation Operation { get; set; }
        private TimeOnly StartTime { get; set; }
        public MathGame(Difficulty difficulty, Operation operation)
        {
            Difficulty = difficulty;
            Operation = operation;
            StartTime = TimeOnly.FromDateTime(DateTime.Now);
        }

        public void Game(int count)
        {
            int i = 0;
            while (i < count)
            {
                GenerateNumbers(out int first, out int second, Difficulty, Operation);
                Console.WriteLine($"{first}{(char)Operation}{second}=");
                Console.WriteLine($"Введите ответ:");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    switch (Operation)
                    {
                        case Operation.Addition:
                            {
                                if (number == (first + second))
                                {
                                    Console.WriteLine("Ответ верный!");
                                }
                                else Console.WriteLine($"Ответ неверный!\nПравильный ответ: {first + second}");
                                break;
                            }
                        case Operation.Substraction:
                            {
                                if (number == (first - second))
                                {
                                    Console.WriteLine("Ответ верный!");
                                }
                                else Console.WriteLine($"Ответ неверный!\nПравильный ответ: {first - second}");
                                break;
                            }
                        case Operation.Multiplication:
                            {
                                if (number == (first * second))
                                {
                                    Console.WriteLine("Ответ верный!");
                                }
                                else Console.WriteLine($"Ответ неверный!\nПравильный ответ: {first * second}");
                                break;
                            }
                        case Operation.Division:
                            {

                                if (number == (first / second))
                                {
                                    Console.WriteLine("Ответ верный!");
                                }
                                else Console.WriteLine($"Ответ неверный!\nПравильный ответ: {first / second}");

                                break;
                            }

                    }
                }

                else Console.WriteLine("Неверный формат ответа!");
                i++;
            }
            TimeOnly endTime = TimeOnly.FromDateTime(DateTime.Now);
            Console.WriteLine($"Вы закончили игру за {endTime - StartTime} секунд!\n" +
                $"Уровень сложности:{Difficulty}\n" +
                $"Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            
        }


        private void GenerateNumbers(out int firstNumber, out int secondNumber, Difficulty difficulty, Operation operation)
        {
            Random firstRand = new();
            int diff = (int)difficulty;
            firstNumber = firstRand.Next(diff);
            secondNumber = firstRand.Next(diff);
            if (operation == Operation.Division)
            {
                while (secondNumber == 0 || firstNumber % secondNumber != 0)
                {
                    firstNumber = firstRand.Next(diff);
                    secondNumber = firstRand.Next(diff);
                }
            }
          
        }

    }
}
