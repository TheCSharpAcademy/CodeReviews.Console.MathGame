using Schnopsi.MathGame;

List<string> calculations = new();
ConsoleInteractions.ShowWelcomeMessage();
bool endApp = false;
do
{
	string userChoise = ConsoleInteractions.MainMenu();
	Console.Clear();

	switch (userChoise)
	{
		case "A":
			ConsoleInteractions.HandleAdd(calculations);
			break;
		case "S":
			ConsoleInteractions.HandleSubtract(calculations);
			break;
		case "M":
			ConsoleInteractions.HandleMultiply(calculations);
			break;
		case "D":
			ConsoleInteractions.HandleDivide(calculations);
			break;
		case "P":
			ConsoleInteractions.ShowCalculations(calculations);
			break;
		case "E":
			endApp = true;
			break;
	}
} while (endApp == false);
