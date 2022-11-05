namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < Math.Min(i + indexDiff + 1, nums.Length); j++)
            {
                if (Math.Abs(nums[j] - nums[i]) <= valueDiff)
                {
                    return true;
                }
            }
        }

        return false;
    }
}

[TestFixture]
public partial class KataTests
{
    [TestCase(new[] { 1, 2, 3, 1 }, 3, 0, ExpectedResult = true)]
    [TestCase(new[] { 1, 5, 9, 1, 5, 9 }, 2, 3, ExpectedResult = false)]
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
    {
        return Kata.ContainsNearbyAlmostDuplicate(nums, indexDiff, valueDiff);
    }
}