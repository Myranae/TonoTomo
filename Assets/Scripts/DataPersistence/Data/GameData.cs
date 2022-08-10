using System;

[System.Serializable]
public class GameData 
{
    public int foodStat, cleanlinessStat, happinessStat, hydrationStat;
    public float energyStat, healthStat;
    public DateTime gameStart;
    // public DateTime gameExit;
    private int defaultStat = 100;

    public GameData()
    {
        this.cleanlinessStat = defaultStat;
        this.energyStat = defaultStat;
        this.happinessStat = defaultStat;
        this.hydrationStat = defaultStat;
        this.healthStat = defaultStat;
        this.gameStart = DateTime.UtcNow;

    }
}
