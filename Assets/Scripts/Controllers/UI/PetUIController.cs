using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetUIController : MonoBehaviour
{
    public static PetUIController instance;
    public EggController eggController;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one PetUIController in the Scene.");
    }

    public void HatchFaster()
    {
        if (eggController.incubationTimeLeft > 0)
        {
            eggController.ShowPetting();
            eggController.incubationTimeLeft -= 5;
        }
    }
}
