namespace Katas.TennisAggregate;

public class TennisPlayer
{
    public TennisPlayer(string name)
    {
        Name = name;
    }

    public int Score { get; set; }
    public string Name { get; set; }

    public void Scored(int score)
    {
        Score += score;
    }
}