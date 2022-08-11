using System;
[System.Serializable]
public class GameData 
{
    public float foodStat, cleanlinessStat, happinessStat, hydrationStat, energyStat, healthStat, incubationTimeLeftStat;
    public DateTime gameStart;
    public DateTime gameLastPlayed;
    // public DateTime gameExit;
    private int defaultStat = 70;
    public string lastScene;

    public GameData()
    {
        this.lastScene = "EggIdleScene";
        this.incubationTimeLeftStat = 60;
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
