using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EggController : MonoBehaviour, IDataPersistence
{   
    // public DataPersistenceManager dataPersistenceManager;
    public Animator eggAnimator;
    public float incubationTimeLeft;
    public float actualIncTime; 
    public GameObject pettingAnim;
    public bool hasHatched;
    public UserActionController userActionController;
    public GameObject lightsOff;
    public Button lightsAction;
    public Button petAction;

    private void Awake() 
    {
        pettingAnim.SetActive(false);
    }

    private void Start() {
        // dataPersistenceManager = GameObject.FindGameObjectWithTag("DPM").GetComponent<DataPersistenceManager>();
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
    }

    private void CheckIncubationTime()
    {
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
            lightsAction.interactable = false;
            petAction.interactable = false;
            pettingAnim.SetActive(false);
            eggAnimator.SetBool("timeToHatch", true);
        }
    }

    void EggHatch()
    {
        // NeedsController.instance.timeStartedPlaying = DateTime.UtcNow;
        // tried to reference timestartedplaying but it's not loaded when this script is active

        // dataPersistenceManager.gameData.gameStart = DateTime.UtcNow;

        hasHatched = true;
        SceneManager.LoadScene("BabyIdleScene");
    }
}
