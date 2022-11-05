namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int CountCombinations(int money, int[] coins)
    {
        if (money == 0)
        {
            return 1;
        }

        var result = 0;
        var coinList = coins.OrderByDescending(x => x).ToList();

        foreach (var coin in coins.OrderByDescending(x => x))
        {
            coinList.RemoveAt(0);

            for (var i = 1; i <= money / coin; i++)
            {
                result += CountCombinations(money - i * coin, coinList.ToArray());
            }
        }

        return result;
    }
}

[TestFixture]
public class CountCombinationsTests
{
    [TestCase(4, new[] { 1, 2 }, ExpectedResult = 3)]
    [TestCase(10, new[] { 5, 2, 3 }, ExpectedResult = 4)]
    [TestCase(11, new[] { 5, 7 }, ExpectedResult = 0)]
    public int CountCombinations(int money, int[] coins)
    {
        return Kata.CountCombinations(money, coins);
    }
}