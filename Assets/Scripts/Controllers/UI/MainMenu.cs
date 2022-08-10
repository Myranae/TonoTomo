using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnNewGameClicked()
    {
        DataPersistenceManager.instance.NewGame();
    }

    public void onLoadGameClicked()
    {
        DataPersistenceManager.instance.LoadGame();
    }

    public void onSaveGameClicked()
    {
        DataPersistenceManager.instance.SaveGame();
    }
}
