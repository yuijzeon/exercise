namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static long NextBiggerNumber(long n)
    {
        var result = n.ToString().Select(Convert.ToInt32).ToArray();
        Console.Write(result);
        return -1;
    }
}

[TestFixture]
public partial class KataTests
{
    [TestCase(12, ExpectedResult = 21)]
    [TestCase(513, ExpectedResult = 531)]
    [TestCase(2017, ExpectedResult = 2071)]
    [TestCase(414, ExpectedResult = 441)]
    [TestCase(144, ExpectedResult = 414)]
    public long NextBiggerNumber(int n)
    {
        Console.WriteLine("****** Small Number");
        return Kata.NextBiggerNumber(n);
    }
}