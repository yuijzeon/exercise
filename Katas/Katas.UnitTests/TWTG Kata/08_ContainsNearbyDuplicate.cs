namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        var dictionary = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            dictionary.Add(i, nums[i]);
        }

        var groupBy = dictionary.GroupBy(x => x.Value);

        return groupBy
            .Any(x => x.Max(y => y.Key) - x.Min(y => y.Key) <= k);
    }
}

[TestFixture]
public class ContainsNearbyDuplicateTests
{
    [TestCase(new[] { 1, 2, 3, 1 }, 3, ExpectedResult = true)]
    [TestCase(new[] { 1, 0, 1, 1 }, 1, ExpectedResult = true)]
    [TestCase(new[] { 1, 2, 3, 1, 2, 3 }, 2, ExpectedResult = false)]
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        return Kata.ContainsNearbyDuplicate(nums, k);
    }
}