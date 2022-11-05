namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static string CatMouse(string x)
    {
        return Math.Abs(x.IndexOf('C') - x.IndexOf('m')) < 5
            ? "Caught!"
            : "Escaped!";
    }
}

[TestFixture]
public class CatMouseTests
{
    [TestCase("C....m", ExpectedResult = "Escaped!")]
    [TestCase("C..m", ExpectedResult = "Caught!")]
    [TestCase("C.....m", ExpectedResult = "Escaped!")]
    public string CatMouse(string x)
    {
        return Kata.CatMouse(x);
    }
}