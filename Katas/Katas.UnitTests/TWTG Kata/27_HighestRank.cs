namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int HighestRank(IEnumerable<int> arr)
    {
        return arr.GroupBy(x => x).OrderByDescending(g => g.Key).ThenByDescending(g => g.Count()).First().Key;
    }
}

[TestFixture]
public partial class KataTests
{
    [Test]
    public void HighestRank()
    {
        var arr = new[] { 12, 10, 8, 12, 7, 6, 4, 10, 12 };
        Assert.That(Kata.HighestRank(arr), Is.EqualTo(12));
    }
}