using UnityEngine;

public class NeedsManagement : MonoBehaviour
{
    private ShowNeeds showNeeds;
    public Animator petAnimator;
    public bool isSad;
    public GameObject pettingAnim;
    public GameObject pet;

    private void Awake() {
        pettingAnim.SetActive(false);
        // dirtyAnim.SetActive(false);
        showNeeds = pet.GetComponent<ShowNeeds>();

    }
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

}
