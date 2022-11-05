namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int MaxDiffLength(string[] a1, string[] a2)
    {
        return a1.Length == 0 || a2.Length == 0
            ? -1
            : Math.Max(
                Math.Abs(a1.OrderBy(s => s.Length).First().Length - a2.OrderByDescending(s => s.Length).First().Length),
                Math.Abs(a1.OrderByDescending(s => s.Length).First().Length - a2.OrderBy(s => s.Length).First().Length)
            );
    }
}

[TestFixture]
public class MaxDiffLengthTests
{
    [TestCase(new[] { "hoqq", "bbllkw", "oox", "ejjuyyy", "plmiis", "xxxzgpsssa", "xxwwkktt", "znnnnfqknaz", "qqquuhii", "dvvvwz" },
        new[] { "cccooommaaqqoxii", "gggqaffhhh", "tttoowwwmmww" }, ExpectedResult = 13)]
    public int MaxDiffLength(string[] a1, string[] a2)
    {
        return Kata.MaxDiffLength(a1, a2);
    }
}