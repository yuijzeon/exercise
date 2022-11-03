namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
    {
        throw new NotImplementedException();
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