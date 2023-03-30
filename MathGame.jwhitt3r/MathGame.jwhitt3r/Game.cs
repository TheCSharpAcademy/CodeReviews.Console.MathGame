using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.jwhitt3r
{
    public class Game
    {

        private int _difficulty = 1;
        private int _lives = 5;
        private Random _rnd = new Random();
        private DataTable dt = new DataTable();
        public string Equation {  get; set; }
        public char Symbol { get; set; }
        public Score results;
        private List<char> _symbols = new List<char>{'/', '+', '*', '-'};
        public Game(char coreSymbol, Score gameScore, int difficulty) {
            this.Symbol = coreSymbol;
            this.results = gameScore;
            this._difficulty = difficulty;
            _symbols.Remove(this.Symbol);
            this.GameLoop();
        }

        public void IncreaseDifficulty()
        {
            // Max difficulty is 3
            if (this._difficulty >= 3)
            {
                this._difficulty += 1;
            }
        }

        private int[] GenerateNumbers()
        {

            int[] numbers = new int[1 + this._difficulty]; // We always want 2 numbers to begin with and then add the additional numbers as we go
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = this._rnd.Next(1, 1000);
            }
            return numbers;
        }

        private char GetRandomSymbolFromList()
        {
            int index = this._rnd.Next(this._symbols.Count);
            return this._symbols[index];
        }

        private string GenerateForumla()
        {
            string problemSet = "";

            int[] numbers = this.GenerateNumbers();

            for(int i = 0; i < numbers.Length; i++)
            {
                if (i == 0)
                {
                    problemSet += $"({numbers[i]}{this.Symbol}";
                } else if (i == numbers.Length - 1)
                {
                    problemSet += $"{numbers[i]})";
                    break;
                }
                else
                {
                    char additionalSymbol = this.GetRandomSymbolFromList();
                    problemSet += $"{numbers[i]}{additionalSymbol}";
                }
            }
            this.Equation = problemSet;
            return problemSet;
        }

        public void PrintQuestion()
        {
            string myStatement = this.GenerateForumla();
            Console.WriteLine($"What is the answer for the following math problem: {myStatement}");
            
        }

        private int computeResult()
        {
           int val = Convert.ToInt32(dt.Compute(this.Equation, ""));
           return val;
        }

        public void GameLoop()
        {
            while (this._lives > 0)
            {
                this.PrintQuestion();
                this.GetAnswer();
            }
            return;
        }

        public void GetAnswer()
        {
            Console.WriteLine("What is your answer?");
            Console.WriteLine(computeResult());
            int answer = int.TryParse(Console.ReadLine(), out answer) ? answer : 0;

            while (answer != computeResult())
            {
                Console.WriteLine("Unlucky try again");
                answer = int.TryParse(Console.ReadLine(), out answer) ? answer : 0;
                this.DecreaseLives();
                if(this._lives <= 0)
                {
                    Console.WriteLine("Game over, no more lives!");
                    break;
                }
            }
            results.AddScore($"{this.Equation} - {answer}");
            Console.WriteLine("You got it right!");
        }

        public void IncreaseLives()
        {
            this._lives += 1;
        }

        public void DecreaseDifficulty()
        {
            // Minimum difficulty is 1
            if (this._difficulty <=1 )
            {
                this._difficulty -= 1;
            }
        }

        public void DecreaseLives()
        {
            this._lives -= 1;
        }

    }
}
