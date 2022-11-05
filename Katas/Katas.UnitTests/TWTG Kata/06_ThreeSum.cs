namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var list = new List<IList<int>>();

        for (var idx1 = 0; idx1 < nums.Length - 2; idx1++)
        {
            var idx2 = idx1 + 1;
            var idx3 = nums.Length - 1;

            while (idx2 < idx3)
            {
                if (nums[idx2] + nums[idx3] < -nums[idx1])
                {
                    idx2++;
                }
                else if (nums[idx2] + nums[idx3] > -nums[idx1])
                {
                    idx3--;
                }
                else
                {
                    var solution = new List<int> { nums[idx1], nums[idx2], nums[idx3] };
                    list.Add(solution);
                    while (idx2 + 1 < idx3 && nums[idx2 + 1] == solution[1]) idx2++;
                    while (idx2 < idx3 - 1 && nums[idx3 - 1] == solution[2]) idx3--;
                    idx2++;
                }
            }
            var current = nums[idx1];
            while (idx1 + 1 < nums.Length - 2 && nums[idx1 + 1] == current) idx1++;
        }

        return list;
    }
}

[TestFixture]
public partial class KataTests
{
    [Test, TestCaseSource(nameof(Kata6Cases))]
    public IList<IList<int>> ThreeSum(int[] nums) => Kata.ThreeSum(nums);

    private static IEnumerable<TestCaseData> Kata6Cases
    {
        get
        {
            yield return new TestCaseData(new[] { -1, 0, 1, 2, -1, -4 })
                .Returns(new List<List<int>> { new() { -1, -1, 2 }, new() { -1, 0, 1 } });

            yield return new TestCaseData(new[] { 0, 1, 1 })
                .Returns(Array.Empty<IList<int>>());

            yield return new TestCaseData(new[] { 0, 0, 0 })
                .Returns(new List<List<int>> { new() { 0, 0, 0 } });

            yield return new TestCaseData(new[] { -2, 0, 1, 1, 2 })
                .Returns(new List<List<int>> { new() { -2, 0, 2 }, new() { -2, 1, 1 } });
        }
    }
}