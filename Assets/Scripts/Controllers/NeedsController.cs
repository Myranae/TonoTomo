using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NeedsController : MonoBehaviour, IDataPersistence
{
    public double food, happiness, hydration, cleanliness, energy, health;
    public float foodTickRate, happinessTickRate, hydrationTickRate, cleanlinessTickRate, energyTickRate, healthTickRate;
    public GameObject hungryAnim;
    public GameObject dirtyAnim;
    public GameObject thirstyAnim;
    public GameObject sickAnim;
    private NeedsManagement needsManagement;
    public GameObject needsActions;
    private ShowNeeds showNeeds;
    public GameObject pet;
    public GameObject tiredAnim;
    public TimeSpan interval;
    public double secondsSinceLastPlayed;
    public double gameHoursSinceLastPlayed;
    public bool hasHatchedNc;
    public GameObject lightsOff;
    public UserActionController userActionController;
    public DateTime lastTimePlayed;
    public DateTime timeStartedPlaying;
    private DataPersistenceManager dataPersistenceManager;

    private void Awake() 
    {
        hungryAnim.SetActive(false);
        dirtyAnim.SetActive(false);
        thirstyAnim.SetActive(false);
        tiredAnim.SetActive(false);
        sickAnim.SetActive(false);

        dataPersistenceManager = GameObject.FindGameObjectWithTag("DPM").GetComponent<DataPersistenceManager>();

        // timeStartedPlaying = DateTime.UtcNow;
        // DataPersistenceManager.instance.SaveGame();

        showNeeds = pet.GetComponent<ShowNeeds>();
        userActionController = pet.GetComponent<UserActionController>();
    }

    private void Start() {
        needsManagement = needsActions.GetComponent<NeedsManagement>();
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
        // this.timeStartedPlaying = DateTime.Parse(data.gameStart);
        data.gameStart = DateTime.UtcNow.ToString("u");

        double timePassed = data.hasHatchedStat ? CalculateGameHoursPassed(data) : 0;

        this.food = data.foodStat - foodTickRate*timePassed;
        this.happiness = data.happinessStat - happinessTickRate*timePassed;
        this.hydration = data.hydrationStat - hydrationTickRate*timePassed;
        this.cleanliness = data.cleanlinessStat - cleanlinessTickRate*timePassed;
        this.health = data.healthStat - healthTickRate*timePassed;

        if (data.isSleepingStat)
        {
            Debug.Log("Sleeping, so adding: " + energyTickRate*timePassed);
            this.energy = data.energyStat + energyTickRate*timePassed;
        } 
        else
        {
            Debug.Log("Not sleeping, right?");
            this.energy = data.energyStat - energyTickRate*timePassed;
        }

        this.hasHatchedNc = data.hasHatchedStat;
    }

    public double CalculateGameHoursPassed(GameData data)
    {
        // interval = DateTime.Parse(data.gameLastPlayed) - timeStartedPlaying;
        interval = DateTime.Parse(data.gameStart) - DateTime.Parse(data.gameLastPlayed);
        Debug.Log("This is gameStart: " + data.gameStart);
        Debug.Log("This is gameLastPlayed: " + data.gameLastPlayed);
        Debug.Log("This is the interval: " + interval);

        secondsSinceLastPlayed = interval.TotalSeconds;
        Debug.Log("Seconds since last played: " + secondsSinceLastPlayed);

        gameHoursSinceLastPlayed = secondsSinceLastPlayed / (double)TimingManager.instance.hourLength;
        Debug.Log("HourLength from TimingManager: " + TimingManager.instance.hourLength);

        Debug.Log("Game hours since last played from NC: " + gameHoursSinceLastPlayed);
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

            data.gameLastPlayed = this.lastTimePlayed.ToString("u");

            Debug.Log("Saving last time played (" + this.lastTimePlayed + ") as gamelastplayed (" + data.gameLastPlayed + ").");

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

    public void ChangeFood(float amount)
    {
        food += amount;
        if(food > 100) food = 100;
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
