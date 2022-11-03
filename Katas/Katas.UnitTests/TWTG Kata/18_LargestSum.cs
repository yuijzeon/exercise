namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int LargestSum(int[] arr)
    {
        int result = 0,
            temp = 0;

        foreach (var i in arr)
        {
            temp += i;

            if (result < temp)
            {
                result = temp;
            }

            if (temp < 0)
            {
                temp = 0;
            }
        }

        return result;
    }
}

[TestFixture]
public partial class KataTests
{
    [TestCase(new[] { -1, -2, -3 }, ExpectedResult = 0)]
    [TestCase(new[] { 0 }, ExpectedResult = 0)]
    [TestCase(new[] { 1, 2, 3, 4 }, ExpectedResult = 10)]
    [TestCase(new[] { 31, -41, 59, 26, -53, 58, 97, -93, -23, 84 }, ExpectedResult = 187)]
    public int LargestSum(int[] arr)
    {
        return Kata.LargestSum(arr);
    }
}