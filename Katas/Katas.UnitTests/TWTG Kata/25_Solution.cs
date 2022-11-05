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
public class SolutionTests
{
    [TestCase(10, ExpectedResult = 23)]
    public int Solution(int value)
    {
        return Kata.Solution(10);
    }
}