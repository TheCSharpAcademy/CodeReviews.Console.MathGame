using Math_Game.Tools;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGameTests;

[TestFixture]
internal class ValidatorTests
{
    Validator _cut;

    [SetUp]
    public void Setup()
    {
        _cut = new Validator();
    }

    [TestCase("Sum")]
    [TestCase("Subtraction")]
    [TestCase("Multiplication")]
    [TestCase("Division")]
    [TestCase("Mixed")]
    [TestCase("Records")]
    public void ValidateMenuOption_ShallReturnTrue_IfGivenStringIsValidEnumOption(string input)
    {
        var result = _cut.ValidateMenuOption(input);
        Assert.That(result, Is.True);
    }
    [TestCase("Su")]
    [TestCase("Hello")]
    [TestCase("Multi")]
    [TestCase("Div")]
    [TestCase("Mi")]
    [TestCase("aaaaa")]
    public void ValidateMenuOption_ShallReturnFalse_IfGivenStringIsNotValidEnumOption(string input)
    {
        var result = _cut.ValidateMenuOption(input);
        Assert.That(result, Is.False);
    }
    [TestCase("Easy")]
    [TestCase("Medium")]
    [TestCase("Hard")]
    [TestCase("Random")]
    public void ValidateDifficulty_ShallReturnTrue_IfGivenStringIsValidEnumOption(string input)
    {
        var result = _cut.ValidateDifficulty(input);
        Assert.That(result, Is.True);
    }
    [TestCase("Ez")]
    [TestCase("Mid")]
    [TestCase("Hardcore")]
    [TestCase("Rando")]
    public void ValidateDifficulty_ShallReturnFalse_IfGivenStringIsNotValidEnumOption(string input)
    {
        var result = _cut.ValidateDifficulty(input);
        Assert.That(result, Is.False);
    }
}
