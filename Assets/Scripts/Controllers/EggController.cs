using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EggController : MonoBehaviour
{
    // private DateTime startDateTime;
    public Animator eggAnimator;

    void Start()
    {
        // if(startDateTime == null)
        // {
        //     startDateTime = DateTime.UtcNow;
        // }
        // bool timeToHatch = false;

    }

    void Update()
    {
        if(Time.time > 30)
        {
            eggAnimator.SetBool("timeToHatch", true);
            

        }
    }

    void EggHatch()
    {
        SceneManager.LoadScene(2);
    }
}
