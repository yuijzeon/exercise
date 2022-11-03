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
public partial class KataTests
{
    [Test]
    public void MaxDiffLength()
    {
        string[] s1 = { "hoqq", "bbllkw", "oox", "ejjuyyy", "plmiis", "xxxzgpsssa", "xxwwkktt", "znnnnfqknaz", "qqquuhii", "dvvvwz" };
        string[] s2 = { "cccooommaaqqoxii", "gggqaffhhh", "tttoowwwmmww" };
        Assert.That(Kata.MaxDiffLength(s1, s2), Is.EqualTo(13));
    }
}