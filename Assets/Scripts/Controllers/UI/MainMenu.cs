using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{   
    public DataPersistenceManager dataPersistenceManager;

    // public GameObject lightsOff, petAction, medicineAction, bathAction, drinkAction, foodAction;
    // private ShowNeeds showNeeds;
    public UserActionController userActionController;
    // public GameObject pet;

    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;

    private void Start() 
    {
        if (SceneManager.GetActiveScene().name == "Opening 2")
        {
            if(!DataPersistenceManager.instance.HasGameData())
            {
                continueGameButton.interactable = false;
            }
        }

        // showNeeds = GameObject.FindWithTag("Pet").GetComponent<ShowNeeds>();
    }    

    public void OnNewGameClicked()
    {
        DisableMenuButtons();
        DataPersistenceManager.instance.NewGame();
        // SceneManager.LoadSceneAsync("EggIdleScene");
        SceneManager.LoadScene("EggIdleScene");

    }

    public void OnLoadGameClicked()
    {   
        DisableMenuButtons();
        DataPersistenceManager.instance.LoadGame();
        Debug.Log("Load Game clicked; game loaded.");
        // SceneManager.LoadSceneAsync(dataPersistenceManager.gameData.lastScene);
        SceneManager.LoadScene(dataPersistenceManager.gameData.lastScene);

        // if (dataPersistenceManager.gameData.isSleepingStat)
        // {
        //     if (dataPersistenceManager.gameData.lastScene == "EggIdleScene")
        //     {
        //         userActionController.EggGoToSleep();
        //     }
        //     else if (dataPersistenceManager.gameData.lastScene == "BabyIdleScene")
        //     {
        //         userActionController.GoToSleep();
        //     }
        // }
    }

    public void OnSaveGameClicked()
    {
        DataPersistenceManager.instance.SaveGame();
    }

    public void OnExitGameClicked()
    {
        Application.Quit();
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }

}
