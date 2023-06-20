using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.kmakai;

public class Game
{
    public int NumberOne { get; set; }
    public int NumberTwo { get; set; }
    public Operation Op { get; set; }
    public int Answer { get; set; }
    public int UserAnswer { get; set; }

    public Game(Operation operation)
    {
        Random random = new Random();
        NumberOne = random.Next(1, 101);
        NumberTwo = random.Next(1, 101);
        Op = operation;
        Answer = Op switch
        {
            Operation.Add => Calculator.Add(NumberOne, NumberTwo),
            Operation.Subtract => Calculator.Subtract(NumberOne, NumberTwo),
            Operation.Multiply => Calculator.Multiply(NumberOne, NumberTwo),
            Operation.Divide => Calculator.Divide(NumberOne, NumberTwo),
        };
    }



}

public enum Operation
{
    Add,
    Subtract,
    Multiply,
    Divide
}
