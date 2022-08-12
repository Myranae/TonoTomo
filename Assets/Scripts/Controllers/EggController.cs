using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class EggController : MonoBehaviour, IDataPersistence
{   
    // public ButtonController buttonController;
    // private GameObject dpm;
    public DataPersistenceManager dataPersistenceManager;
    public Animator eggAnimator;
    public float incubationTimeLeft;
    public float actualIncTime; 
    public GameObject pettingAnim;
    public bool hasHatched;
    public UserActionController userActionController;
    public GameObject lightsOff;
    // public static EggController instance;

    private void Awake() 
    {
        pettingAnim.SetActive(false);

        // dpm = GameObject.FindWithTag("DPM");
        // dataPersistenceManager = dpm.GetComponent<DataPersistenceManager>();
    }

    private void Start() 
    {
        // dpm = GameObject.FindWithTag("DPM");
        // dataPersistenceManager = dpm.GetComponent<DataPersistenceManager>();
        // incubationTimeLeft = dataPersistenceManager.gameData.incubationTimeLeftStat;
        // Debug.Log("This is incubationTimeLeft at Start: " + incubationTimeLeft);

        // actualIncTime = GameObject.FindWithTag("Egg").GetComponent<EggController>().incubationTimeLeft;
    }

    void Update()
    {
        CheckIncubationTime();
        // dpm = GameObject.FindWithTag("DPM");
        // dataPersistenceManager = dpm.GetComponent<DataPersistenceManager>();
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

    // public void ShowPetting()
    // {
    //     pettingAnim.SetActive(true);
    //     pettingAnim.SetActive(true);
    // }

    // public void StopPetting()
    // {   
    //     if (incubationTimeLeft > 0)
    //     {
    //         incubationTimeLeft -= 10;
            
    //         Debug.Log("After pet, this is incubationTimeLeft: " + incubationTimeLeft);

    //         pettingAnim.SetActive(false);
    //     }
    // }

    private void CheckIncubationTime()
    {
        // Debug.Log("This is incTime on update: " + incubationTimeLeft);
        if (incubationTimeLeft > 0)
        {
            incubationTimeLeft -= Time.deltaTime;
        }
        else if (incubationTimeLeft <= 0)
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
