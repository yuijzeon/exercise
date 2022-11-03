namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static string SumStrings(string a, string b)
    {
        var arrA = a.Reverse().Select(x => int.Parse(x.ToString()));
        var arrB = b.Reverse().Select(x => int.Parse(x.ToString()));
        var result = new List<int>();
        var temp = 0;

        foreach (var g in arrA.Zip(arrB))
        {
            result.Add((g.First + g.Second) + temp);
            temp = (g.First + g.Second) / 10;
        }

        result.Reverse();
        return string.Join("", result);
    }
}

[TestFixture]
public partial class KataTests
{
    [TestCase("1", "2", ExpectedResult = "3")]
    [TestCase("123", "456", ExpectedResult = "579")]
    public string SumStrings(string a, string b)
    {
        return Kata.SumStrings(a, b);
    }
}