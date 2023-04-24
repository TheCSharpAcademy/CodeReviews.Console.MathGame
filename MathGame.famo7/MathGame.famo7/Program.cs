﻿
var game = new Game();

while (true)
{
    Menu();
    char gametype = Console.ReadLine()[0];
    if (gametype == 'Q') break;
    if (gametype == 'V')
    {
        game.ViewHistory();
        continue;
    }
    ParentGame gameChoice = gametype switch
    {
        'A' => new Addition(),
        'S' => new Subtraction(),
        'M' => new Multiplication(),
        'D' => new Division(),
    };

    for (int i = 0; i < 2; i++)
    {
        Console.WriteLine($"{gameChoice.Name} game");
        var (a, b) = GetValues();

        switch (gametype)
        {
            case 'A':
                Console.WriteLine($"{a} + {b}");
                int answer = int.Parse(Console.ReadLine());
                if (CheckAnswer(answer, a + b))
                {
                    Console.WriteLine("Correct");
                    gameChoice.Point++;
                }
                else Console.WriteLine("Wrong");
                continue;
            case 'S':
                Console.WriteLine($"{a} - {b}");
                answer = int.Parse(Console.ReadLine());
                if (CheckAnswer(answer, a - b))
                {
                    Console.WriteLine("Correct");
                    gameChoice.Point++;
                }
                else Console.WriteLine("Wrong");
                continue;
            case 'M':
                Console.WriteLine($"{a} * {b}");
                answer = int.Parse(Console.ReadLine());
                if (CheckAnswer(answer, a * b))
                {
                    Console.WriteLine("Correct");
                    gameChoice.Point++;
                }
                else Console.WriteLine("Wrong");
                continue;
            case 'D':
                Console.WriteLine($"{a} / {b}");
                answer = int.Parse(Console.ReadLine());
                if (CheckAnswer(answer, a / b))
                {
                    Console.WriteLine("Correct");
                    gameChoice.Point++;
                }
                else Console.WriteLine("Wrong");
                continue;
            default:
                break;
        }
    }
    game.AddHistory(gameChoice);

}


void Menu()
{
    Console.WriteLine("What game would you like to play today? Choose from the options below:");
    Console.WriteLine("V - View Previous Games");
    Console.WriteLine("A - Addition");
    Console.WriteLine("S - Subtraction");
    Console.WriteLine("M - Multiplication");
    Console.WriteLine("D - Division");
    Console.WriteLine("Q - Quit the program");

}

Tuple<int, int> GetValues()
{
    Random r = new Random();
    return Tuple.Create(r.Next(1, 5), r.Next(1, 5));
}

bool CheckAnswer(int a, int b) => a == b;

