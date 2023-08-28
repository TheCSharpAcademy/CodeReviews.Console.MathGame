using System.IO;
using System.Collections;

// See https://aka.ms/new-console-template for more information
// You need to create a Math game containing the 4 basic operations
//The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
//Users should be presented with a menu to choose an operation
//You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.
//You don't need to record results on a database. Once the program is closed the results will be deleted.

namespace MathGame
{
    public class Game
    {
        int goodAnswers = 0;
        int questions = 0;
        ArrayList questionsList = new ArrayList();
        public char mainMenu() //function is returning upper case char and this means selection of type of challange.
        {
            char playerChoice = ' ';
            Console.WriteLine("=========================");
            Console.WriteLine($"Questions asked: {questions}   correct answers: {goodAnswers}");
            Console.WriteLine("Welcome to the Math Game!");
            Console.WriteLine("Please chose what kind of math problem would you like to solve:\n");
            Console.WriteLine("A. Addition");
            Console.WriteLine("B. Substraction");
            Console.WriteLine("C. Multiplication");
            Console.WriteLine("D. Division");
            Console.WriteLine("E. Random problem\n");
            Console.WriteLine("H. Show games log");
            Console.WriteLine("X. Exit");
            Console.WriteLine($"\nYour choice: ");
            string input = Console.ReadLine()!;
            try
            {
                playerChoice = char.Parse(input);
                playerChoice = char.ToUpper(playerChoice);
            }
            catch (Exception e) 
            {
                Console.WriteLine($"Please enter correct letter.");
            }
            return playerChoice;
        }

        public void showGamesHistory()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Games History:");
            foreach(var item in  questionsList) 
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }

        public void additionChallange()
        {
            questions++;
            int a, b;
            Random rng = new Random();
            a = rng.Next(10);
            b = rng.Next(10);
            Console.WriteLine("========================");
            string question = $"{a} + {b} = ?";
            questionsList.Add(question);
            Console.WriteLine($"Yor question is:\n{question}\nYour answer:");
            for (int i = 0; i < 3; i++) 
            {
                string input = Console.ReadLine()!;
                int answerNum = 0;
                try
                {
                    answerNum = int.Parse(input);
                    if (answerNum == (a + b))
                    {
                        Console.WriteLine($"Correct!\n{a} + {b} = {a + b}!");
                        questionsList.Add($"Correct answer ({answerNum})");
                        goodAnswers++;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not correct, please try again!");
                        questionsList.Add($"Wrong answer ({answerNum})");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"{e.Message}");
                    Console.WriteLine("Not correct, please try again!");
                    questionsList.Add($"Wrong answer (wrong input ex. character instead of number)");
                }
            }
        }

        public void multiplicationChallange()
        {
            questions++;
            int a, b;
            Random rng = new Random();
            a = rng.Next(10);
            b = rng.Next(10);
            Console.WriteLine("========================");
            string question = $"{a} * {b} = ?";
            questionsList.Add(question);
            Console.WriteLine($"Yor question is:\n{question}\nYour answer:");
            for (int i = 0; i < 3; i++)
            {
                string input = Console.ReadLine()!;
                int answerNum = 0;
                try
                {
                    answerNum = int.Parse(input);
                    if (answerNum == (a * b))
                    {
                        Console.WriteLine($"Correct!\n{a} * {b} = {a * b}!");
                        questionsList.Add($"Correct answer ({answerNum})");
                        goodAnswers++;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not correct, please try again!");
                        questionsList.Add($"Wrong answer ({answerNum})");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"{e.Message}");
                    Console.WriteLine("Not correct, please try again!");
                    questionsList.Add($"Wrong answer (wrong input ex. character instead of number)");
                }
            }
        }

        public void substractionChallange()
        {
            questions++;
            int a = 0, b = 1;
            do
            {
                Random rng = new Random();
                a = rng.Next(10);
                b = rng.Next(10);
            } while (a < b);
            Console.WriteLine("========================");
            string question = $"{a} - {b} = ?";
            questionsList.Add(question);
            Console.WriteLine($"Yor question is:\n{question}\nYour answer:");
            for (int i = 0; i < 3; i++)
            {
                string input = Console.ReadLine()!;
                int answerNum = 0;
                try
                {
                    answerNum = int.Parse(input);
                    if (answerNum == (a - b))
                    {
                        Console.WriteLine($"Correct!\n{a} - {b} = {a - b}!");
                        questionsList.Add($"Correct answer ({answerNum})");
                        goodAnswers++;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not correct, please try again!");
                        questionsList.Add($"Wrong answer ({answerNum})");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"{e.Message}");
                    Console.WriteLine("Not correct, please try again!");
                    questionsList.Add($"Wrong answer (wrong input ex. character instead of number)");
                }
            }
        }

        public void divisionChallange()
        {
            questions++;
            int a = 1, b = 1;
            do
            {
                Random rng = new Random();
                a = rng.Next(1,10);
                b = rng.Next(1,10);
            } while (a % b != 0);
            Console.WriteLine("========================");
            string question = $"{a} / {b} = ?";
            questionsList.Add(question);
            Console.WriteLine($"Yor question is:\n{question}\nYour answer:");
            for (int i = 0; i < 3; i++)
            {
                string input = Console.ReadLine()!;
                int answerNum = 0;
                try
                {
                    answerNum = int.Parse(input);
                    if (answerNum == (a / b))
                    {
                        Console.WriteLine($"Correct!\n{a} / {b} = {a / b}!");
                        questionsList.Add($"Correct answer ({answerNum})");
                        goodAnswers++;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not correct, please try again!");
                        questionsList.Add($"Wrong answer ({answerNum})");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"{e.Message}");
                    Console.WriteLine("Not correct, please try again!");
                    questionsList.Add($"Wrong answer (wrong input ex. character instead of number)");
                }
            }
        }
    }



    class Programm
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            bool gameLoop = true;
            while (gameLoop)
            {
                char userSelection = game.mainMenu();
                if (userSelection == 'A')
                {
                    game.additionChallange();
                }
                else if (userSelection == 'X')
                {
                    gameLoop = false;
                }
                else if (userSelection == 'B')
                {
                    game.substractionChallange();
                }
                else if (userSelection == 'C')
                {
                    game.multiplicationChallange();
                }
                else if (userSelection == 'D')
                {
                    game.divisionChallange();
                }
                else if (userSelection == 'E')
                {
                    Random rng = new Random();
                    int randomSelection = rng.Next(1,5);
                    switch (randomSelection)
                    {
                        case 1:
                            game.additionChallange();
                            break;
                        case 2:
                            game.substractionChallange();
                            break;
                        case 3:
                            game.multiplicationChallange();
                            break;
                        case 4:
                            game.divisionChallange();
                            break;
                        default:
                            break;
                    }
                }
                else if (userSelection == 'H')
                {
                    game.showGamesHistory();
                }
                Console.WriteLine($"\n");
            }
        }
    }
}