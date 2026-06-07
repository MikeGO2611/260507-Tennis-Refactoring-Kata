namespace Tennis;

public class Player
{
    private int score;
    private string name;

    public Player(string name)
    {
        this.name = name;
    }

    public int Score
    {
        set { score = value; }
        get { return score; }
    }

    public string Name
    {
        set { name = value; }
        get { return name; }
    }
}

public class TennisGame6 : ITennisGame
{
    private int player2Score;
    private string player2Name;
    private readonly Player _player1;

    public TennisGame6(string player1Name, string player2Name)
    {
        _player1 = new Player(player1Name);
        this.player2Name = player2Name;
    }

    public void WonPoint(string playerName)
    {
        if (playerName == _player1.Name)
            _player1.Score++;
        else
            player2Score++;
    }

    public string GetScore()
    {
        if (ArePlayersTied())
            return GetTieScore();
        if (IsGamePoint())
            return GetEndGameScore();
        
        return GetRegularScore();
    }

    private bool ArePlayersTied()
    {
        return _player1.Score == player2Score;
    }

    private bool IsGamePoint()
    {
        return _player1.Score >= 4 || player2Score >= 4;
    }

    private string GetRegularScore()
    {
        var score1 = GetScoreString(_player1.Score);
        var score2 = GetScoreString(player2Score);

        return $"{score1}-{score2}";
    }

    private static string GetScoreString(int score)
    {
        return score switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            _ => "Forty"
        };
    }

    private string GetEndGameScore()
    {
        return (_player1.Score - player2Score) switch
        {
            1 => $"Advantage {_player1.Name}",
            -1 => $"Advantage {player2Name}",
            >= 2 => $"Win for {_player1.Name}",
            _ => $"Win for {player2Name}"
        };
    }

    private string GetTieScore()
    {
        return _player1.Score switch
        {
            0 => "Love-All",
            1 => "Fifteen-All",
            2 => "Thirty-All",
            _ => "Deuce"
        };
    }
}