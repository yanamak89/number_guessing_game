public class Player
{
    public int Attempts { get; set; }
    public int HighScore { get; private set; }

    public Player()
    {
        HighScore = int.MaxValue;
        Attempts = 0;
    }

    public void UpdateHighScore()
    {
        if (Attempts < HighScore)
            HighScore = Attempts;
    }

    public void ResetAttempts()
    {
        Attempts = 0;
    }
}