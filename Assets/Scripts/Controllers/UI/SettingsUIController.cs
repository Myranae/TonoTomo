using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsUIController : MonoBehaviour
{
    [SerializeField] private GameObject soundOn;
    [SerializeField] private GameObject soundOff;
    [SerializeField] private AudioClip bckgrndMusic;
    [SerializeField] private AudioSource audioSource;
    public bool muted;
    [HideInInspector] public Scene currentScene;
    private string sceneName;


    void Start()
    {
        TurnOnSound();
    }


    void Update()
    {
        // Scene newScene = SceneManager.GetActiveScene();
        // if(newScene.name != "Menu" && currentScene != newScene)
        // {
        //     currentScene = newScene;
        // }
    }

    public void TurnOffSound()
    {
        soundOn.SetActive(false);
        soundOff.SetActive(true);
        audioSource.Pause();
        muted = true;
    }

    public void TurnOnSound()
    {
        soundOn.SetActive(true);
        soundOff.SetActive(false);
        // audioSource.clip = bckgrndMusic;
        audioSource.Play();
        muted = false;
    }

    public void GetCurrentScene()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Debug.Log("Newly current scene is: " + sceneName);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log(sceneName);
    }

    public void ReturnToActiveScene()
    {
        // Debug.Log("Current scene is: " + currentScene.name);
        Debug.Log("Previous scene name is: " + Level.PreviousLevel);
        SceneManager.LoadScene(Level.PreviousLevel);
    }
}
