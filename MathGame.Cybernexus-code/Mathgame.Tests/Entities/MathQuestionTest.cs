
namespace MathGame.Tests.Entities;

public class MathQuestionTest
{
    private readonly Random _random =  new();
    private readonly GameSettings _gameSettings = new GameSettings(DifficultyLevel.Easy);

    [Fact]
    public void Addition_ShouldCalculateCorrectAnswer()
    {
        //     Arrange
        //     Set up what the test needs
        // Act
        // Perform the behaviour we're testing
        var question = new MathQuestion(Operation.Addition, _random, _gameSettings);

        // Assert
        // Verify the result
        Assert.Equal(question.FirstNumber + question.SecondNumber, question.Answer);
    } 

    [Fact]
    public void Division_ShouldAlwaysProduceInteger()
    {
        var question = new MathQuestion(Operation.Division, _random, _gameSettings );

        Assert.Equal(0, question.FirstNumber % question.SecondNumber);
    }

   [Theory]
   [InlineData(Operation.Addition, "+")]
   [InlineData(Operation.Subtraction, "-")]
   [InlineData(Operation.Multiplication, "*")]
   [InlineData(Operation.Division, "/")]

    public void Operation_ShouldMatchSymbol(Operation operation, string symbol)
    {
       var question = new MathQuestion(operation, _random, _gameSettings);

       Assert.Equal(symbol, question.Symbol);
    }
}