namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static string RomanConvert(int n)
    {
        var result = "";

        result +=
            n / 1000 % 10 == 1
                ? "M"
                : n / 1000 % 10 == 2
                    ? "MM"
                    : n / 1000 % 10 == 3
                        ? "MMM"
                        : "";

        result +=
            n / 100 % 10 == 1
                ? "C"
                : n / 100 % 10 == 2
                    ? "CC"
                    : n / 100 % 10 == 3
                        ? "CCC"
                        : n / 100 % 10 == 4
                            ? "CD"
                            : n / 100 % 10 == 5
                                ? "D"
                                : n / 100 % 10 == 6
                                    ? "DC"
                                    : n / 100 % 10 == 7
                                        ? "DCC"
                                        : n / 100 % 10 == 8
                                            ? "DCCC"
                                            : n / 100 % 10 == 9
                                                ? "CM"
                                                : "";

        result +=
            n / 10 % 10 == 1
                ? "X"
                : n / 10 % 10 == 2
                    ? "XX"
                    : n / 10 % 10 == 3
                        ? "XXX"
                        : n / 10 % 10 == 4
                            ? "XL"
                            : n / 10 % 10 == 5
                                ? "L"
                                : n / 10 % 10 == 6
                                    ? "LX"
                                    : n / 10 % 10 == 7
                                        ? "LXX"
                                        : n / 10 % 10 == 8
                                            ? "LXXX"
                                            : n / 10 % 10 == 9
                                                ? "XC"
                                                : "";

        result +=
            n % 10 == 1
                ? "I"
                : n % 10 == 2
                    ? "II"
                    : n % 10 == 3
                        ? "III"
                        : n % 10 == 4
                            ? "IV"
                            : n % 10 == 5
                                ? "V"
                                : n % 10 == 6
                                    ? "VI"
                                    : n % 10 == 7
                                        ? "VII"
                                        : n % 10 == 8
                                            ? "VIII"
                                            : n % 10 == 9
                                                ? "IX"
                                                : "";

        return result;
    }
}

[TestFixture]
public partial class KataTests
{
    [TestCase(1, ExpectedResult = "I")]
    [TestCase(2, ExpectedResult = "II")]
    [TestCase(4, ExpectedResult = "IV")]
    [TestCase(500, ExpectedResult = "D")]
    [TestCase(1000, ExpectedResult = "M")]
    [TestCase(1954, ExpectedResult = "MCMLIV")]
    [TestCase(1990, ExpectedResult = "MCMXC")]
    [TestCase(2008, ExpectedResult = "MMVIII")]
    [TestCase(2014, ExpectedResult = "MMXIV")]
    public string RomanConvert(int n)
    {
        return Kata.RomanConvert(n);
    }
}