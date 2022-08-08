using UnityEngine;

public class UserActionController : MonoBehaviour
{
    public GameObject pettingAnim;
    // [SerializeField] private NeedsManagement needsManagement;
    public NeedsController needsController;
    // public GameObject needsAction;
    private int needAmtChange = 10;
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
            needsController.happiness += needAmtChange;
            if (needsController.happiness > 100)
                needsController.happiness = 100;

    }

    public void IncreaseCleanliness()
    {
            needsController.cleanliness += needAmtChange;
            if (needsController.cleanliness > 100)
                needsController.cleanliness = 100;

    }
}