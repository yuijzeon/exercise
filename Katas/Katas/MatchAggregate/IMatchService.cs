namespace Katas.MatchAggregate;

public interface IMatchService
{
    void UpdateGoalRecord(int matchId, SoccerEvent soccerEvent);
}