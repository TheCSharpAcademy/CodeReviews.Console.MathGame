using MathGame.src;
using MathGame.src.enums;

namespace MathGame
{
    class Program
    {
        static void Main(String[] args)
        {
            String name;
            int selectedGameLevel = new();

            Console.WriteLine("Welcome Aboard! What should the geeks call you?");
            name = Console.ReadLine();
            Console.WriteLine($"Hi {name}, Let's get started: \n Select your game level: \n 1. Beginner \n 2. Intermediate \n 3.Professional");
            do
            {
                if (selectedGameLevel > 3) Console.WriteLine("Wrong Selection! select from the list");
                selectedGameLevel = int.Parse(Console.ReadLine());

            } while (selectedGameLevel > 3);



            switch (selectedGameLevel)
            {
                case 1: GameLevel.gameLevel = Gamelevel.Beginner; new Player(name, GameLevel.gameLevel); break;
                case 2: GameLevel.gameLevel = Gamelevel.Intermediate; new Player(name, GameLevel.gameLevel); break;
                case 3: GameLevel.gameLevel = Gamelevel.Pro; new Player(name, GameLevel.gameLevel); break;
            }

            // Player player = new(name, );
        }
    }
}
