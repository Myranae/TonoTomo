using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadScene("EggIdleScene");
    }
}
