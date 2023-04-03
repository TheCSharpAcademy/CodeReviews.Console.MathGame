using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.jwhitt3r
{

    /// <summary>
    /// The Game class is a generic class that allows for the four variations of game.
    /// It class takes a core symbol that is used to define the game, e.g., + = addition, - = subtraction
    /// / = devision, and * = multiplication.
    /// </summary>
    public class Game
    {

        /// <summary>
        /// The games default difficulty.
        /// </summary>
        private int _difficulty = 1;

        /// <summary>
        /// The amount of lives a user has on starting a game.
        /// </summary>
        private int _lives = 5;

        /// <summary>
        /// The list of symbols used to determine the game type and additional symbols
        /// to be used in the equations.
        /// </summary>
        private List<char> _symbols = new List<char> { '/', '+', '*', '-' };

        /// <summary>
        /// Random number generate is used to pick the additional symbols and integers
        /// in the equation.
        /// </summary>
        private Random _rnd = new Random();

        /// <summary>
        /// A Data Table is used to convert the formula from a string of characters into a mathematical formula
        /// and calculate the formulas answer.
        /// </summary>
        private DataTable dt = new DataTable();

        /// <summary>
        /// Holds the complete equation.
        /// </summary>
        public string Equation {  get; set; }

        /// <summary>
        /// The core symbol of the game, e.g., +, -, /, *.
        /// </summary>
        public char Symbol { get; set; }

        /// <summary>
        /// Holds a reference to the score object that is used to track the users correct formulas
        /// and answers.
        /// </summary>
        public Score results;

        /// <summary>
        /// Games constructor to generate a new game
        /// </summary>
        /// <param name="coreSymbol">The core symbol used to determine the game type, e.g., +, -, /, *</param>
        /// <param name="gameScore">The Score object that is used to tracker the users successful answers</param>
        /// <param name="difficulty">The difficulty of the game</param>
        public Game(char coreSymbol, Score gameScore, int difficulty) {
            this.Symbol = coreSymbol;
            this.results = gameScore;
            this._difficulty = difficulty;
            _symbols.Remove(this.Symbol);
            this.GameLoop();
        }

        /// <summary>
        /// GenerateNumbers creates a random set of integers to be used in the mathematical formula.
        /// The amount of numbers that are generated are defined by the difficulty of the game, e.g.,
        /// if the difficulty is 1 then there will only be two numbers. If the games difficulty is two
        /// then there will be three numbers and if the game is set to the difficulty of three, there will be
        /// four numbers. The size of the numbers is also determined by the difficulty, by default it is 1000 * the difficulty.
        /// </summary>
        /// <returns>An array of integers</returns>
        private int[] GenerateNumbers()
        {

            int[] numbers = new int[1 + this._difficulty]; // We always want 2 numbers to begin with and then add the additional numbers as we go
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = this._rnd.Next(1, 1000 * this._difficulty);
            }
            return numbers;
        }

        /// <summary>
        /// GetRandomSymbolFromList randomly picks a symbol from the list of core symbols (this does not include the core symbol).
        /// E.g., If the core symbol is +, then it will return either, *, -, or / as a char
        /// </summary>
        /// <returns>A symbol as a char</returns>
        private char GetRandomSymbolFromList()
        {
            int index = this._rnd.Next(this._symbols.Count);
            return this._symbols[index];
        }

        /// <summary>
        /// GenerateEquation builds the structure of the math problem to be presented to the user.
        /// This function calls the GenerateNumbers function to get the array of integers, constructs
        /// the default difficulty, which is two numbers and the core symbol and then extends the equation
        /// to incorporate additional symbols and additional numbers based on the difficulty of the game.
        /// </summary>
        /// <returns>A string is returned that presents the equation to the user</returns>
        private string GenerateEquation()
        {
            string equation = "";

            int[] numbers = this.GenerateNumbers();

            for(int i = 0; i < numbers.Length; i++)
            {
                if (i == 0)
                {
                    equation += $"({numbers[i]}{this.Symbol}";
                } else if (i == numbers.Length - 1)
                {
                    equation += $"{numbers[i]})";
                    break;
                }
                else
                {
                    char additionalSymbol = this.GetRandomSymbolFromList();
                    equation += $"{numbers[i]}{additionalSymbol}";
                }
            }
            this.Equation = equation;
            return equation;
        }

        /// <summary>
        /// Prints the equation to the console
        /// </summary>
        public void PrintEquation()
        {
            Console.WriteLine($"What is the answer for the following math problem: {this.Equation}");
            
        }

        /// <summary>
        /// A data table is used to convert the string-based equation into a mathematical formula
        /// and then generate the result.
        /// </summary>
        /// <returns>Returns the answer of the formula</returns>
        private int computeResult()
        {
           int answer = Convert.ToInt32(dt.Compute(this.Equation, ""));
           return answer;
        }

        /// <summary>
        /// GameLoop cycles through the game until the user has no more lives.
        /// On return, it goes back to the main menu.
        /// </summary>
        public void GameLoop()
        {
            while (this._lives > 0)
            {
                this.GenerateEquation();
                this.PrintEquation();
                this.GetUsersAnswer();
            }
            return;
        }

        /// <summary>
        /// GetUsersAnswer awaits the user to input the correct answer.
        /// If the user gets the equation correct their lives increases by one
        /// and the formula and answer is added to a list. If they get it wrong
        /// they lose a life and have another attempt at the equation.
        /// </summary>
        public void GetUsersAnswer()
        {
            int attempts = 1;
            Console.WriteLine("What is your answer?");
            Console.WriteLine(computeResult());
            int answer = int.TryParse(Console.ReadLine(), out answer) ? answer : 0;

            while (answer != computeResult())
            {
                attempts++;
                Console.WriteLine("Unlucky try again");
                answer = int.TryParse(Console.ReadLine(), out answer) ? answer : 0;
                this.DecreaseLives();
                if(this._lives <= 0)
                {
                    Console.WriteLine("Game over, no more lives!");
                    break;
                }
            }
            this.IncreaseLives();
            results.AddScore($"Equation:{this.Equation} - Answer:{answer} - Attempts at Equation:{attempts}");
            Console.WriteLine("You got it right!");
        }

        /// <summary>
        /// Increases the users life by one
        /// </summary>
        public void IncreaseLives()
        {
            this._lives += 1;
        }

        /// <summary>
        /// Decreases the users life by one
        /// </summary>
        public void DecreaseLives()
        {
            this._lives -= 1;
        }

    }
}
