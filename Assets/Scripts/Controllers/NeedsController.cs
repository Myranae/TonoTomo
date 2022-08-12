using System;
using UnityEngine;
using UnityEngine.SceneManagement;
// using System.Collections;

public class NeedsController : MonoBehaviour, IDataPersistence
{
    public float food, happiness, hydration, cleanliness, energy, health;
    public float foodTickRate, happinessTickRate, hydrationTickRate, cleanlinessTickRate, energyTickRate, healthTickRate;
    public GameObject hungryAnim;
    public GameObject dirtyAnim;
    public GameObject thirstyAnim;
    public GameObject sickAnim;
    public DateTime lastTimeFed;
    private NeedsManagement needsManagement;
    public GameObject needsActions;
    [SerializeField] private int needsThreshold;
    private ShowNeeds showNeeds;
    public GameObject pet;
    public GameObject tiredAnim;
    public TimeSpan interval;
    public float secondsSinceLastPlayed;
    public float gameHoursSinceLastPlayed;
    // public EggController eggController;
    public bool hasHatchedNc;
    public GameObject lightsOff;
    public UserActionController userActionController;

    private void Awake() 
    {
        hungryAnim.SetActive(false);
        dirtyAnim.SetActive(false);
        thirstyAnim.SetActive(false);
        tiredAnim.SetActive(false);
        sickAnim.SetActive(false);
    }
    private void Start() {
        needsManagement = needsActions.GetComponent<NeedsManagement>();
        showNeeds = pet.GetComponent<ShowNeeds>();
    }

    private void Update() 
    {
        if (hasHatchedNc) 
        {
            if (TimingManager.gameHourTimer < 0)
            {
                ChangeFood(-foodTickRate);
                ChangeHappiness(-happinessTickRate);
                ChangeEnergy(-energyTickRate);
                ChangeHydration(-hydrationTickRate);
                ChangeCleanliness(-cleanlinessTickRate);
                
                if (lightsOff.activeSelf)
                {
                    Debug.Log("LightsOff is active.");
                    userActionController.IncreaseEnergy();
                }
            }

            CheckHunger();
            CheckCleanliness();
            CheckEnergy();
            CheckHappiness();
            CheckHydration();
            CheckHealth();
            CheckForPetDeath();
        }
    }

    public void LoadData(GameData data)
    {
        data.gameStart = DateTime.UtcNow;
        Debug.Log("This is gameStart on LoadData: " + data.gameStart);
        Debug.Log("This is gameLastPlayed on LoadData: " + data.gameLastPlayed);
        Debug.Log("This is data.hasHatchedStat on LoadData: " + data.hasHatchedStat);

        float timePassed = data.hasHatchedStat ? CalculateGameHoursPassed(data) : 0;
        Debug.Log("This is timePassed: " + timePassed);

        this.food = data.foodStat - foodTickRate*timePassed;
        Debug.Log("This is the new food: " + this.food);

        this.happiness = data.happinessStat - happinessTickRate*timePassed;
        Debug.Log("On LoadData, this.happiness = " + this.happiness);

        this.energy = data.energyStat - energyTickRate*timePassed;
        this.hydration = data.hydrationStat - hydrationTickRate*timePassed;
        this.cleanliness = data.cleanlinessStat - cleanlinessTickRate*timePassed;
        this.health = data.healthStat - healthTickRate*timePassed;
        this.hasHatchedNc = data.hasHatchedStat;
    }

    public float CalculateGameHoursPassed(GameData data)
    {
        interval = data.gameStart - data.gameLastPlayed;
        Debug.Log("This is the interval: " + interval);
        secondsSinceLastPlayed = interval.Seconds;
        Debug.Log("This is seconds since last played: " + secondsSinceLastPlayed);
        Debug.Log("This is seconds times deltaTime: " + secondsSinceLastPlayed * Time.deltaTime);
        gameHoursSinceLastPlayed = secondsSinceLastPlayed / TimingManager.instance.hourLength;
        return gameHoursSinceLastPlayed;
    }

    public void SaveData(ref GameData data)
    {
        {
            data.foodStat = this.food;
            data.happinessStat = this.happiness;
            data.energyStat = this.energy;
            data.hydrationStat = this.hydration;
            data.cleanlinessStat = this.cleanliness;
            data.healthStat = this.health;
            data.gameLastPlayed = DateTime.UtcNow;
            data.lastScene = SceneManager.GetActiveScene().name != "Menu" ? SceneManager.GetActiveScene().name : data.lastScene;
        }
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
    public void CheckHealth()
    {   
        if (health < 30 && !showNeeds.hideNeedBubbles)
        {
            ShowSickAnim();
        }
        else
        {
            StopSickAnim();
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
    public void ShowSickAnim()
    {
        sickAnim.SetActive(true);
    }

    public void StopSickAnim()
    {
        sickAnim.SetActive(false);
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
    public void ChangeFood(float amount)
    {
        food += amount;
        if(food > 100) food = 100;
        // if(food < 0) food = 0;
        if (food < 0) 
        {
            food = 0;
            health -= healthTickRate;
        }
    }

    public void ChangeHappiness(float amount)
    {
        happiness += amount;
        if(happiness > 100) happiness = 100;
        // if(happiness < 0) happiness = 0;
        if (happiness < 0) 
        {
            happiness = 0;
            health -= healthTickRate;
        }
    }

    public void ChangeEnergy(float amount)
    {
        energy += amount;
        if(energy > 100) energy = 100;
        // if(energy < 0) energy = 0;
        if(energy < 0)
        {
            energy = 0;
            health -= healthTickRate;
        }
    }

    public void ChangeHydration(float amount)
    {
        hydration += amount;
        if(hydration > 100) hydration = 100;
        // if(hydration < 0) hydration = 0;
        if(hydration < 0)
        {
            hydration = 0;
            health -= healthTickRate;
        } 
    }

    public void ChangeCleanliness(float amount)
    {
        cleanliness += amount;
        if(cleanliness > 100) cleanliness = 100;
        // if(cleanliness < 0) cleanliness = 0;
        if(cleanliness < 0)
        {
            cleanliness = 0;
            health -= healthTickRate;
        } 
    }

    public void CheckForPetDeath()
    {
        if (health < 0) 
        {
            PetManager.instance.Die();
        }
    }

}
