namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static long NextSmaller(long n)
    {
        var array = n.ToString().Select(x => x).ToArray();

        for (var i = array.Length - 1; i > 0; i--)
        {
            var x = array[i];
            var y = array[i - 1];
            if (x >= y) continue;

            if (x == '0' && i == 1)
            {
                if (array[2] >= array[0]) continue;
                array[0] = array[2];
                array[2] = y;
                var result = long.Parse(string.Join("", array));
                return result;
            }

            array[i] = y;
            array[i - 1] = x;
            return long.Parse(string.Join("", array));
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