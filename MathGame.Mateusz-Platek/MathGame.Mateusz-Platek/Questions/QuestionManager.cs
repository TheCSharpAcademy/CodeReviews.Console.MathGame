namespace MathGame.Mateusz_Platek.Questions;

public static class QuestionManager
{
    private static List<AdditionQuestion> additionQuestions = new ();
    private static List<SubtractionQuestion> subtractionQuestions = new ();
    private static List<MultiplicationQuestion> multiplicationQuestions = new ();
    private static List<DivisionQuestion> divisionQuestions = new ();
    private static bool initialized = false;
    private static int questions = 20;

    public static void InitLists(DifficultyLevel difficultyLevel)
    {
        additionQuestions.Clear();
        subtractionQuestions.Clear();
        multiplicationQuestions.Clear();
        divisionQuestions.Clear();
        
        for (int i = 0; i < questions; i++)
        {
            additionQuestions.Add(new AdditionQuestion(difficultyLevel));
            subtractionQuestions.Add(new SubtractionQuestion(difficultyLevel));
            multiplicationQuestions.Add(new MultiplicationQuestion(difficultyLevel));
            divisionQuestions.Add(new DivisionQuestion(difficultyLevel));
        }
        initialized = true;
    }

    public static AdditionQuestion GetAdditionQuestion()
    {
        if (!initialized)
        {
            InitLists(DifficultyLevel.Easy);
        }
        Random random = new Random();
        return additionQuestions.ElementAt(random.Next(0, questions));
    }

    public static SubtractionQuestion GetSubtractionQuestion()
    {
        if (!initialized)
        {
            InitLists(DifficultyLevel.Easy);
        }
        Random random = new Random();
        return subtractionQuestions.ElementAt(random.Next(0, questions));
    }
    
    public static MultiplicationQuestion GetMultiplicationQuestion()
    {
        if (!initialized)
        {
            InitLists(DifficultyLevel.Easy);
        }
        Random random = new Random();
        return multiplicationQuestions.ElementAt(random.Next(0, questions));
    }
    
    public static DivisionQuestion GetDivisionQuestion()
    {
        if (!initialized)
        {
            InitLists(DifficultyLevel.Easy);
        }
        Random random = new Random();
        return divisionQuestions.ElementAt(random.Next(0, questions));
    }
}