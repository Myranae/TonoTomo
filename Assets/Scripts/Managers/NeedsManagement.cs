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

    public void Sad()
    {
        petAnimator.SetBool("isSad", true);
        isSad = true;
    }

    public void notSad()
    {
        petAnimator.SetBool("isSad", false);
        isSad = false;
    }

    public void Heal()
    {
        showNeeds.hideNeedBubbles = true;
        petAnimator.SetTrigger("Heal");
    }

    public void Eat()
    {
        showNeeds.hideNeedBubbles = true;
        petAnimator.SetTrigger("Eat");
    }

    public void Drink()
    {
        showNeeds.hideNeedBubbles = true;
        petAnimator.SetTrigger("Drink");
    }

    public void Bath()
    {
        showNeeds.hideNeedBubbles = true;
        petAnimator.SetTrigger("Bath");
    }

}
