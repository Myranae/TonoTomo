using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EggController : MonoBehaviour
{
    public Animator eggAnimator;
    private float incubationTimeLeft;
    public GameObject pettingAnim;

    private void Awake() 
    {
        incubationTimeLeft = 30;
    }

    private void Start() 
    {
        pettingAnim.SetActive(false);
    }

    void Update()
    {
        CheckIncubationTime();
    }

    public void ShowPetting()
    {
        pettingAnim.SetActive(true);
    }

    public void StopPetting()
    {
        pettingAnim.SetActive(false);
    }

    private void CheckIncubationTime()
    {
        if(incubationTimeLeft > 0)
        {
            incubationTimeLeft -= Time.deltaTime;
        }
        else eggAnimator.SetBool("timeToHatch", true);
    }

    void EggHatch()
    {
        SceneManager.LoadScene(2);
    }


}
