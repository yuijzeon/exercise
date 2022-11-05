namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    private static readonly string[] NumberMapping = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    public static string AverageString(string str)
    {
        try
        {
            var ints = str.Split(' ')
                .Select(digit => Array.IndexOf(NumberMapping, digit))
                .Select(index => index == -1
                    ? throw new Exception()
                    : index);

            return NumberMapping[(int)ints.Average()];
        }
        catch (Exception)
        {
            return "n/a";
        }
    }
}

[TestFixture]
public class AverageStringTests
{
    [TestCase("zero nine five two", ExpectedResult = "four")]
    [TestCase("four six two three", ExpectedResult = "three")]
    [TestCase("one two three four five", ExpectedResult = "three")]
    [TestCase("five four", ExpectedResult = "four")]
    [TestCase("zero zero zero zero zero", ExpectedResult = "zero")]
    [TestCase("one one eight one", ExpectedResult = "two")]
    [TestCase("", ExpectedResult = "n/a")]
    public string AverageString(string str)
    {
        return Kata.AverageString(str);
    }
}