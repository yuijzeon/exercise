using System.Text.RegularExpressions;

namespace Katas.UnitTests;

public static class StringExtensions
{
    public static string JoinCamelCase(this string value, string separator)
    {
        return Regex.Replace(value, @"(?<=[a-z])\B(?=[A-Z])|(?<=\d)\B(?=\D)|(?<=\D)\B(?=\d)", separator);
    }
}

[TestFixture]
public class StringExtensionsTests
{
    [TestCase("11", " ", ExpectedResult = "11")]
    [TestCase("1a", " ", ExpectedResult = "1 a")]
    [TestCase("1A", " ", ExpectedResult = "1 A")]
    [TestCase("1-", " ", ExpectedResult = "1-")]
    [TestCase("_A", " ", ExpectedResult = "_A")]
    [TestCase("__", " ", ExpectedResult = "__")]
    [TestCase("_-", " ", ExpectedResult = "_-")]
    [TestCase("aa", " ", ExpectedResult = "aa")]
    [TestCase("Aa", " ", ExpectedResult = "Aa")]
    [TestCase("AA", " ", ExpectedResult = "AA")]
    [TestCase("aA", " ", ExpectedResult = "a A")]
    [TestCase("a1", " ", ExpectedResult = "a 1")]
    [TestCase("KCPay", " ", ExpectedResult = "KCPay")]
    public string JoinCamelCase(string value, string separator)
    {
        return value.JoinCamelCase(separator);
    }
}