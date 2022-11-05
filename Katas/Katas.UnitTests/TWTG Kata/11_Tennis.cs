using FluentAssertions;
using Katas.TennisAggregate;

namespace Katas.UnitTests.TWTG_Kata;

[TestFixture]
public class TennisTests
{
    private TennisGame _tennisGame = null!;

    [SetUp]
    public void Setup()
    {
        _tennisGame = new TennisGame(new TennisPlayer("Lara"), new TennisPlayer("Yuijuhn"));
    }

    [Test]
    public void scores_0v0_report_love_all()
    {
        _tennisGame.Report().Should().Be("Love All");
    }

    [Test]
    public void scores_1v0_report_fifteen_love()
    {
        _tennisGame.Player1.Scored(1);
        _tennisGame.Report().Should().Be("Fifteen Love");
    }

    [Test]
    public void scores_2v0_report_thirty_love()
    {
        _tennisGame.Player1.Scored(2);
        _tennisGame.Report().Should().Be("Thirty Love");
    }

    [Test]
    public void scores_3v0_report_forty_love()
    {
        _tennisGame.Player1.Scored(3);
        _tennisGame.Report().Should().Be("Forty Love");
    }

    [Test]
    public void scores_0v1_report_love_fifteen()
    {
        _tennisGame.Player2.Scored(1);
        _tennisGame.Report().Should().Be("Love Fifteen");
    }

    [Test]
    public void scores_0v2_report_love_thirty()
    {
        _tennisGame.Player2.Scored(2);
        _tennisGame.Report().Should().Be("Love Thirty");
    }

    [Test]
    public void scores_0v3_report_love_forty()
    {
        _tennisGame.Player2.Scored(3);
        _tennisGame.Report().Should().Be("Love Forty");
    }

    [Test]
    public void scores_1v1_report_fifteen_all()
    {
        _tennisGame.Player1.Scored(1);
        _tennisGame.Player2.Scored(1);
        _tennisGame.Report().Should().Be("Fifteen All");
    }

    [Test]
    public void scores_2v2_report_thirty_all()
    {
        _tennisGame.Player1.Scored(2);
        _tennisGame.Player2.Scored(2);
        _tennisGame.Report().Should().Be("Thirty All");
    }

    [Test]
    public void scores_3v3_report_deuce()
    {
        _tennisGame.Player1.Scored(3);
        _tennisGame.Player2.Scored(3);
        _tennisGame.Report().Should().Be("Deuce");
    }

    [Test]
    public void scores_4v4_report_deuce()
    {
        _tennisGame.Player1.Scored(4);
        _tennisGame.Player2.Scored(4);
        _tennisGame.Report().Should().Be("Deuce");
    }

    [Test]
    public void scores_4v3_report_player1_adv()
    {
        _tennisGame.Player1.Scored(4);
        _tennisGame.Player2.Scored(3);
        _tennisGame.Report().Should().Be($"{_tennisGame.Player1.Name} Adv");
    }

    [Test]
    public void scores_3v4_report_player2_adv()
    {
        _tennisGame.Player1.Scored(3);
        _tennisGame.Player2.Scored(4);
        _tennisGame.Report().Should().Be($"{_tennisGame.Player2.Name} Adv");
    }

    [Test]
    public void scores_5v3_report_player1_win()
    {
        _tennisGame.Player1.Scored(5);
        _tennisGame.Player2.Scored(3);
        _tennisGame.Report().Should().Be($"{_tennisGame.Player1.Name} Win");
    }

    [Test]
    public void scores_3v5_report_player1_win()
    {
        _tennisGame.Player1.Scored(3);
        _tennisGame.Player2.Scored(5);
        _tennisGame.Report().Should().Be($"{_tennisGame.Player2.Name} Win");
    }
}