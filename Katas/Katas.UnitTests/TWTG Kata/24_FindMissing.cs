namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int FindMissing(List<int> list)
    {
        var difference = Math.Min(list[2] - list[1], list[1] - list[0]);

        for (var i = 1; i < list.Count; i++)
        {
            if (list[i] - list[i - 1] != difference)
            {
                return (list[i] + list[i - 1]) / 2;
            }
        }

        return -1;
    }
}

[TestFixture]
public partial class KataTests
{
    [Test, TestCaseSource(nameof(Kata24Cases))]
    public int FindMissing(List<int> list) => Kata.FindMissing(list);

    private static IEnumerable<TestCaseData> Kata24Cases
    {
        get
        {
            yield return new TestCaseData(new[] { new List<int> { 1, 3, 5, 9, 11 } }).Returns(7);
            yield return new TestCaseData(new[] { new List<int> { 0, 5, 10, 20, 25 } }).Returns(15);
            yield return new TestCaseData(new[] { new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 } }).Returns(10);
            yield return new TestCaseData(new[] { new List<int> { 1040, 1220, 1580 } }).Returns(1400);
        }
    }
}