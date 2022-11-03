namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int GetVowelCount(string str)
    {
        return str.Count(x => new[] { 'a', 'e', 'i', 'o', 'u' }.Contains(x));
    }
}

[TestFixture]
public partial class KataTests
{
    [Test]
    public void GetVowelCount()
    {
        Assert.That(Kata.GetVowelCount("abracadabra"), Is.EqualTo(5), "Nope!");
    }
}