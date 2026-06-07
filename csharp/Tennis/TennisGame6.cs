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
        if (player1Score >= 4 || player2Score >= 4)
            return GetEndGameScore();
        
        return GetRegularScore();
    }

    private string GetRegularScore()
    {
        string result;
        string regularScore;

        var score1 = GetScoreString(player1Score);
        var score2 = GetScoreString(player2Score);

        regularScore = $"{score1}-{score2}";

        result = regularScore;
        return result;
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

    private string GetEndGameScore()
    {
        string result;
        string endGameScore;

        switch (player1Score - player2Score)
        {
            case 1:
                endGameScore = $"Advantage {player1Name}";
                break;
            case -1:
                endGameScore = $"Advantage {player2Name}";
                break;
            case >= 2:
                endGameScore = $"Win for {player1Name}";
                break;
            default:
                endGameScore = $"Win for {player2Name}";
                break;
        }

        result = endGameScore;
        return result;
    }

    private string GetTieScore()
    {
        string result;
        string tieScore;
        switch (player1Score)
        {
            case 0:
                tieScore = "Love-All";
                break;
            case 1:
                tieScore = "Fifteen-All";
                break;
            case 2:
                tieScore = "Thirty-All";
                break;
            default:
                tieScore = "Deuce";
                break;
        }

        result = tieScore;
        return result;
    }
}