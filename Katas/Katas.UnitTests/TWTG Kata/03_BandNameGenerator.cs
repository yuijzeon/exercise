namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static string BandNameGenerator(string str)
    {
        return str[0] == str[^1]
            ? char.ToUpper(str[0]) + str[1..] + str[1..]
            : $"The {char.ToUpper(str[0]) + str[1..]}";
    }
}

[TestFixture]
public partial class KataTests
{
    [TestCase("knife", ExpectedResult = "The Knife")]
    [TestCase("tart", ExpectedResult = "Tartart")]
    [TestCase("sandles", ExpectedResult = "Sandlesandles")]
    [TestCase("bed", ExpectedResult = "The Bed")]
    public string BandNameGenerator(string str)
    {
        return Kata.BandNameGenerator(str);
    }
}