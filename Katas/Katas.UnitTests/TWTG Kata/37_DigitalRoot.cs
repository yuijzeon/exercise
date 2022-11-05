namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int DigitalRoot(long n)
    {
        var r = n;

        while (r > 9)
        {
            r = r.ToString().Select(o => Convert.ToInt32(o) - 48).ToArray().Sum();
        }

        return (int)r;
    }
}

[TestFixture]
public class DigitalRootTests
{
    [TestCase(16, ExpectedResult = 7)]
    [TestCase(456, ExpectedResult = 6)]
    public int DigitalRoot(long n)
    {
        return Kata.DigitalRoot(n);
    }
}