using UnityEngine;
using UnityEngine.SceneManagement;


public class EggController : MonoBehaviour
{   
    // public ButtonController buttonController;
    public Animator eggAnimator;
    public float incubationTimeLeft;
    public GameObject pettingAnim;

    private void Awake() 
    {
        incubationTimeLeft = 30;
        pettingAnim.SetActive(false);

    }

    private void Start() 
    {
    }

    void Update()
    {
        CheckIncubationTime();
    }

    public void ShowPetting()
    {
        Debug.Log("Received press!");
        pettingAnim.SetActive(true);
        pettingAnim.SetActive(true);

    }

    public void StopPetting()
    {   
        if (incubationTimeLeft > 0)
        {

            pettingAnim.SetActive(false);
            incubationTimeLeft -= 5;
            // buttonController.DisableButton();
        }
    }

    private void CheckIncubationTime()
    {
        if(incubationTimeLeft > 0)
        {
            incubationTimeLeft -= Time.deltaTime;
        }
        else 
        {
            pettingAnim.SetActive(false);
            eggAnimator.SetBool("timeToHatch", true);
        }
    }

    void EggHatch()
    {
        SceneManager.LoadScene("BabyIdleScene");
    }


}
