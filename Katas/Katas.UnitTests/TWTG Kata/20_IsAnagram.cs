namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static bool IsAnagram(string test, string original)
    {
        return original.ToLower().GroupBy(x => x).Select(g => test.ToLower().Count(x => x == g.Key) == g.Count()).All(x => x);
    }
}

[TestFixture]
public partial class KataTests
{
    [TestCase("foefet", "toffee", ExpectedResult = true)]
    [TestCase("Buckethead", "DeathCubeK", ExpectedResult = true)]
    [TestCase("Twoo", "Woot", ExpectedResult = true)]
    [TestCase("apple", "pale", ExpectedResult = false)]
    public bool IsAnagram(string test, string original)
    {
        return Kata.IsAnagram(test, original);
    }
}