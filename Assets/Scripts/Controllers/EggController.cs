using UnityEngine;
using UnityEngine.SceneManagement;

public class EggController : MonoBehaviour, IDataPersistence
{   
    // public ButtonController buttonController;
    public Animator eggAnimator;
    public float incubationTimeLeft;
    public GameObject pettingAnim;

    private void Awake() 
    {
        pettingAnim.SetActive(false);
    }

    void Update()
    {
        CheckIncubationTime();
    }

    public void LoadData(GameData data)
    {
        this.incubationTimeLeft = data.incubationTimeLeftStat;
    }

    public void SaveData(ref GameData data)
    {
        data.incubationTimeLeftStat = this.incubationTimeLeft;
        data.lastScene = SceneManager.GetActiveScene().name;
        Debug.Log("Last scene was: " + data.lastScene);
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
