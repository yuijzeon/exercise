namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        var list = new List<IList<int>>();

        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                for (var k = j + 1; k < nums.Length; k++)
                {
                    if (nums[i] + nums[j] + nums[k] != 0)
                    {
                        continue;
                    }

                    var orderedEnumerable = new[] { nums[i], nums[j], nums[k] }.OrderBy(x => x).ToList();

                    if (!list.Any(x => x[0] == orderedEnumerable[0] && x[1] == orderedEnumerable[1] && x[2] == orderedEnumerable[2]))
                    {
                        list.Add(orderedEnumerable);
                    }
                }
            }
        }

        throw new NotImplementedException("Big Data Timeout");

        //return list;
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
                .Returns(new List<List<int>> { new() { -1, 0, 1 }, new() { -1, -1, 2 } });

            yield return new TestCaseData(new[] { 0, 1, 1 })
                .Returns(Array.Empty<IList<int>>());

            yield return new TestCaseData(new[] { 0, 0, 0 })
                .Returns(new List<List<int>> { new() { 0, 0, 0 } });
        }
    }
}