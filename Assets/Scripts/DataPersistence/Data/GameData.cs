using System;

[System.Serializable]
public class GameData 
{
    public float foodStat, cleanlinessStat, happinessStat, hydrationStat, energyStat, healthStat;
    public DateTime gameStart;
    public DateTime gameLastPlayed;
    // public DateTime gameExit;
    private int defaultStat = 100;

    public GameData()
    {
        this.cleanlinessStat = defaultStat;
        this.energyStat = defaultStat;
        this.happinessStat = defaultStat;
        this.hydrationStat = defaultStat;
        this.healthStat = defaultStat;
        this.foodStat = defaultStat;
        this.gameStart = DateTime.UtcNow;
        this.gameLastPlayed = new DateTime();
    }
}
