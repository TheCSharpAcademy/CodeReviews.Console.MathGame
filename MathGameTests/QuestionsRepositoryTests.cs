using NUnit.Framework;

namespace MathGameTests;

[TestFixture]
public class QuestionsRepositoryTests
{

    [Test]
    public void RandomDifficultySumQuestions_ShallReturnCollection_WithCorrectTypeAndCount()
    {
        var questions = QuestionsRepository.RandomDifficultySumQuestions();
        Assert.That(questions, Is.All.Matches<Question>(q => q.Text.Contains("+")));
        Assert.That(questions.Count(), Is.EqualTo(5));
    }
    [Test]
    public void RandomDifficultySubtractionQuestions_ShallReturnCollection_WithCorrectTypeAndCount()
    {
        var questions = QuestionsRepository.RandomDifficultySubtractionQuestions();
        Assert.That(questions, Is.All.Matches<Question>(q => q.Text.Contains("-")));
        Assert.That(questions.Count(), Is.EqualTo(5));
    }
    [Test]
    public void RandomDifficultyMultiplicationQuestions_ShallReturnCollection_WithCorrectTypeAndCount()
    {
        var questions = QuestionsRepository.RandomDifficultyMultiplicationQuestions();
        Assert.That(questions, Is.All.Matches<Question>(q => q.Text.Contains("×")));
        Assert.That(questions.Count(), Is.EqualTo(5));
    }
    [Test]
    public void RandomDifficultyDivisionQuestions_ShallReturnCollection_WithCorrectTypeAndCount()
    {
        var questions = QuestionsRepository.RandomDifficultyDivisionQuestions();
        Assert.That(questions, Is.All.Matches<Question>(q => q.Text.Contains("÷")));
        Assert.That(questions.Count(), Is.EqualTo(5));
    }
}
