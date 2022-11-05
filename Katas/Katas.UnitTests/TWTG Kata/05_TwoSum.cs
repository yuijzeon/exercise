namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int[] TwoSum(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new[] { i, j };
                }
            }
        }

        return Array.Empty<int>();
    }
}

[TestFixture]
public class TwoSumTests
{
    [TestCase(new[] { 2, 7, 11, 15 }, 9, ExpectedResult = new[] { 0, 1 })]
    [TestCase(new[] { 3, 2, 4 }, 6, ExpectedResult = new[] { 1, 2 })]
    [TestCase(new[] { 3, 3 }, 6, ExpectedResult = new[] { 0, 1 })]
    public int[] TwoSum(int[] nums, int target)
    {
        return Kata.TwoSum(nums, target);
    }
}