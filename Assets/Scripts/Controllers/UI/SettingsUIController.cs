using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}
