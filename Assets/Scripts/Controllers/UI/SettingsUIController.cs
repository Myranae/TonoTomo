using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsUIController : MonoBehaviour
{
    [SerializeField] private GameObject soundOn;
    [SerializeField] private GameObject soundOff;
    [SerializeField] private AudioClip bckgrndMusic;
    [SerializeField] private AudioSource audioSource;
    public bool muted;


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

    void Start()
    {
        TurnOnSound();
    }


    void Update()
    {
        
    }

    public void ChangeScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
}
