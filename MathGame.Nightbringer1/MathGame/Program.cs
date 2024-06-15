using System.Threading.Tasks.Sources;
using static System.Formats.Asn1.AsnWriter;

namespace MathGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please type your name");

            var name = Console.ReadLine();
            var date = DateTime.UtcNow;

            void AdditionGame(string message)
            {
                Console.WriteLine($"{message}");

                var random = new Random();

                int score = 0;
                int lives = 3;

                for (int i = 0; i < 10; i++)
                {

                    int firstNumber = random.Next(1, 9);
                    int secondNumber = random.Next(1, 9);
                    Console.WriteLine($"{firstNumber} + {secondNumber}");

                    var result = Console.ReadLine();

                    if (int.Parse(result) == firstNumber + secondNumber)
                    {
                        Console.WriteLine("Your answer was correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("Your answer is incorrect");
                        lives--;
                    }

                    if (lives == 0)
                    {
                        Console.WriteLine("you are out of lives! try again!");
                        Console.WriteLine($"You scored {score}!");
                        Environment.Exit(1);
                    }
                }
                Console.WriteLine($"You scored {score}!");
            }
            void SubtractionGame(string message)
            {
                Console.WriteLine($"{message}");

                var random = new Random();

                int score = 0;
                int lives = 3;
                for (int i = 0; i < 10; i++)
                {

                    int firstNumber = random.Next(1, 9);
                    int secondNumber = random.Next(1, 9);
                    Console.WriteLine($"{firstNumber} - {secondNumber}");

                    var result = Console.ReadLine();

                    if (int.Parse(result) == firstNumber - secondNumber)
                    {
                        Console.WriteLine("Your answer was correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("Your answer is incorrect");
                        lives--;
                    }

                    if (lives == 0)
                    {
                        Console.WriteLine("you are out of lives! try again!");
                        Console.WriteLine($"You scored {score}!");
                        Environment.Exit(1);
                    }
                }
                Console.WriteLine($"You scored {score}!");
            }
            void MultiplicationGame(string message)
            {
                Console.WriteLine($"{message}");

                var random = new Random();

                int score = 0;
                int lives = 3;
                for (int i = 0; i < 10; i++)
                {

                    int firstNumber = random.Next(1, 9);
                    int secondNumber = random.Next(1, 9);
                    Console.WriteLine($"{firstNumber} * {secondNumber}");

                    var result = Console.ReadLine();

                    if (int.Parse(result) == firstNumber * secondNumber)
                    {
                        Console.WriteLine("Your answer was correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("Your answer is incorrect");
                        lives--;
                    }

                    if (lives == 0)
                    {
                        Console.WriteLine("you are out of lives! try again!");
                        Console.WriteLine($"You scored {score}!");
                        Environment.Exit(1);
                    }
                }
                Console.WriteLine($"You scored {score}!");
            }
            void DivisionGame(string message)
            {
                int score = 0;
                int lives = 3;
                for (int i =0; i < 10; i++)
                { 
                    var divisionNumbers = GetDivisionNumbers();
                    var firstNumber = divisionNumbers[0];
                    var secondNumber = divisionNumbers[1];

                    Console.WriteLine($"{firstNumber} / {secondNumber}");
                    var result = Console.ReadLine();

                    if (int.Parse(result) == firstNumber / secondNumber)
                    {
                        Console.WriteLine("Your answer was correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("Your answer is incorrect");
                        lives--;
                    }

                    if (lives == 0)
                    {
                        Console.WriteLine("you are out of lives! try again!");
                        Console.WriteLine($"You scored {score}!");
                        Environment.Exit(1);
                    }
                }
                Console.WriteLine($"You scored {score}!");
            }
            int[] GetDivisionNumbers()
            {
                var random = new Random();

                var firstNumber = random.Next(1, 99);
                int secondNumber = random.Next(1, 99);

                var result = new int[2];

                

                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = random.Next(1, 99);
                    secondNumber = random.Next(1, 99);
                }
                
                result[0] = firstNumber;
                result[1] = secondNumber;


                return result;
            }
        } 
    }
}
