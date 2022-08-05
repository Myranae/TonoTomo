using System;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    public int food, happiness, energy, hydration, cleanliness, health;
    public int foodTickRate, happinessTickRate, energyTickRate, hydrationTickRate, cleanlinessTickRate, healthTickRate;
    public GameObject hungryAnim;
    public DateTime lastTimeFed;
    private PetController petController;
    public GameObject pet;


    private void Awake() 
    {
        hungryAnim.SetActive(false);
    }
    private void Start() {
        petController = pet.GetComponent<PetController>();
    }

    public void Initialize(int food, int happiness, int energy, int hydration, int cleanliness, int health)
    {
        lastTimeFed = DateTime.Now; 
        this.food = food;
        this.happiness = happiness;
        this.energy = energy;
        this.hydration = hydration;
        this.cleanliness = cleanliness;
        this.health = health;
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

        CheckHunger();
        // CheckEnergy();
        CheckHappiness();
    }

    public void CheckHunger()
    {   
        if (food < 50)
        {
            ShowHungryAnim();
        }
        else
        {
            StopHungryAnim();
        }
    }

    // public void CheckEnergy()
    // {   
    //     if (energy < 50)
    //     {
    //         ShowTiredAnim();
    //     }
    //     else
    //     {
    //         StopTiredAnim();
    //     }
    // }

    public void CheckHappiness()
    {   
        if (happiness < 50 && petController.isSad == false)
        {
            petController.Sad();
        }
        else if (happiness >= 50 && petController.isSad == true)
        {
            // petController.Idle();
            petController.notSad();
        }
    }

    public void ShowHungryAnim()
    {
        hungryAnim.SetActive(true);
    }

    public void StopHungryAnim()
    {
        hungryAnim.SetActive(false);
    }

    // public void ShowTiredAnim()
    // {
    //     tiredAnim.SetActive(true);
    // }

    // public void StopHungryAnim()
    // {
    //     tiredAnim.SetActive(false);
    // }


    // Might want to change the below to one called ChangeNeed and pass in
    // the string or variable of the need to change, plus the amount to change
    public void ChangeFood(int amount)
    {
        food += amount;
        if (amount > 0)
        {
            lastTimeFed = DateTime.Now;
        }
        if(food < 0)
        {
            PetManager.Die();
        } 
        else if(food > 100) food = 100;
    }

    public void ChangeHappiness(int amount)
    {
        happiness += amount;
        if(happiness < 0)
        {
            PetManager.Die();
        } 
        else if(happiness > 100) happiness = 100;
        
    }

    public void ChangeEnergy(int amount)
    {
        energy += amount;
        if(energy < 0)
        {
            PetManager.Die();
        } 
        else if(energy > 100) energy = 100;
    }
    public void ChangeHydration(int amount)
    {
        hydration += amount;
        if(hydration < 0)
        {
            PetManager.Die();
        } 
        else if(hydration > 100) hydration = 100;
    }
    public void ChangeCleanliness(int amount)
    {
        cleanliness += amount;
        if(cleanliness < 0)
        {
            PetManager.Die();
        } 
        else if(cleanliness > 100) cleanliness = 100;
    }
}
// Maybe have a "lives" or "needsChances" variable set to a certain number
// then subtract one from that number each time a need hits or goes below 0
// then run DeathCheck on every update and DeathCheck says if the "lives"
//variable is at or below 0, then run the Die method
// I think when two needs are at 0, then health starts to decrease
// or something like that. 