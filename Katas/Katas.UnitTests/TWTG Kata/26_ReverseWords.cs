namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static string ReverseWords(string str)
    {
        return string.Join(" ", str.Split(" ").Select(x => string.Join("", x.ToCharArray().Reverse())));
    }
}

[TestFixture]
public class ReverseWordsTests
{
    [TestCase("This is an example!", ExpectedResult = "sihT si na !elpmaxe")]
    public string ReverseWords(string str)
    {
        return Kata.ReverseWords(str);
    }
}