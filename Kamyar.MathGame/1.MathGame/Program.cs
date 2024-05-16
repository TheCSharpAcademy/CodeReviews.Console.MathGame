Messages.WelcomeMessage();
bool isRunning = true;

Messages.DifficultyMessage();
int difficultyChoice = Menu.GetDifficulty();

Messages.NumberOfQuestionsMessage();
int numberOfQuestions = Menu.GetNumberOfQuestions();

while (isRunning && numberOfQuestions > 0)
{
    Messages.MenuMessage(numberOfQuestions);
    string questionTypeChoice = Menu.GetQuestionType();

    if (questionTypeChoice == "Q")
    {
        isRunning = false;
    }
    else if (questionTypeChoice == "V")
    {
        Results.ShowResults();
    }
    else
    {
        Game game = new Game(questionTypeChoice, difficultyChoice);
        numberOfQuestions -= 1;
    }
}
Messages.EndOfGameMessage();
Results.ShowResults();
Console.ReadLine();
