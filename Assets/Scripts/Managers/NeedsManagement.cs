using UnityEngine;

public class NeedsManagement : MonoBehaviour
{
    private ShowNeeds showNeeds;
    public Animator petAnimator;
    public bool isSad;
    public GameObject pettingAnim;
    public GameObject pet;
    // public bool hideNeedBubbles;

    private void Awake() {
        pettingAnim.SetActive(false);
        // hideNeedBubbles = false;
        // dirtyAnim.SetActive(false);
        showNeeds = pet.GetComponent<ShowNeeds>();

    }

    // private void Update() 
    // {
    //     if (petAnimator.GetCurrentAnimatorStateInfo(0).IsName("Bath") && petAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
    //     {
    //     hideNeedBubbles = false;
    //     }
    // }
    public void Idle()
    {
        petAnimator.SetTrigger("Idle");
    }

    public void Happy()
    {
        petAnimator.SetTrigger("Happy");
    }

    public void Hungry()
    {
        petAnimator.SetTrigger("Hungry");
    }

    public void Sad()
    {
        // petAnimator.SetTrigger("Sad");
        petAnimator.SetBool("isSad", true);
        isSad = true;
    }

    public void notSad()
    {
        // petAnimator.SetTrigger("Sad");
        petAnimator.SetBool("isSad", false);
        isSad = false;
        // Idle();
    }

    public void Tired()
    {
        petAnimator.SetTrigger("Tired");
    }

    public void Thirsty()
    {
        petAnimator.SetTrigger("Thirsty");
    }

    public void Eat()
    {
        petAnimator.SetTrigger("Eat");
    }

    public void Drink()
    {
        petAnimator.SetTrigger("Drink");
    }

    public void Dirty()
    {
        petAnimator.SetTrigger("Dirty");
    }

    public void Bath()
    {
        showNeeds.hideNeedBubbles = true;
        petAnimator.SetTrigger("Bath");
    }

    public void Sleep()
    {
        petAnimator.SetTrigger("Sleep");
    }

    // public void ShowNeeds()
    // {
    //     Debug.Log("Trying to change hideNeedBubbles1");
    //     hideNeedBubbles = false;
    //     Debug.Log("Trying to change hideNeedBubbles2");
    // }

}
