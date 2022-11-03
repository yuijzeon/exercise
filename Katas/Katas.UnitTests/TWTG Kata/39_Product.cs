namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int Product(int[] values)
    {
        return values.Aggregate((a, b) => a * b);
    }
}

[TestFixture]
public partial class KataTests
{
    [TestCase(new[] { 5, 4, 1, 3, 9 }, ExpectedResult = 540)]
    [TestCase(new[] { -2, 6, 7, 8 }, ExpectedResult = -672)]
    [TestCase(new[] { 10 }, ExpectedResult = 10)]
    [TestCase(new[] { 0, 2, 9, 7 }, ExpectedResult = 0)]
    public int Product(int[] values)
    {
        return Kata.Product(values);
    }
}