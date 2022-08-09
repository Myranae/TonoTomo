using UnityEngine;

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
    public GameObject pet;

    private void Awake() 
    {
        pettingAnim.SetActive(false);
        // needsController = GetComponent<NeedsController>();
    }

    public void ShowPetting()
    {
        // Debug.Log("Received press!");
        // pettingAnim.SetActive(true);
        pettingAnim.SetActive(true);
    }

    public void StopPetting()
    {   
        pettingAnim.SetActive(false);
        IncreaseHappiness();
    }

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

    public void IncreaseFood()
    {
            needsController.food += foodChange;
            if (needsController.food > 100)
                needsController.food = 100;

    }
}