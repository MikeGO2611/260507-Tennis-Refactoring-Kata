namespace Tennis;

public class TennisGame6 : ITennisGame
{
    private int player1Score;
    private int player2Score;
    private string player1Name;
    private string player2Name;

    public TennisGame6(string player1Name, string player2Name)
    {
        this.player1Name = player1Name;
        this.player2Name = player2Name;
    }

    public void WonPoint(string playerName)
    {
        if (playerName == player1Name)
            player1Score++;
        else
            player2Score++;
    }

    public string GetScore()
    {
        if (player1Score == player2Score)
            return GetTieScore();
        if (IsGamePoint())
            return GetEndGameScore();
        
        return GetRegularScore();
    }

    private bool IsGamePoint()
    {
        return player1Score >= 4 || player2Score >= 4;
    }

    private string GetRegularScore()
    {
        var score1 = GetScoreString(player1Score);
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
        return (player1Score - player2Score) switch
        {
            1 => $"Advantage {player1Name}",
            -1 => $"Advantage {player2Name}",
            >= 2 => $"Win for {player1Name}",
            _ => $"Win for {player2Name}"
        };
    }

    private string GetTieScore()
    {
        return player1Score switch
        {
            0 => "Love-All",
            1 => "Fifteen-All",
            2 => "Thirty-All",
            _ => "Deuce"
        };
    }
}