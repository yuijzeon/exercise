namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static bool Xo(string input)
    {
        return input.ToLower().Count(x => x == 'x') == input.ToLower().Count(x => x == 'o');
    }
}

[TestFixture]
public partial class KataTests
{
    [TestCase("xo", ExpectedResult = true)]
    [TestCase("xxOo", ExpectedResult = true)]
    [TestCase("xxxm", ExpectedResult = false)]
    [TestCase("Oo", ExpectedResult = false)]
    [TestCase("ooom", ExpectedResult = false)]
    public bool Xo(string input)
    {
        return Kata.Xo(input);
    }
}