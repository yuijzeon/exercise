namespace Katas.MatchAggregate;

public interface IMatchRepository
{
    Match GetMatch(int id);
    void UpdateGoalRecord(Match match);
}