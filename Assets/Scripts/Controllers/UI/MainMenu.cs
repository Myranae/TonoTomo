using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{   
    public DataPersistenceManager dataPersistenceManager;

    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueGameButton;

    private void Start() 
    {
        if(!DataPersistenceManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
        }
    }    
    public void OnNewGameClicked()
    {
        DisableMenuButtons();
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync("EggIdleScene");

    }

    public void OnLoadGameClicked()
    {   
        DisableMenuButtons();
        DataPersistenceManager.instance.LoadGame();
        Debug.Log("Last scene saved: " + dataPersistenceManager.gameData.lastScene);
        SceneManager.LoadSceneAsync(dataPersistenceManager.gameData.lastScene);
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
