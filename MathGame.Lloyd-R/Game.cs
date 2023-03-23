using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MathGame
{
    public class Game
    {
        public static void RandomGame()
        {
            int score = 0;
            int lives = 3;
            int questionNumber = 1;
            int answer;
            int correctAnswer;
            int randomOperation;
            int randomNum1;
            int randomNum2;
            Random random = new Random();
            while (lives > 0)
                while (lives > 0)
                {
                    randomOperation = random.Next(1, 5);
                    randomNum1 = random.Next(1, 11);
                    randomNum2 = random.Next(1, 11);
                    switch (randomOperation)
                    {
                        case 1:
                            Console.WriteLine("Question {0}: {1} + {2} = ?", questionNumber, randomNum1, randomNum2);
                            correctAnswer = randomNum1 + randomNum2;
                            break;
                        case 2:
                            Console.WriteLine("Question {0}: {1} - {2} = ?", questionNumber, randomNum1, randomNum2);
                            correctAnswer = randomNum1 - randomNum2;
                            break;
                        case 3:
                            Console.WriteLine("Question {0}: {1} * {2} = ?", questionNumber, randomNum1, randomNum2);
                            correctAnswer = randomNum1 * randomNum2;
                            break;
                        case 4:
                            Console.WriteLine("Question {0}: {1} / {2} = ?", questionNumber, randomNum1, randomNum2);
                            correctAnswer = randomNum1 / randomNum2;
                            break;
                        default:
                            correctAnswer = 0;
                            break;
                    }
                    answer = Convert.ToInt32(Console.ReadLine());
                    if (answer == correctAnswer)
                    {
                        Console.WriteLine("Correct!");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect!");
                        lives--;
                    }
                    questionNumber++;
                }
            Console.WriteLine("Game Over! Your score is {0}", score);
        }
    }
}
