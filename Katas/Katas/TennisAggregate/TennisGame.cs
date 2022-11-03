namespace Katas.TennisAggregate;

public class TennisGame
{
    private readonly Dictionary<int, string> _scoreMap = new()
    {
        [0] = "Love",
        [1] = "Fifteen",
        [2] = "Thirty",
        [3] = "Forty"
    };

    public TennisGame(TennisPlayer player1, TennisPlayer player2)
    {
        Player1 = player1;
        Player2 = player2;
    }

    public TennisPlayer Player1 { get; }
    public TennisPlayer Player2 { get; }

    public string Report()
    {
        if (Math.Max(Player1.Score, Player2.Score) > 3)
        {
            switch (Player1.Score - Player2.Score)
            {
                case 1: return $"{Player1.Name} Adv";
                case -1: return $"{Player2.Name} Adv";
                case > 1: return $"{Player1.Name} Win";
                case < -1: return $"{Player2.Name} Win";
            }
        }

        if (Player1.Score == Player2.Score)
        {
            return Player1.Score > 2
                ? "Deuce"
                : $"{_scoreMap[Player1.Score]} All";
        }

        return $"{_scoreMap[Player1.Score]} {_scoreMap[Player2.Score]}";
    }
}
