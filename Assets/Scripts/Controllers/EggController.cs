using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class EggController : MonoBehaviour, IDataPersistence
{   
    // public ButtonController buttonController;
    public DataPersistenceManager dataPersistenceManager;
    public Animator eggAnimator;
    private float incubationTimeLeft;
    public GameObject pettingAnim;
    public bool hasHatched;
    public UserActionController userActionController;
    public GameObject lightsOff;
    // public static EggController instance;

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
        this.hasHatched = data.hasHatchedStat;
    }

    public void SaveData(ref GameData data)
    {
        data.incubationTimeLeftStat = this.incubationTimeLeft;
        data.hasHatchedStat = this.hasHatched;
        
        data.lastScene = SceneManager.GetActiveScene().name != "Menu" ? SceneManager.GetActiveScene().name : data.lastScene;
        Debug.Log("Scene just saved as lastScene: " + data.lastScene);
    }

    public void ShowPetting()
    {
        Debug.Log("Start petting incubationTimeLeft is: " + incubationTimeLeft);
        pettingAnim.SetActive(true);
        pettingAnim.SetActive(true);
    }

    public void StopPetting()
    {   
        if (incubationTimeLeft > 0)
        {
            incubationTimeLeft -= 5;
            
            Debug.Log("After pet, this is incubationTimeLeft: " + incubationTimeLeft);

            pettingAnim.SetActive(false);
        }
    }

    private void CheckIncubationTime()
    {
        if (incubationTimeLeft > 0)
        {
            incubationTimeLeft -= Time.deltaTime;
        }
        else 
        {
            if (lightsOff.activeInHierarchy)
            {
                userActionController.GoToSleep();
            }
            pettingAnim.SetActive(false);
            eggAnimator.SetBool("timeToHatch", true);
        }
    }

    void EggHatch()
    {
        hasHatched = true;
        dataPersistenceManager.gameData.gameStart = DateTime.UtcNow;
        SceneManager.LoadScene("BabyIdleScene");
    }

}
