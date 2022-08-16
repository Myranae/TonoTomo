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
        audioSource.Play();
        muted = false;
    }

    public void GetCurrentScene()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log(sceneName);
    }

    public void ReturnToActiveScene()
    {
        SceneManager.LoadScene(Level.PreviousLevel);
    }
}
