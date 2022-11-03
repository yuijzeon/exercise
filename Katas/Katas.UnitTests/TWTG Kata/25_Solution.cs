namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int Solution(int value)
    {
        return value < 1
            ? 0
            : Enumerable.Range(1, value - 1).Where(x => x % 3 == 0 || x % 5 == 0).Aggregate((a, b) => a + b);
    }
}

[TestFixture]
public partial class KataTests
{
    [Test]
    public void Solution()
    {
        Assert.That(Kata.Solution(10), Is.EqualTo(23));
    }
}