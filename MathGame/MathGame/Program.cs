// See https://aka.ms/new-console-template for more information

using MathGame;

var pastGames = new List<string>();

var userName = Utilities.ShowWelcomeScreen();

var userChoice = Utilities.ShowMainMenu(userName);

while (userChoice != 3)
{
    switch (userChoice)
    {
        case 1:
            int difficultyChoice = Utilities.ShowDifficultyMenu();
            while (difficultyChoice < 1 || difficultyChoice > 3)
            {
                Utilities.ShowInvalidMenuSelection();
                difficultyChoice = Utilities.ShowDifficultyMenu();
            }

            int gameChoice = Utilities.ShowGameModeMenu();
            while (gameChoice < 1 || gameChoice > 4)
            {
                Utilities.ShowInvalidMenuSelection();
                gameChoice = Utilities.ShowGameModeMenu();

            }
            if (gameChoice == 1)
            {
                pastGames.Add(Utilities.PlayGame(difficultyChoice, "Addition"));
                userChoice = Utilities.ShowMainMenu();
            }
            if (gameChoice == 2)
            {
                pastGames.Add(Utilities.PlayGame(difficultyChoice, "Subtraction"));
                userChoice = Utilities.ShowMainMenu();

            }
            if (gameChoice == 3)
            {
                pastGames.Add(Utilities.PlayGame(difficultyChoice, "Division"));
                userChoice = Utilities.ShowMainMenu();

            }
            if (gameChoice == 4)
            {
                pastGames.Add(Utilities.PlayGame(difficultyChoice, "Multiplication"));
                userChoice = Utilities.ShowMainMenu();

            }
            break;
        case 2:
            Console.Clear();
            foreach (var item in pastGames)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nPress enter to continue");
            Console.ReadLine();
            userChoice = Utilities.ShowMainMenu();
            break;

        default:
            Utilities.ShowInvalidMenuSelection();
            userChoice = Utilities.ShowMainMenu();
            break;

    }
}



