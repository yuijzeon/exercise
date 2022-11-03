namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int[] SortArray(int[] array)
    {
        var odds = new Queue<int>(array.Where(x => x % 2 == 1).OrderBy(e => e));

        return array.Select(e => e % 2 == 1
            ? odds.Dequeue()
            : e).ToArray();
    }
}

[TestFixture]
public partial class KataTests
{
    [TestCase(new[] { 5, 3, 2, 8, 1, 4 }, ExpectedResult = new[] { 1, 3, 2, 8, 5, 4 })]
    [TestCase(new[] { 5, 3, 1, 8, 0 }, ExpectedResult = new[] { 1, 3, 5, 8, 0 })]
    [TestCase(new int[] { }, ExpectedResult = new int[] { })]
    public int[] SortArray(int[] array)
    {
        return Kata.SortArray(array);
    }
}