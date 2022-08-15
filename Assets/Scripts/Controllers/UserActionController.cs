using UnityEngine;
using UnityEngine.SceneManagement;

public class UserActionController : MonoBehaviour
{
    public GameObject pettingAnim;
    // [SerializeField] private NeedsManagement needsManagement;
    public NeedsController needsController;
    // public GameObject needsAction;
    private int happinessChange = 10;
    private int cleanlinessChange = 30;
    private int foodChange = 15;
    private int hydrationChange = 15;
    private int healthChange = 35;
    // This is how much the energyChange should be if it needs to sleep all night; it's not tuned for that yet though
    // private int energyChange = (1/2520);
    private int energyChange = 5;
    public GameObject pet;
    public GameObject lightsOff;
    public GameObject medicineAction;
    public GameObject gameAction;
    public GameObject bathAction;
    public GameObject drinkAction;
    public GameObject foodAction;
    public GameObject petAction;
    private ShowNeeds showNeeds;


    private void Awake() 
    {
        pettingAnim.SetActive(false);
    }

    private void Start() 
    {
        showNeeds = pet.GetComponent<ShowNeeds>();
    }

    private void Update()
    {
        // if (lightsOff.activeSelf)
        // {
        //     Debug.Log("LightsOff is active.");
        //     IncreaseEnergy();
        // }
    }

    public void ShowPetting()
    {
        pettingAnim.SetActive(true);
        pettingAnim.SetActive(true);
    }

    // public void StopPetting()
    // {   
    //     pettingAnim.SetActive(false);
    //     IncreaseHappiness();
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
        lightsOff.SetActive(!lightsOff.activeSelf);
        medicineAction.SetActive(!medicineAction.activeSelf);
        // gameAction.SetActive(!gameAction.activeSelf);
        bathAction.SetActive(!bathAction.activeSelf);
        drinkAction.SetActive(!drinkAction.activeSelf);
        foodAction.SetActive(!foodAction.activeSelf);
        petAction.SetActive(!petAction.activeSelf);
        showNeeds.hideNeedBubbles = !showNeeds.hideNeedBubbles;
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
        Debug.Log("Active scene name is: " + SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name != "EggIdleScene")
        {
            needsController.energy += energyChange;
            if (needsController.energy > 100)
                needsController.energy = 100;
        }
    }

    // public void ShowPetting()
    // {
    //     pettingAnim.SetActive(true);
    //     pettingAnim.SetActive(true);
    // }
}