using Domain.Models;
using Domain.Models.Enums;
using FluentAssertions;

namespace Tests.Unit.Domain;
public class UserDataTests
{
    [Test]
    [TestCase(0, 100)]
    [TestCase(100, 0)]
    [TestCase(-1, 50)]
    [TestCase(50, -1)]
    public void BmiShouldReturnZeroWhenUserDataIncomplete(decimal weight, decimal height)
    {
        UserData user = new()
        {
            Weight = weight,
            Height = height
        };

        user.Bmi.Should().Be(0);
    }

    [Test]
    [TestCase(0, 100, 20)]
    [TestCase(100, 0, 20)]
    [TestCase(100, 100, 0)]
    [TestCase(-1, 50, 20)]
    [TestCase(50, -1, 20)]
    [TestCase(50, 50, -1)]
    public void BmrShouldReturnZeroWhenUserDataIncomplete(decimal weight, decimal height, int age)
    {
        UserData user = new()
        {
            Weight = weight,
            Height = height,
            Age = age
        };

        user.Bmr.Should().Be(0);
    }

    [Test]
    public void BmiShouldReturncorrectvalueWhenUserDataCorrect()
    {
        UserData user = new()
        {
            Weight = 70,
            Height = 170
        };

        // Weight / (Height / 100 * Height / 100);
        Math.Round(user.Bmi, 2).Should().Be(24.22m);
    }

    [Test]
    [TestCase(Gender.Male, 1672.5d)]
    [TestCase(Gender.Female, 1506.5d)]
    public void BrmShouldReturnCorrectvalueWhenUserDataCorect(Gender gender, decimal expected)
    {
        UserData user = new()
        {
            Weight = 73,
            Height = 170,
            Age = 25,
            Gender = gender
        };

        // male : 10 * Weight + 6.25m * Height - 5 * Age + 5; 
        // female : 10 * Weight + 6.25m * Height - 5 * Age - 161;
        Math.Round(user.Bmr, 2).Should().Be(expected);
    }


}