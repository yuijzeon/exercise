namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static long NextSmaller(long n)
    {
        var digits = n.ToString();

        for (var i = digits.Length - 2; i >= 0; i--)
        {
            if (digits[i] <= digits[i + 1])
            {
                continue;
            }

            var chars = digits[i..].OrderByDescending(x => x).ToList();

            for (var j = 0; j < chars.Count; j++)
            {
                if (digits[i] <= chars[j])
                {
                    continue;
                }

                chars.Insert(0, chars[j]);
                chars.RemoveAt(j + 1);
                digits = string.Join("", digits[..i] + string.Join("", chars));

                if (digits.First() != '0')
                {
                    return long.Parse(digits);
                }
            }
        }

        return -1;
    }
}

[TestFixture]
public partial class KataTests
{
    [TestCase(21, ExpectedResult = 12)]
    [TestCase(907, ExpectedResult = 790)]
    [TestCase(531, ExpectedResult = 513)]
    [TestCase(1027, ExpectedResult = -1)]
    [TestCase(441, ExpectedResult = 414)]
    [TestCase(123456798, ExpectedResult = 123456789)]
    public long NextSmaller(long n)
    {
        return Kata.NextSmaller(n);
    }
}