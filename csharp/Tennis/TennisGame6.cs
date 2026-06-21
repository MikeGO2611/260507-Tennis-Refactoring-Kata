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
        get { return score; }
        private set { score = value; }
    }

    public string Name
    {
        get { return name; }
    }

    public void WinPoint()
    {
        Score++;
    }
}

public class TennisGame6 : ITennisGame
{ 
    private readonly Player _player1;
    private readonly Player _player2;

    public TennisGame6(string player1Name, string player2Name)
    {
        _player1 = new Player(player1Name);
        _player2 = new Player(player2Name);
    }

    public void WonPoint(string playerName)
    {
        if (playerName == _player1.Name) // Feature envy
            _player1.WinPoint();
        else
            _player2.WinPoint();
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
        return _player1.Score == _player2.Score; // Feature envy. Metodo a player
    }

    private bool IsGamePoint()
    {
        return _player1.Score >= 4 || _player2.Score >= 4; // Feature envy
    }

    private string GetRegularScore()
    {
        var score1 = GetScoreString(_player1.Score);
        var score2 = GetScoreString(_player2.Score);

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
        return (_player1.Score - _player2.Score) switch
        {
            1 => $"Advantage {_player1.Name}",
            -1 => $"Advantage {_player2.Name}",
            >= 2 => $"Win for {_player1.Name}",
            _ => $"Win for {_player2.Name}"
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