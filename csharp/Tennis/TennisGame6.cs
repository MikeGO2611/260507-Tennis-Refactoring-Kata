namespace Tennis;

public class Score
{
    public Score()
    {
    }

    public int Value { get; set; }

    public string ToDescription()
    {
        return Value switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            _ => "Forty"
        };
    }
}

public class Player
{
    public Player(string name)
    {
        Name = name;
        Score1 = new Score();
    }

    public string Name { get; }

    public Score Score1 { get; }

    public void WinPoint()
    {
        Score1.Value++; //Envy
    }

    public string GetRegularScore(Player adversary)
    {
        var score1 = Score1.ToDescription();
        var score2 = adversary.Score1.ToDescription();

        return $"{score1}-{score2}";
    }

    public string GetEndGameScore(Player adversary)
    {
        return (Score1.Value - adversary.Score1.Value) switch //Envy, Chain
        {
            1 => $"Advantage {Name}",
            -1 => $"Advantage {adversary.Name}",
            >= 2 => $"Win for {Name}",
            _ => $"Win for {adversary.Name}"
        };
    }

    public string GetTieScore()
    {
        return Score1.Value switch //Envy
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
        return _player1.Score1.Value == _player2.Score1.Value; // Feature envy. Chain
    }

    private bool IsGamePoint()
    {
        return _player1.Score1.Value >= 4 || _player2.Score1.Value >= 4; // Feature envy. Chain
    }
}