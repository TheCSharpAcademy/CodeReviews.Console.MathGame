using MathGame.Wolfieeex;

// Introduce the player to the Maths game:
Console.WriteLine("Welcome to the Maths Game! It's great you're spending your time training your brain!");
Console.Write("Please insert your name: ");

// Get player's name and current date (if player tries to skip and presses enter instead, ask for input again). Also, capitalise the first letter of the name:
string? name = null;
DateTime date = DateTime.UtcNow;
Helpers.ReadInput(ref name, "Don't be shy! Please, introduce yourself: ");
name = Char.ToUpper(name[0]) + name.Substring(1);

// Display main menu:
MainMenu menu = new MainMenu();
menu.MainMenuFunctionality(name, date);

// On program close:
Console.Clear();
Console.WriteLine("Thanks for playing the Maths Game! See you soon!\n");



