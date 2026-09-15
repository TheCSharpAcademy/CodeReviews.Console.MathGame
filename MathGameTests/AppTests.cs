using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGameTests;

[TestFixture]
internal class AppTests
{
    App _cut;
    Mock<IMathQuizUserInteractor> _mockIMathQuizUserInteractor;
    Mock<IRandom> _mockRandom;
    Quiz _quiz;
    GameResults _gameResults;
    QuestionGenerator _questionGenerator;

    [SetUp]
    public void Setup()
    {
        _mockRandom = new Mock<IRandom>();
        _questionGenerator = new QuestionGenerator(_mockRandom.Object);
        _mockIMathQuizUserInteractor = new Mock<IMathQuizUserInteractor>();
        _quiz = new Quiz(_mockIMathQuizUserInteractor.Object, _questionGenerator);
        _gameResults = new GameResults();
        _cut = new App(_mockIMathQuizUserInteractor.Object, _quiz, _gameResults);
    }


    [Test]
    public void Run_ShallDisplayRecords_IfChosenOptionIsRecords()
    {
        _mockIMathQuizUserInteractor.SetupSequence(mock => mock.PromptForOption()).Returns("Records").Returns("Sum");
        _mockIMathQuizUserInteractor.Setup(mock => mock.PromptForDifficulty()).Returns("Easy");
        
        _cut.Run();
        _mockIMathQuizUserInteractor.Verify(mock => mock.DisplayResults(_gameResults.Results), Times.Once());
    }
    [Test]
    public void Run_ShallStartQuiz_WithSelectedMenuOption()
    {
        _mockIMathQuizUserInteractor.Setup(mock => mock.PromptForOption()).Returns("Sum");
        _mockIMathQuizUserInteractor.Setup(mock => mock.PromptForDifficulty()).Returns("Easy");

        _cut.Run();
        Assert.That(_quiz.Questions, Is.All.Matches<Question>(q => q.Text.Contains("+")));
    }
    [Test]
    public void Run_ShallAddQuizResult_ToGameResults()
    {
        _mockIMathQuizUserInteractor.SetupSequence(mock => mock.PromptForOption()).Returns("Sum");
        _mockIMathQuizUserInteractor.Setup(mock => mock.PromptForDifficulty()).Returns("Easy");
        _mockIMathQuizUserInteractor.Setup(mock => mock.PromptForAnswer()).Returns("0");
        _mockIMathQuizUserInteractor.Setup(mock => mock.PromptForGameEnd()).Returns(true);
        _cut.Run();
        Assert.That(_gameResults.Results.Contains((0,It.IsAny<double>())));
    }
    [Test]
    public void Run_ShallSetIsGameFinished_ToTrue_WhenUserDoesNotWantToPlayAgain()
    {
        _mockIMathQuizUserInteractor.SetupSequence(mock => mock.PromptForOption()).Returns("Sum");
        _mockIMathQuizUserInteractor.Setup(mock => mock.PromptForDifficulty()).Returns("Easy");
        _mockIMathQuizUserInteractor.Setup(mock => mock.PromptForAnswer()).Returns("0");
        _mockIMathQuizUserInteractor.Setup(mock => mock.PromptForGameEnd()).Returns(true);
        _cut.Run();
        Assert.That(_cut.IsGameFinished, Is.False);
    }
    [Test]
    public void Run_ShallSetIsGameFinished_ToFalse_WhenUserWantsToPlayAgain()
    {
        _mockIMathQuizUserInteractor.SetupSequence(mock => mock.PromptForOption()).Returns("Sum");
        _mockIMathQuizUserInteractor.Setup(mock => mock.PromptForDifficulty()).Returns("Easy");
        _mockIMathQuizUserInteractor.Setup(mock => mock.PromptForAnswer()).Returns("0");
        _mockIMathQuizUserInteractor.Setup(mock => mock.PromptForGameEnd()).Returns(false);
        _cut.Run();
        Assert.That(_cut.IsGameFinished, Is.True);
    }
}
