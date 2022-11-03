namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int Find(int[] integers)
    {
        return integers.Count(i => i % 2 == 0) == 1
            ? integers.First(i => i % 2 == 0)
            : integers.First(i => i % 2 == 1);
    }
}

[TestFixture]
public partial class KataTests
{
    [TestCase(new[] { 2, 6, 8, -10, 3 }, ExpectedResult = 3)]
    [TestCase(new[] { 206847684, 1056521, 7, 17, 1901, 21104421, 7, 1, 35521, 1, 7781 }, ExpectedResult = 206847684)]
    [TestCase(new[] { int.MaxValue, 0, 1 }, ExpectedResult = 0)]
    public int Find(int[] integers)
    {
        return Kata.Find(integers);
    }
}