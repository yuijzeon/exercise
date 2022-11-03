namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int FindIt(int[] seq)
    {
        return seq.First(x => seq.Count(y => y == x) % 2 == 1);
    }
}

[TestFixture]
public partial class KataTests
{
    [Test]
    public void FindIt()
    {
        Assert.That(Kata.FindIt(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }), Is.EqualTo(5));
    }
}