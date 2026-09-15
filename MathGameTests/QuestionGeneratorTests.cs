using Math_Game.Enums;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGameTests;

[TestFixture]
internal class QuestionGeneratorTests
{
    QuestionGenerator _cut;
    Mock<IRandom> _mockRandom;

    [SetUp]
    public void Setup()
    {
        _mockRandom = new Mock<IRandom>();
        _cut = new QuestionGenerator(_mockRandom.Object);
    }

    [TestCase(Difficulty.Easy, MenuOptions.Sum, "What's the result of 2 + 3?", "5")]
    [TestCase(Difficulty.Medium, MenuOptions.Subtraction, "What's the result of 234 - 125?", "109")]
    [TestCase(Difficulty.Hard, MenuOptions.Multiplication, "What's the result of 125 × 24?", "3000")]
    [TestCase(Difficulty.Medium, MenuOptions.Division, "What's the result of 144 ÷ 12?", "12")]
    public void Generate_ShallReturnAppropriateQuestion_WithSpecifiedParameters(Difficulty difficulty, MenuOptions gameMode, string expectedText, string expectedResult)
    {
        _mockRandom.SetupSequence(mock => mock.Next(QuestionsRepository.EasyQuestionsSum.Count()))
            .Returns(0);
        var result = _cut.Generate(difficulty, gameMode);
        Assert.That(result.Text, Is.EqualTo(expectedText));
        Assert.That(result.Result, Is.EqualTo(expectedResult));
    }
}
