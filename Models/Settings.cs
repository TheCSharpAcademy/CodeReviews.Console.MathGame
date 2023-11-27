namespace Branch_Console;

internal class Settings
{
    internal string PlayerName { get; set; }

    internal Difficulty Difficulty { get; set; }

    internal int QuestionsCount { get; set; }
}

internal enum Difficulty : int
{
    Easy = 1, // only one operation // result between 1 and 20
    Normal = 2, // positive or negative integers // only one operation // result between -40 and 40
    Hard = 3, //positive or negatives integers //2 operations // result between -80 and 80
    //impossible = 4, 
}