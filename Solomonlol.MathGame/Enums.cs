using System;
using System.Collections.Generic;
using System.Text;

namespace STUDY.MathGame
{
    public class Enums
    {
        public enum Operation
        {
            Addition ='+',
            Substraction='-',
            Multiplication='*',
            Division='/',
            Exit=0
        }
        public enum Difficulty
        {
            Easy=10,
            Medium=100,
            Hard=1000
        }

        public enum Menu
        {
            StartGame=1,
            GameHistory,
            Exit
        }
    }
}
