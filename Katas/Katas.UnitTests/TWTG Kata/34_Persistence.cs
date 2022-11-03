namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int Persistence(long n)
    {
        var count = 0;

        while (n > 9)
        {
            n = n.ToString().ToArray().Select(x => x - 48).Aggregate((a, b) => a * b);
            count++;
        }

        return count;
    }
}

[TestFixture]
public partial class KataTests
{
    [TestCase(39, ExpectedResult = 3)]
    [TestCase(4, ExpectedResult = 0)]
    [TestCase(25, ExpectedResult = 2)]
    [TestCase(999, ExpectedResult = 4)]
    public int Persistence(long n)
    {
        Console.WriteLine("****** Basic Tests");
        return Kata.Persistence(n);
    }
}