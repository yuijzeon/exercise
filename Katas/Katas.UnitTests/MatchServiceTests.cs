using Katas.MatchAggregate;

namespace Katas.UnitTests;

[TestFixture]
public class MatchServiceTests
{
    private const int AnyMatchId = 1;
    private IMatchRepository _matchRepository = null!;
    private MatchService _matchService = null!;

    [SetUp]
    public void SetUp()
    {
        _matchRepository = Substitute.For<IMatchRepository>();
        _matchService = new MatchService(_matchRepository);
    }

    [TestCase(1, "", "H")]
    [TestCase(1, ";", "H", TestName = "break need to remove")]
    [TestCase(2, "", ";H", TestName = "break need to add")]
    public void home_goal(int livePeriod, string before, string after)
    {
        GivenMatch(livePeriod, before);
        DoEvent(SoccerEvent.HomeGoal);
        AssertGoalRecord(after);
    }

    [TestCase(1, "", "A")]
    [TestCase(1, ";", "A", TestName = "break need to remove")]
    [TestCase(2, "", ";A", TestName = "break need to add")]
    public void away_goal(int livePeriod, string before, string after)
    {
        GivenMatch(livePeriod, before);
        DoEvent(SoccerEvent.AwayGoal);
        AssertGoalRecord(after);
    }

    [TestCase(1, "H", "")]
    [TestCase(1, "H;", "", TestName = "break need to remove")]
    [TestCase(2, "H;", ";", TestName = "cancel previous half goal")]
    [TestCase(2, "H", ";", TestName = "break need to add")]
    public void home_cancel_success(int livePeriod, string before, string after)
    {
        GivenMatch(livePeriod, before);
        DoEvent(SoccerEvent.HomeCancel);
        AssertGoalRecord(after);
    }

    [TestCase(1, "A", "")]
    [TestCase(1, "A;", "", TestName = "break need to remove")]
    [TestCase(2, "A;", ";", TestName = "cancel previous half goal")]
    [TestCase(2, "A", ";", TestName = "break need to add")]
    public void away_cancel_success(int livePeriod, string before, string after)
    {
        GivenMatch(livePeriod, before);
        DoEvent(SoccerEvent.AwayCancel);
        AssertGoalRecord(after);
    }

    [TestCase(1, "", TestName = "no any team goal")]
    [TestCase(1, "A", TestName = "last goal from away")]
    [TestCase(2, ";", TestName = "no any team goal")]
    [TestCase(2, "A;", TestName = "last goal from away")]
    public void home_cancel_fail(int livePeriod, string before)
    {
        GivenMatch(livePeriod, before);
        Assert.Throws<Exception>(() => DoEvent(SoccerEvent.HomeCancel));
    }

    [TestCase(1, "", TestName = "no any team goal")]
    [TestCase(1, "H", TestName = "last goal from home")]
    [TestCase(2, ";", TestName = "no any team goal")]
    [TestCase(2, "H;", TestName = "last goal from home")]
    public void away_cancel_fail(int livePeriod, string before)
    {
        GivenMatch(livePeriod, before);
        Assert.Throws<Exception>(() => DoEvent(SoccerEvent.AwayCancel));
    }

    private void DoEvent(SoccerEvent soccerEvent)
    {
        _matchService.UpdateGoalRecord(AnyMatchId, soccerEvent);
    }

    private void AssertGoalRecord(string goalRecord)
    {
        _matchRepository.Received().UpdateGoalRecord(Arg.Is<Match>(match => match.GoalRecord == goalRecord));
    }

    private void GivenMatch(int livePeriod, string goalRecord)
    {
        _matchRepository.GetMatch(AnyMatchId).Returns(new Match
        {
            Id = AnyMatchId,
            LivePeriod = livePeriod,
            GoalRecord = goalRecord
        });
    }
}