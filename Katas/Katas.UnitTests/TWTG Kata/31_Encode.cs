namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static int[] Encode(string str, int n)
    {
        return str.Select((num, idx) => new { num, idx }).Select(x => x.num - 96 + Convert.ToInt32(n.ToString()[x.idx % n.ToString().Length].ToString())).ToArray();
    }
}

[TestFixture]
public class EncodeTests
{
    [TestCase("scout", 1939, ExpectedResult = new[] { 20, 12, 18, 30, 21 })]
    [TestCase("masterpiece", 1939, ExpectedResult = new[] { 14, 10, 22, 29, 6, 27, 19, 18, 6, 12, 8 })]
    public int[] Encode(string str, int n)
    {
        return Kata.Encode(str, n);
    }
}