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
public partial class KataTests
{
    [TestCase("zero nine five two", "four")]
    [TestCase("four six two three", "three")]
    [TestCase("one two three four five", "three")]
    [TestCase("five four", "four")]
    [TestCase("zero zero zero zero zero", "zero")]
    [TestCase("one one eight one", "two")]
    [TestCase("", "n/a")]
    public void AverageString(string str, string expected)
    {
        Assert.That(Kata.AverageString(str), Is.EqualTo(expected));
    }
}