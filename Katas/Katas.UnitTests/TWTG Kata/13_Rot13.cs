namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static string Rot13(string input)
    {
        var convertor = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
            .Zip("NOPQRSTUVWXYZABCDEFGHIJKLMnopqrstuvwxyzabcdefghijklm");

        return string.Join("", input.Select(x =>
        {
            return convertor.Any(c => c.First == x)
                ? convertor.First(c => c.Second == x).First
                : x;
        }));
    }
}

[TestFixture]
public partial class KataTests
{
    [TestCase("EBG13 rknzcyr.", ExpectedResult = "ROT13 example.")]
    [TestCase("This is my first ROT13 excercise!", ExpectedResult = "Guvf vf zl svefg EBG13 rkprepvfr!")]
    public string Rot13(string input)
    {
        return Kata.Rot13(input);
    }
}