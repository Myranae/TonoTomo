using UnityEngine;
using UnityEngine.SceneManagement;

public class StopPetting : MonoBehaviour
{
    public GameObject pettingAnim;
    public EggController eggController;
    public UserActionController userActionController;

    public void StopPetting2()
    {   
        if (SceneManager.GetActiveScene().name == "EggIdleScene")
        {
            if (eggController.incubationTimeLeft > 0)
            {
                eggController.incubationTimeLeft -= 10;
                pettingAnim.SetActive(false);
            }
        }

        if (SceneManager.GetActiveScene().name == "BabyIdleScene")
        {
            pettingAnim.SetActive(false);
            userActionController.IncreaseHappiness();
        }
    }

}
