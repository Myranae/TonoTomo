using UnityEngine;

public class PetController : MonoBehaviour
{
    // public Animator petAnimator;
    private Vector3 destination;
    public float speed;
    // public bool isSad;
    // public GameObject hungryAnim;

    private void Update() 
    {
        if(Vector3.Distance(transform.position, destination) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed*Time.deltaTime);
        }

    }

    public void Move(Vector3 destination)
    {
        this.destination = destination;
    }

    // public void Idle()
    // {
    //     petAnimator.SetTrigger("Idle");
    // }

    // public void Happy()
    // {
    //     petAnimator.SetTrigger("Happy");
    // }

    // public void Hungry()
    // {
    //     petAnimator.SetTrigger("Hungry");
    // }

    // public void Sad()
    // {
    //     // petAnimator.SetTrigger("Sad");
    //     petAnimator.SetBool("isSad", true);
    //     isSad = true;
    // }

    // public void notSad()
    // {
    //     // petAnimator.SetTrigger("Sad");
    //     petAnimator.SetBool("isSad", false);
    //     isSad = false;
    //     Idle();
    // }

    // public void Tired()
    // {
    //     petAnimator.SetTrigger("Tired");
    // }

    // public void Thirsty()
    // {
    //     petAnimator.SetTrigger("Thirsty");
    // }

    // public void Eat()
    // {
    //     petAnimator.SetTrigger("Eat");
    // }

    // public void Drink()
    // {
    //     petAnimator.SetTrigger("Drink");
    // }

    // public void Dirty()
    // {
    //     petAnimator.SetTrigger("Dirty");
    // }

    // public void Bath()
    // {
    //     petAnimator.SetTrigger("Bath");
    // }

    // public void Sleep()
    // {
    //     petAnimator.SetTrigger("Sleep");
    // }

}
