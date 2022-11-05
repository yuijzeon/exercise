namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static long NextBiggerNumber(long n)
    {
        var digits = n.ToString();

        for (var i = digits.Length - 2; i >= 0; i--)
        {
            if (digits[i] >= digits[i + 1])
            {
                continue;
            }

            var chars = digits[i..].OrderBy(x => x).ToList();

            for (var j = 0; j < chars.Count; j++)
            {
                if (digits[i] >= chars[j])
                {
                    continue;
                }

                chars.Insert(0, chars[j]);
                chars.RemoveAt(j + 1);
                return long.Parse(string.Join("", digits[..i] + string.Join("", chars)));
            }
        }

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