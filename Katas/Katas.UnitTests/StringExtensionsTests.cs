using System.Text.RegularExpressions;

namespace Katas.UnitTests;

public static class StringExtensions
{
    public static string JoinCamel(this string value, string separator = " ")
    {
        return Regex.Replace(value, @"(?<=[\da-z])(?=[A-Z])|(?<=[a-z])(?=[\dA-Z])", separator);
    }
}

[TestFixture]
public class StringExtensionsTests
{
    [TestCase("Case123Tests", ExpectedResult = "Case 123 Tests")]
    public string JoinCamel(string value, string separator = " ")
    {
        return value.JoinCamel(separator);
    }
}