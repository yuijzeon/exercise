namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static string ReverseWords(string str)
    {
        return string.Join(" ", str.Split(" ").Select(x => string.Join("", x.ToCharArray().Reverse())));
    }
}

[TestFixture]
public partial class KataTests
{
    [Test]
    public void ReverseWords()
    {
        Assert.That(Kata.ReverseWords("This is an example!"), Is.EqualTo("sihT si na !elpmaxe"));
    }
}