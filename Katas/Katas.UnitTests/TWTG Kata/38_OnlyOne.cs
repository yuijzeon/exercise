namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static bool OnlyOne(params bool[] flags)
    {
        return flags.Count(b => b) == 1;
    }
}

[TestFixture]
public partial class KataTests
{
    [Test]
    public void OnlyOne()
    {
        Assert.That(Kata.OnlyOne(true, false), Is.EqualTo(true));
    }
}