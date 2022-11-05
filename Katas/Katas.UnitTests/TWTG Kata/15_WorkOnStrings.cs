namespace Katas.UnitTests.TWTG_Kata;

public static partial class Kata
{
    public static string WorkOnStrings(string a, string b)
    {
        var groupA = a.ToLower().GroupBy(x => x);
        var groupB = b.ToLower().GroupBy(x => x);

        a = groupB.Where(g => g.Count() % 2 == 1)
            .Aggregate(a, (current, g) => string.Join("", current.Select(x => (x == char.ToUpper(g.Key))
                ? g.Key
                : (x == g.Key)
                    ? char.ToUpper(g.Key)
                    : x)));

        b = groupA.Where(g => g.Count() % 2 == 1)
            .Aggregate(b, (current, g) => string.Join("", current.Select(x => (x == char.ToUpper(g.Key))
                ? g.Key
                : (x == g.Key)
                    ? char.ToUpper(g.Key)
                    : x)));

        return a + b;
    }
}

[TestFixture]
public class WorkOnStringsTests
{
    [TestCase("abc", "cde", ExpectedResult = "abCCde")]
    [TestCase("abab", "bababa", ExpectedResult = "ABABbababa")]
    [TestCase("abcdeFgtrzw", "defgGgfhjkwqe", ExpectedResult = "abcDeFGtrzWDEFGgGFhjkWqE")]
    [TestCase("abcdeFg", "defgG", ExpectedResult = "abcDEfgDEFGg")]
    public string WorkOnStrings(string a, string b)
    {
        return Kata.WorkOnStrings(a, b);
    }
}