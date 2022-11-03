using Katas.Api.Controllers;
using Katas.MatchAggregate;

namespace Katas.UnitTests;

public class MatchControllerTests
{
    private const int AnyMatchId = 1;
    private MatchController _matchController = null!;
    private IMatchService _matchService = null!;

    [SetUp]
    public void SetUp()
    {
        _matchService = Substitute.For<IMatchService>();
        _matchController = new MatchController(_matchService);
    }

    [TestCase(SoccerEvent.HomeGoal)]
    [TestCase(SoccerEvent.AwayCancel)]
    public void update_goal_record_success(SoccerEvent soccerEvent)
    {
        _matchController.UpdateGoalRecord(AnyMatchId, soccerEvent);

        _matchService.Received().UpdateGoalRecord(AnyMatchId, soccerEvent);
    }
}