namespace Tennis;

public class Player
{
    public Player(string name)
    {
        Name = name;
    }

    public int Score { get; private set; }
    public string Name { get; }

    public void WinPoint()
    {
        Score++;
    }

    public string GetRegularScore(Player adversary)
    {
        var score1 = GetScoreString(Score);
        var score2 = GetScoreString(adversary.Score);

        return $"{score1}-{score2}";
    }

    private string GetScoreString(int score)
    {
        return score switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            _ => "Forty"
        };
    }

    public string GetEndGameScore(Player adversary)
    {
        return (Score - adversary.Score) switch
        {
            1 => $"Advantage {Name}",
            -1 => $"Advantage {adversary.Name}",
            >= 2 => $"Win for {Name}",
            _ => $"Win for {adversary.Name}"
        };
    }

    public string GetTieScore()
    {
        return Score switch
        {
            0 => "Love-All",
            1 => "Fifteen-All",
            2 => "Thirty-All",
            _ => "Deuce"
        };
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
            return _player1.GetTieScore();
        if (IsGamePoint())
            return _player1.GetEndGameScore(_player2);
        
        return _player1.GetRegularScore(_player2);
    }

    private bool ArePlayersTied()
    {
        return _player1.Score == _player2.Score; // Feature envy. Metodo a player
    }

    private bool IsGamePoint()
    {
        return _player1.Score >= 4 || _player2.Score >= 4; // Feature envy
    }
}