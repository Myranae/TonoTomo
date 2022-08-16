using System;
[System.Serializable]
public class GameData 
{
    public float foodStat, cleanlinessStat, happinessStat, hydrationStat, energyStat, healthStat, incubationTimeLeftStat;
    public string gameStart;
    public string gameLastPlayed;
    // public DateTime gameExit;
    private int defaultStat = 70;
    public string lastScene;
    public bool hasHatchedStat, isSleepingStat;

    public GameData()
    {
        this.lastScene = null;
        this.hasHatchedStat = false;
        this.incubationTimeLeftStat = 60;
        this.cleanlinessStat = defaultStat;
        this.energyStat = defaultStat;
        this.happinessStat = defaultStat;
        this.hydrationStat = defaultStat;
        this.healthStat = defaultStat;
        this.foodStat = defaultStat;
        this.gameStart = DateTime.UtcNow.ToString("u");
        this.gameLastPlayed = DateTime.UtcNow.ToString("u");
        this.isSleepingStat = false;
    }

    //"MM/dd/yyyy HH:mm:ss"
}
