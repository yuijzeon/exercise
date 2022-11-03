namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int DuplicateCount(string str)
    {
        return str.ToLower().GroupBy(x => x).Count(x => x.Count() > 1);
    }
}

[TestFixture]
public partial class KataTests
{
    [TestCase("", ExpectedResult = 0)]
    [TestCase("abcde", ExpectedResult = 0)]
    [TestCase("aabbcde", ExpectedResult = 2)]
    [TestCase("aabBcde", ExpectedResult = 2, Description = "should ignore case")]
    [TestCase("Indivisibility", ExpectedResult = 1)]
    [TestCase("Indivisibilities", ExpectedResult = 2, Description = "characters may not be adjacent")]
    public int DuplicateCount(string str, string? message = null)
    {
        return Kata.DuplicateCount(str);
    }
}