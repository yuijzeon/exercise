namespace Katas.MatchAggregate;

public class MatchService : IMatchService
{
    private readonly IMatchRepository _matchRepository;

    public MatchService(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }

    public void UpdateGoalRecord(int matchId, SoccerEvent soccerEvent)
    {
        var match = _matchRepository.GetMatch(matchId);
        match.Do(soccerEvent);
        _matchRepository.UpdateGoalRecord(match);
    }
}