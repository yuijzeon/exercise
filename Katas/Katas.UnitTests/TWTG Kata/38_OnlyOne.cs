namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static bool OnlyOne(params bool[] flags)
    {
        return flags.Count(b => b) == 1;
    }
}

[TestFixture]
public class OnlyOneTests
{
    [TestCase(true, false, ExpectedResult = true)]
    public bool OnlyOne(params bool[] flags)
    {
        return Kata.OnlyOne(true, false);
    }
}