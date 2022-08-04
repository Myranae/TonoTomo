using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystem;
using UnityEngine.UI;

public class SettingsUIController : MonoBehaviour
{
    [SerializeField] private GameObject soundOn;
    [SerializeField] private GameObject soundOff;
    [SerializeField] private AudioClip bckgrndMusic;
    [SerializeField] private AudioSource audioSource;
    public bool muted;


    void TurnOffSound()
    {
        soundOn.SetActive(false);
        soundOff.SetActive(true);
        // audioSource.clip = bckgrndMusic;
        audioSource.Pause();
        muted = true;
    }

    void TurnOnSound()
    {
        soundOn.SetActive(true);
        soundOff.SetActive(false);
        // audioSource.clip = bckgrndMusic;
        audioSource.Play();
        muted = false;
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
