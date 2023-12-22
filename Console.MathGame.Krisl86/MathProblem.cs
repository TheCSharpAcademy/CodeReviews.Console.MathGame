namespace KristianLepka.MathGame;

enum Difficulty
{
    Easy, Medium, Hard
}

class MathProblem
{
    static Random rand = new();

    public static MathProblem Generate(char pOperator, Difficulty difficulty)
    {
        int na = 0;
        int nb = 0;
        int answer = 0;
        int plusFrom, plusTo, minFrom, minTo, mulFrom, mulTo, divFrom, divTo;

        if (difficulty == Difficulty.Easy)
        {
           plusFrom = 0; plusTo = 51; minFrom = 0; minTo = 51; mulFrom = 0; mulTo = 11; divFrom = 0; divTo = 21;
        }
        else if (difficulty == Difficulty.Medium)
        {
            plusFrom = 0; plusTo = 251; minFrom = 0; minTo = 251; mulFrom = 0; mulTo = 26; divFrom = 0; divTo = 51;
        }
        else
        {
            plusFrom = 0; plusTo = 1001; minFrom = 0; minTo = 1001; mulFrom = 0; mulTo = 51; divFrom = 0; divTo = 101;
        }

        if (pOperator == '+')
        {
            na = rand.Next(plusFrom, plusTo);
            nb = rand.Next(plusFrom, plusTo);
            answer = na + nb;
        }
        else if (pOperator == '-')
        {
            na = rand.Next(minFrom, minTo);
            nb = rand.Next(minFrom, minTo);
            answer = na - nb;
        }
        else if (pOperator == '*')
        {
            na = rand.Next(mulFrom, mulTo);
            nb = rand.Next(mulFrom, mulTo);
            answer = na * nb;
        }
        else if (pOperator == '/')
        {
            na = rand.Next(divFrom, divTo);
            var divs = GetDivisors(na);
            nb = divs[rand.Next(divs.Count)];
            answer = na / nb;
        }

        return new MathProblem(na, nb, pOperator, answer, difficulty);
    }

    static List<int> GetDivisors(int n)
    {
        if (n == 0)
            return new List<int>() { 1 };

        var divisors = Enumerable.Range(2, n / 2)
            .Where(i => n % i == 0).ToList();
        divisors.Insert(0, 1);
        divisors.Add(n);
        return divisors;
    }

    MathProblem(int numberA, int numberB, char pOperator, int answer, Difficulty difficulty)
    {
        NumberA = numberA;
        NumberB = numberB;
        Operator = pOperator;
        Answer = answer;
        Difficulty = difficulty;
    }

    public int NumberA { get; }
    public int NumberB { get; }
    public char Operator { get; }
    public int Answer { get; }
    public Difficulty Difficulty { get; }
    public bool AnsweredCorrectly { get; set; }

    public override string ToString()
        => $"{NumberA} {Operator} {NumberB} = ?";
}

