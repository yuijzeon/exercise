namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var list = new List<IList<int>>();

        foreach (var (num1, i) in nums.Select((num1, i) => (num1, i)))
        {
            foreach (var (num2, j) in nums[(i + 1)..].Select((num2, j) => (num2, j)))
            {
                if (nums[(i + j + 2)..].All(num3 => num1 + num2 + num3 != 0))
                {
                    continue;
                }

                if (!list.Any(x => x.SequenceEqual(new[] { num1, num2, -num1 - num2 })))
                {
                    list.Add(new List<int> { num1, num2, -num1 - num2 });
                }
            }
        }

        throw new Exception("LeetCode::Time Limit Exceeded");
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
                .Returns(new List<List<int>> { new() { -1, -1, 2 }, new() { -1, 0, 1 } });

            yield return new TestCaseData(new[] { 0, 1, 1 })
                .Returns(Array.Empty<IList<int>>());

            yield return new TestCaseData(new[] { 0, 0, 0 })
                .Returns(new List<List<int>> { new() { 0, 0, 0 } });
        }
    }
}