using UnityEngine;
using UnityEngine.SceneManagement;

public class UserActionController : MonoBehaviour, IDataPersistence
{
    public GameObject pettingAnim;
    public NeedsController needsController;
    private int happinessChange = 10;
    private int cleanlinessChange = 30;
    private int foodChange = 15;
    private int hydrationChange = 15;
    private int healthChange = 35;
    // This is how much the energyChange should be if it needs to sleep all night; it's not tuned for that yet though
    // private int energyChange = (1/2520);
    private int energyChange = 5;
    // public GameObject pet;
    public GameObject lightsOff;
    public GameObject medicineAction;
    public GameObject gameAction;
    public GameObject bathAction;
    public GameObject drinkAction;
    public GameObject foodAction;
    public GameObject petAction;
    public ShowNeeds showNeeds;
    public bool isSleeping;


    private void Awake() 
    {
        pettingAnim.SetActive(false);
        // if (SceneManager.GetActiveScene().name == "Pet_Baby")
        // {
        //     showNeeds = GameObject.FindGameObjectWithTag("Pet").GetComponent<ShowNeeds>();
        // }
    }

    // private void Start() 
    // {

    // }

    public void LoadData(GameData data)
    {
        this.isSleeping = data.isSleepingStat;
    }

    public void SaveData(ref GameData data)
    {
        data.isSleepingStat = this.isSleeping;
    }


    // public void ShowPetting()
    // {
    //     pettingAnim.SetActive(true);
    //     pettingAnim.SetActive(true);
    // }

    public void IncreaseHappiness()
    {
        needsController.happiness += happinessChange;
        if (needsController.happiness > 100)
            needsController.happiness = 100;
    }

    public void IncreaseCleanliness()
    {
        needsController.cleanliness += cleanlinessChange;
        if (needsController.cleanliness > 100)
            needsController.cleanliness = 100;

    }
    public void IncreaseHydration()
    {
        needsController.hydration += hydrationChange;
        if (needsController.hydration > 100)
            needsController.hydration = 100;
    }

    public void GoToSleep() 
    {
        isSleeping = isSleeping ? false : true;
        lightsOff.SetActive(!lightsOff.activeSelf);
        medicineAction.SetActive(!medicineAction.activeSelf);
        // gameAction.SetActive(!gameAction.activeSelf);
        bathAction.SetActive(!bathAction.activeSelf);
        drinkAction.SetActive(!drinkAction.activeSelf);
        foodAction.SetActive(!foodAction.activeSelf);
        petAction.SetActive(!petAction.activeSelf);

        GameObject.FindGameObjectWithTag("Pet").GetComponent<ShowNeeds>().hideNeedBubbles = !GameObject.FindGameObjectWithTag("Pet").GetComponent<ShowNeeds>().hideNeedBubbles;

    }
    public void EggGoToSleep() 
    {
        lightsOff.SetActive(!lightsOff.activeSelf);
        // medicineAction.SetActive(!medicineAction.activeSelf);
        // gameAction.SetActive(!gameAction.activeSelf);
        // bathAction.SetActive(!bathAction.activeSelf);
        // drinkAction.SetActive(!drinkAction.activeSelf);
        // foodAction.SetActive(!foodAction.activeSelf);
        petAction.SetActive(!petAction.activeSelf);
        // showNeeds.hideNeedBubbles = !showNeeds.hideNeedBubbles;
        isSleeping = !isSleeping;
    }

    public void IncreaseFood()
    {
        needsController.food += foodChange;
        if (needsController.food > 100)
            needsController.food = 100;
    }

    public void IncreaseHealth()
    {
        needsController.health += healthChange;
        if (needsController.health > 100)
            needsController.health = 100;
    }
    public void IncreaseEnergy()
    {
        if (SceneManager.GetActiveScene().name != "EggIdleScene")
        {
            needsController.energy += energyChange;
            if (needsController.energy > 100)
                needsController.energy = 100;
        }
    }
}