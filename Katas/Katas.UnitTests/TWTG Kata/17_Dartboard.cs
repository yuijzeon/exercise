namespace Katas.UnitTests.TWTG_Kata;

public class Dartboard
{
    public string GetScore(double x, double y)
    {
        var radius = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        var theta = Math.Atan2(y, x);

        if (theta < 0)
        {
            theta += 2 * Math.PI;
        }

        var place = (int)(theta / (Math.PI / 20));

        var score = new[]
        {
            6, 13, 13, 4, 4, 18, 18, 1, 1, 20, 20, 5, 5, 12, 12, 9, 9, 14, 14, 11,
            11, 8, 8, 16, 16, 7, 7, 19, 19, 3, 3, 17, 17, 2, 2, 15, 15, 10, 10, 6
        };

        return radius < 6.35
            ? "DB"
            : radius < 15.9
                ? "SB"
                : radius < 99
                    ? $"{score[place]}"
                    : radius < 107
                        ? $"T{score[place]}"
                        : radius < 162
                            ? $"{score[place]}"
                            : radius < 170
                                ? $"D{score[place]}"
                                : "X";
    }
}

[TestFixture]
public class DartboardTests
{
    [TestCase(-133.69, -147.38, ExpectedResult = "X")]
    [TestCase(4.06, 0.71, ExpectedResult = "DB")]
    [TestCase(2.38, -6.06, ExpectedResult = "SB")]
    [TestCase(-5.43, 117.95, ExpectedResult = "20")]
    [TestCase(-73.905, -95.94, ExpectedResult = "7")]
    [TestCase(55.53, -87.95, ExpectedResult = "T2")]
    [TestCase(-145.19, 86.53, ExpectedResult = "D9")]
    public string GetScoreTest(double x, double y)
    {
        var dartboard = new Dartboard();
        return dartboard.GetScore(x, y);
    }
}