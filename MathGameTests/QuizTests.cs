global using Math_Game.Tools;
global using Math_Game.Application;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace MathGameTests;

[TestFixture]
internal class QuizTests
{
    Quiz _cut;
    QuestionGenerator _questionGenerator;
    Mock<IMathQuizUserInteractor> _mockUserInteractor;
    Mock<IRandom> _mockRandom;

    [SetUp]
    public void Setup()
    {
        _mockUserInteractor = new Mock<IMathQuizUserInteractor>();
        _mockRandom = new Mock<IRandom>();
        _questionGenerator = new QuestionGenerator(_mockRandom.Object);
        _cut = new Quiz(_mockUserInteractor.Object, _questionGenerator);
    }

    [Test]
    public void StartGame_ShallHaveCorrectAmountOfQuestionsGenerated()
    {
        _cut.StartGame(Math_Game.Enums.Difficulty.Easy, Math_Game.Enums.MenuOptions.Sum);
        Assert.That(_cut.Questions.Count(), Is.EqualTo(5));
    }
    [Test]
    public void StartGame_ShallHaveScoreOf5_IfAllUserAnswersAreCorrect()
    {
        _mockRandom.SetupSequence(mock => mock
        .Next(QuestionsRepository.EasyQuestionsSum.Count()))
            .Returns(0)
            .Returns(1)
            .Returns(2)
            .Returns(3)
            .Returns(4);
        _mockUserInteractor
            .SetupSequence(mock => mock.PromptForAnswer())
            .Returns("5")
            .Returns("11")
            .Returns("15")
            .Returns("17")
            .Returns("15");
        _cut.StartGame(Math_Game.Enums.Difficulty.Easy, Math_Game.Enums.MenuOptions.Sum);
        Assert.That(_cut.Points, Is.EqualTo(5));
    }
    [Test]
    public void StartGame_ShallNotIncrasePointsField_IfUserAnswerIsIncorrect()
    {
        _mockRandom.SetupSequence(mock => mock
        .Next(QuestionsRepository.EasyQuestionsSum.Count()))
            .Returns(0)
            .Returns(1)
            .Returns(2)
            .Returns(3)
            .Returns(4);
        _mockUserInteractor
            .SetupSequence(mock => mock.PromptForAnswer())
            .Returns("5")
            .Returns("11")
            .Returns("10")
            .Returns("17")
            .Returns("15");
        _cut.StartGame(Math_Game.Enums.Difficulty.Easy, Math_Game.Enums.MenuOptions.Sum);
        Assert.That(_cut.Points, Is.EqualTo(4));
    }
    [Test]
    public void StartGame_ShallDisplayFinalResult_AfterAllQuestions()
    {
        _cut.StartGame(Math_Game.Enums.Difficulty.Easy, Math_Game.Enums.MenuOptions.Sum);
        _mockUserInteractor.Verify(mock => mock.DisplayMessage($"Final result: {_cut.Points} points. Time: {_cut.Time} seconds"), Times.Once());
    }
}
