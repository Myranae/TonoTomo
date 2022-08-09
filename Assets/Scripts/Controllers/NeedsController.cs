using System;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    public int food, happiness, hydration, cleanliness, health;
    public float energy;
    
    public int foodTickRate, happinessTickRate, hydrationTickRate, cleanlinessTickRate, healthTickRate;
    public float energyTickRate;
    public GameObject hungryAnim;
    public GameObject dirtyAnim;
    public GameObject thirstyAnim;
    public DateTime lastTimeFed;
    private NeedsManagement needsManagement;
    public GameObject needsActions;

    [SerializeField]
    private int needsThreshold;
    private ShowNeeds showNeeds;
    public GameObject pet;
    public GameObject tiredAnim;

    private void Awake() 
    {
        hungryAnim.SetActive(false);
        dirtyAnim.SetActive(false);
    }
    private void Start() {
        needsManagement = needsActions.GetComponent<NeedsManagement>();
        showNeeds = pet.GetComponent<ShowNeeds>();
    }

    // public void Initialize(int food, int happiness, int energy, int hydration, int cleanliness, int health)
    // {
    //     lastTimeFed = DateTime.Now; 
    //     this.food = food;
    //     this.happiness = happiness;
    //     this.energy = energy;
    //     this.hydration = hydration;
    //     this.cleanliness = cleanliness;
    //     this.health = health;
    // }

    private void Update() 
    {
        if(TimingManager.gameHourTimer < 0)
        {
            ChangeFood(-foodTickRate);
            ChangeHappiness(-happinessTickRate);
            ChangeEnergy(-energyTickRate);
            ChangeHydration(-hydrationTickRate);
            ChangeCleanliness(-cleanlinessTickRate);

            if (food < 0) food = 0;
            if (happiness < 0) happiness = 0;
            if (energy < 0) energy = 0;
            if (hydration < 0) hydration = 0;
            if (cleanliness < 0) cleanliness = 0;
        }

        CheckHunger();
        CheckCleanliness();
        CheckEnergy();
        CheckHappiness();
        CheckHydration();
    }

    public void CheckHunger()
    {   
        if (food < 50 && !showNeeds.hideNeedBubbles)
        {
            ShowHungryAnim();
        }
        else
        {
            StopHungryAnim();
        }
    }

    public void CheckCleanliness()
    {
        if (cleanliness < 50 && !showNeeds.hideNeedBubbles)
        {
            ShowDirtyAnim();
        }
        else
        {
            StopDirtyAnim();
        }
    }

    public void CheckEnergy()
    {   
        if (energy < 20 && !showNeeds.hideNeedBubbles)
        {
            ShowTiredAnim();
        }
        else
        {
            StopTiredAnim();
        }
    }

    public void CheckHydration()
    {   
        if (hydration < 50 && !showNeeds.hideNeedBubbles)
        {
            ShowThirstyAnim();
        }
        else
        {
            StopThirstyAnim();
        }
    }

    public void CheckHappiness()
    {   
        if (happiness < 50 && needsManagement.isSad == false )
        {
            needsManagement.Sad();
        }
        else if (happiness >= 50 && needsManagement.isSad == true)
        {
            needsManagement.notSad();
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
    public void ShowDirtyAnim()
    {
        dirtyAnim.SetActive(true);
    }

    public void StopDirtyAnim()
    {
        dirtyAnim.SetActive(false);
    }

    public void ShowTiredAnim()
    {
        tiredAnim.SetActive(true);
    }

    public void StopTiredAnim()
    {
        tiredAnim.SetActive(false);
    }

    public void ShowThirstyAnim()
    {
        thirstyAnim.SetActive(true);
    }

    public void StopThirstyAnim()
    {
        thirstyAnim.SetActive(false);
    }


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

    public void ChangeEnergy(float amount)
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