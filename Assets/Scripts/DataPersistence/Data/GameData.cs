using System;

[System.Serializable]
public class GameData 
{
    public int foodStat;
    public int happinessStat;
    public int hydrationStat;
    public int cleanlinessStat;
    public int healthStat;
    public float energyStat;
    public DateTime gameStart;

    public GameData()
    {
        this.cleanlinessStat = NeedsController.cleanliness;
        this.energyStat = NeedsController.energy;
        this.happinessStat = NeedsController.happiness;
        this.hydrationStat = NeedsController.hydration;
        this.healthStat = NeedsController.health;
        this.gameStart = DateTime.UtcNow;

    }
}
