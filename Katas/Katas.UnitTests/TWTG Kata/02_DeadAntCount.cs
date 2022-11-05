namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int DeadAntCount(string ants)
    {
        try
        {
            return ants.Replace("ant", "").GroupBy(x => x)
                .Where(x => x.Key is 'a' or 'n' or 't')
                .Max(x => x.Count());
        }
        catch (Exception)
        {
            return 0;
        }
    }
}

[TestFixture]
public class DeadAntCountTests
{
    [TestCase("ant ant ant ant", ExpectedResult = 0)]
    [TestCase(null, ExpectedResult = 0)]
    [TestCase("ant anantt aantnt", ExpectedResult = 2)]
    [TestCase("ant ant .... a nt", ExpectedResult = 1)]
    public int DeadAntCount(string ants)
    {
        return Kata.DeadAntCount(ants);
    }
}