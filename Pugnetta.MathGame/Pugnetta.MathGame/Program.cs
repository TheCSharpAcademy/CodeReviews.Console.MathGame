
using Pugnetta.MathGame;

var dict = new Dictionary<Game, Result>();
var x = Enum.GetValues(typeof(Operation))
    .Cast<Operation>()
    .Select(o => o.ToString());

string? o = "";

while (true)
{

    while (!x.Contains(o))
    {
        Console.WriteLine(string.Join(",", x));
        o = Console.ReadLine();
    }
    var res = 0;
    bool parse = true;
    Console.WriteLine("Guess result:");
    while (parse)
    {
        parse = !int.TryParse(Console.ReadLine(), out int r);
        res = r;
    }
    var game = Game.Create();
    Console.WriteLine($"{o}: {game.N1}, {game.N2}");
    var y = Exe(game, o);
    Console.WriteLine($"Result: {y}");
    if (y != res) Console.WriteLine($"Guess: {res}, Result: {y}, Lose");
    else Console.WriteLine($"Guess: {res}, Result: {y}, Win");
    dict.Add(game, new Result(res == y, res));
    o = "";
    foreach (var kvp in dict) Console.WriteLine($"Games Played : {kvp.Key}, {kvp.Value}");
}


static int Exe(Game game, string? o) => o switch
{
    "Sum" => game.N1 + game.N2,
    "Sub" => game.N1 - game.N2,
    "Mol" => game.N1 * game.N2,
    "Div" when game.N1 % game.N2 == 0 => game.N1 / game.N2,
    "Div" => game.N1 * 3 / game.N2,
    _ => 999
};



