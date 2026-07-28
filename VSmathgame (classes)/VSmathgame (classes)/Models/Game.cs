
namespace VSmathgame__classes_.Models;

internal class Game
{
    internal int Score { get; set; }
    // getter retrieves data
    //setter lets us modify the field
    internal DateTime Date { get; set; }

    internal GameType Type { get; set; }

}

internal enum GameType
{
    Addition, Subtraction,
    Division, Multiplication
}
// created enum to hold names we will be using as gametytpe variables 
// its in the class method

