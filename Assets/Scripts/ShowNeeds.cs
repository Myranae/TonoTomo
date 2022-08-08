using UnityEngine;

public class ShowNeeds : MonoBehaviour
{
    public NeedsManagement needsManagement;
    // public GameObject needsActions;
    public Animator anim;
    public bool hideNeedBubbles;



    // private void Update() 
    // {
    //     if (anim.GetCurrentAnimatorStateInfo(0).IsName("Bath") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
    //     {
    //     needsManagement.hideNeedBubbles = false;
    //     }

    // }
    public void ShowNeedsBubbles()
    {
        Debug.Log("Trying to change hideNeedBubbles1");
        hideNeedBubbles = false;
        Debug.Log("Trying to change hideNeedBubbles2");
    }
}
