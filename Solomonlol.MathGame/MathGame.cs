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
            int totalScore=0, i = 0;
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
                                    totalScore++;
                                }
                                else Console.WriteLine($"Ответ неверный!\nПравильный ответ: {first + second}");
                                i++;
                                break;
                            }
                        case Operation.Substraction:
                            {
                                if (number == (first - second))
                                {
                                    Console.WriteLine("Ответ верный!");
                                    totalScore++;
                                }
                                else Console.WriteLine($"Ответ неверный!\nПравильный ответ: {first - second}");
                                i++;
                                break;
                            }
                        case Operation.Multiplication:
                            {
                                if (number == (first * second))
                                {
                                    Console.WriteLine("Ответ верный!");
                                    totalScore++;
                                }
                                else Console.WriteLine($"Ответ неверный!\nПравильный ответ: {first * second}");
                                i++;
                                break;
                            }
                        case Operation.Division:
                            {

                                if (number == (first / second))
                                {
                                    Console.WriteLine("Ответ верный!");
                                    totalScore++;
                                }
                                else Console.WriteLine($"Ответ неверный!\nПравильный ответ: {first / second}");
                                i++;
                                break;
                            }

                    }
                }

                else Console.WriteLine("Неверный формат ответа!");
                
            }
            TimeOnly endTime = TimeOnly.FromDateTime(DateTime.Now);
            Console.WriteLine($"Вы закончили игру за {endTime - StartTime} секунд!\n" +
                $"Уровень сложности:{Difficulty}\n" +
                $"Ваш счет: {totalScore} из {count}\n" +
                $"Нажмите любую клавишу для продолжения.");
            SaveResults(Operation, totalScore, count);
            Console.ReadKey();
            
        }

        private void SaveResults(Operation operation, int gameScore, int totalScore)
        {
            GameResults game = new(operation, gameScore, totalScore);
            GameList.Add(game);
        }
        private void GenerateNumbers(out int firstNumber, out int secondNumber, Difficulty difficulty, Operation operation)
        {
            Random firstRand = new();
            firstNumber = firstRand.Next((int)difficulty);
            secondNumber = firstRand.Next((int)difficulty);
            if (operation == Operation.Division)
            {
                while (secondNumber == 0 || firstNumber % secondNumber != 0)
                {
                    firstNumber = firstRand.Next((int)difficulty);
                    secondNumber = firstRand.Next((int)difficulty);
                }
            }
          
        }

    }
}
