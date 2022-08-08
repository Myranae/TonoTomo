using UnityEngine;

public class UserActionController : MonoBehaviour
{
    public GameObject pettingAnim;
    public NeedsController needsController;
    // public GameObject needsAction;
    private int needAmtChange = 10;

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
        if (needsController.happiness < (100-needAmtChange))
        {
            needsController.happiness += needAmtChange;
        }
        
        else

    }
}