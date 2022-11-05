namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static IEnumerable<int> PascalsTriangle(int n)
    {
        var result = new List<int>();

        for (var i = 1; i <= n; i++)
        {
            for (var j = 1; j <= i; j++)
            {
                if (j == 1 || j == i)
                {
                    result.Add(1);
                }
                else
                {
                    result.Add(result[(i - 1) * (i - 2) / 2 + (j - 2)] + result[(i - 1) * (i - 2) / 2 + (j - 1)]);
                }
            }
        }

        return result;
    }
}

[TestFixture]
public class PascalsTriangleTests
{
    [TestCase(1, ExpectedResult = new[] { 1 })]
    [TestCase(2, ExpectedResult = new[] { 1, 1, 1 })]
    [TestCase(4, ExpectedResult = new[] { 1, 1, 1, 1, 2, 1, 1, 3, 3, 1 })]
    public IEnumerable<int> PascalsTriangle(int n)
    {
        return Kata.PascalsTriangle(n);
    }
}