namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int GetVowelCount(string str)
    {
        return str.Count(x => new[] { 'a', 'e', 'i', 'o', 'u' }.Contains(x));
    }
}

[TestFixture]
public class GetVowelCountTests
{
    [TestCase("abracadabra", ExpectedResult = 5, Description = "Nope!")]
    public int GetVowelCount(string str)
    {
        return Kata.GetVowelCount("abracadabra");
    }
}