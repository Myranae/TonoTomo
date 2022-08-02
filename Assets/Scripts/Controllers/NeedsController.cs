using UnityEngine;

public class NeedsController : MonoBehaviour
{
    public int food, happiness, energy, hydration, cleanliness;
    public int foodTickRate, happinessTickRate, energyTickRate, hydrationTickRate, cleanlinessTickRate;

    public void Initialize(int food, int happiness, int energy, int hydration, int cleanliness)
    {
        this.food = food;
        this.happiness = happiness;
        this.energy = energy;
        this.hydration = hydration;
        this.cleanliness = cleanliness;
    }

    private void Update() 
    {
        if(TimingManager.gameHourTimer < 0)
        {
            ChangeFood(-foodTickRate);
            ChangeHappiness(-happinessTickRate);
            ChangeEnergy(-energyTickRate);
            ChangeHydration(-hydrationTickRate);
            ChangeCleanliness(-cleanlinessTickRate);
        }
    }
    // Might want to change the below to one called ChangeNeed and pass in
    // the string or variable of the need to change, plus the amount to change
    public void ChangeFood(int amount)
    {
        food += amount;
    }

    public void ChangeHappiness(int amount)
    {
        happiness += amount;
    }

    public void ChangeEnergy(int amount)
    {
        energy += amount;
    }
    public void ChangeHydration(int amount)
    {
        hydration += amount;
    }
    public void ChangeCleanliness(int amount)
    {
        cleanliness += amount;
    }
}
