using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EggController : MonoBehaviour
{
    public Animator eggAnimator;
    public float incubationTimeLeft;
    private GameObject pettingAnim;

    private void Start() 
    {
        pettingAnim = transform.GetChild(1).GameObject;
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
