namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static string GetMiddle(string s)
    {
        return s.Substring((s.Length - 1) / 2, s.Length % 2 == 0
            ? 2
            : 1);
    }
}

[TestFixture]
public class GetMiddleTests
{
    [TestCase("test", ExpectedResult = "es")]
    [TestCase("testing", ExpectedResult = "t")]
    [TestCase("middle", ExpectedResult = "dd")]
    [TestCase("A", ExpectedResult = "A")]
    public string GetMiddle(string s)
    {
        return Kata.GetMiddle(s);
    }
}