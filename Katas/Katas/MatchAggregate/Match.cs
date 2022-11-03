namespace Katas.MatchAggregate;

public class Match
{
    private readonly Dictionary<SoccerEvent, Action> _actionMapping;
    private string _firstHalfGoalRecord = "";
    private string _secondHalfGoalRecord = "";

    public Match()
    {
        _actionMapping = new Dictionary<SoccerEvent, Action>
        {
            [SoccerEvent.HomeGoal] = () => Goal("H"),
            [SoccerEvent.AwayGoal] = () => Goal("A"),
            [SoccerEvent.HomeCancel] = () => Cancel("H"),
            [SoccerEvent.AwayCancel] = () => Cancel("A"),
        };
    }

    private string LastRecordSymbol =>
        _firstHalfGoalRecord + _secondHalfGoalRecord == ""
            ? ""
            : $"{(_firstHalfGoalRecord + _secondHalfGoalRecord)[^1]}";

    public int Id { get; set; }
    public int LivePeriod { get; set; }

    public string GoalRecord
    {
        get =>
            _firstHalfGoalRecord + (LivePeriod == 2
                ? ";"
                : "") + _secondHalfGoalRecord;
        set
        {
            var records = value.Split(";", 2);
            _firstHalfGoalRecord = records[0];

            _secondHalfGoalRecord = records.Length == 2
                ? records[1]
                : "";
        }
    }

    public void Do(SoccerEvent soccerEvent)
    {
        _actionMapping[soccerEvent]();
    }

    private void Cancel(string recordSymbol)
    {
        if (LastRecordSymbol == recordSymbol)
        {
            GoalRecord = GoalRecord.EndsWith(";")
                ? GoalRecord[..^2] + ";"
                : GoalRecord[..^1];
        }
        else
        {
            throw new Exception("Can't Cancel the Goal");
        }
    }

    private void Goal(string recordSymbol)
    {
        GoalRecord += recordSymbol;
    }
}