using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EggController : MonoBehaviour
{
    public Animator eggAnimator;
    public float incubationTimeLeft;

    void Update()
    {
        CheckIncubationTime();
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
