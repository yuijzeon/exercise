namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static string[] Escape(int[,] carPark)
    {
        var ints = new int[,] { { 1 }, { 2 } };
        throw new NotImplementedException();
    }
}

[TestFixture]
public partial class KataTests
{
    [Test, TestCaseSource(nameof(Kata19Cases))]
    public string[] Escape(int[,] carPark) => Kata.Escape(carPark);

    private static IEnumerable<TestCaseData> Kata19Cases
    {
        get
        {
            yield return new TestCaseData(new[,] { { 1, 0, 0, 0, 2 }, { 0, 0, 0, 0, 0 } }).Returns(new[] { "L4", "D1", "R4" });

            yield return new TestCaseData(new[,]
            {
                { 2, 0, 0, 1, 0 },
                { 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0 }
            }).Returns(new[] { "R3", "D2", "R1" });

            yield return new TestCaseData(new[,]
            {
                { 0, 2, 0, 0, 1 },
                { 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0 }
            }).Returns(new[] { "R3", "D3" });

            yield return new TestCaseData(new[,]
            {
                { 1, 0, 0, 0, 2 },
                { 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            }).Returns(new[] { "L4", "D1", "R4", "D1", "L4", "D1", "R4" });

            yield return new TestCaseData(new[,]
            {
                { 0, 0, 0, 0, 2 }
            }).Returns(Array.Empty<object>());
        }
    }
}