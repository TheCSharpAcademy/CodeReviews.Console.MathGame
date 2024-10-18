using System.Runtime.CompilerServices;
using System.Threading.Tasks.Sources;

namespace MathClasses
{
    public class MathGame
    {
        private string? SelectedGame;
        private int SelDif = 1;
        private int gameCounter = 0;
        private List<string> Scores = new List<string>();  

        public void Menu()
        {
            bool end = false;
            int diff;

            do
            {
                Console.Clear();
                Console.WriteLine("Math game, select a operation you want to play with:");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("+");
                Console.WriteLine("-");
                Console.WriteLine("*");
                Console.WriteLine("/");
                Console.WriteLine("'g' to see scores");
                Console.WriteLine("'q' to quit the game");
                Console.Write("Give the operand here:");
                SelectedGame = Console.ReadLine().Trim();
                
                switch (SelectedGame)
                {
                    case "+":
                        DifMenu();
                        diff = Difficulty(SelDif);
                        Console.Clear();
                        Console.WriteLine("Game + selected, press any key to start");
                        Console.ReadKey();
                        Game(SelectedGame, diff); 
                        break;
                    case "-":
                        DifMenu();
                        diff = Difficulty(SelDif);
                        Console.Clear();
                        Console.WriteLine("Game - selected, press any key to start");
                        Console.ReadKey();
                        Game(SelectedGame, diff);
                        break;
                    case "*":
                        DifMenu();
                        diff = Difficulty(SelDif);
                        Console.Clear();
                        Console.WriteLine("Game * selected, press any key to start");
                        Console.ReadKey();
                        Game(SelectedGame, diff);
                        break;
                    case "/":
                        DifMenu();
                        diff = Difficulty(SelDif);
                        Console.Clear();
                        Console.WriteLine("Game / selected, press any key to start");
                        Console.ReadKey();
                        Game(SelectedGame, diff);
                        break;
                    case "q":
                        end = true;
                        break;
                    case "g":
                        ScoreList();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input, press any key to return to menu");
                        Console.ReadKey();
                        break;
                }
                
            } while (!end);
            
        }

        private void DifMenu()
        {
            bool IsCorrect = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Select a difficulty:");
                Console.WriteLine("Easy: 1");
                Console.WriteLine("Mid: 2");
                Console.WriteLine("Hard: 3");
                Console.Write("Give a number: ");
                bool dif = int.TryParse(Console.ReadLine().Trim(), out int valinta);
                if (dif)
                {
                    SelDif = valinta;
                }
                else
                {
                    Console.Write("Wrong input, press any key to try again");
                    Console.ReadKey();
                    IsCorrect = false;
                }
            } while (!IsCorrect);
        }

        private int Difficulty(int d)
        {
            int diff = 1;

            if (d == 1)
                diff = 10;
            else if (d == 2)
                diff = 50;
            else if (d == 3)
                diff = 100;

            return diff;
        }

        private void ScoreList()
        {
            int i = 0;
            while (i < Scores.Count)
            {
                Console.WriteLine(Scores[i]);
                i++;
            }
            Console.WriteLine("\nPress any key to return to menu");
            Console.ReadKey();
        }

        public void Game(string op, int MaxNum)
        {
            Random num1 = new Random();
            Random num2 = new Random();
            Random div1 = new Random();
            Random div2 = new Random();
            int ScoreCounter = 0;
            bool answer;
            int RightAnswer = 0;
            bool IsWrong = false; 


            while(IsWrong == false)
            {
                int n1 = num1.Next(1, MaxNum);
                int n2 = num2.Next(1, MaxNum);
                int dnum1 = div1.Next(1, MaxNum);
                int dnum2 = div2.Next(1, MaxNum);
                while ((dnum1 % dnum2) != 0)
                {
                    dnum1 = div1.Next(1, MaxNum);
                    dnum2 = div2.Next(1, MaxNum);
                }


                if (op == "+")
                {
                    RightAnswer = n1 + n2;
                    Console.WriteLine($"{n1} + {n2}");
                }else if (op == "-")
                {
                    RightAnswer = n1 - n2;
                    Console.WriteLine($"{n1} - {n2}");
                }else if(op == "*")
                {
                    RightAnswer = n1 * n2;
                    Console.WriteLine($"{n1} * {n2}");
                }else if( op == "/")
                {
                    RightAnswer = dnum1 / dnum2;
                    Console.WriteLine($"{dnum1} / {dnum2}");
                }
                Console.Write("Answer: ");
                answer = int.TryParse(Console.ReadLine(), out int result);
                if (answer)
                {
                     if(result == RightAnswer) 
                     { 
                        IsWrong = false;
                        ScoreCounter++;
                     }
                     else
                     {
                         Console.WriteLine("Wrong answer! Press any key to return to menu");
                         Console.ReadKey();
                         IsWrong = true;
                     }
                }
                else
                {
                    Console.WriteLine("Wrong input! Game over. Press any key to return to menu");
                    Console.ReadKey();
                    IsWrong = true;
                }
            }
            string listalle = $"Game: ({SelectedGame}), Score: {ScoreCounter}";
            Scores.Add(listalle);
            gameCounter++;
        }
    }
}
