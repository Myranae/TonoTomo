using UnityEngine;

public class NeedController : MonoBehaviour
{
    public GameObject pet;
    private Vector3 destination;
    public float speed;

    private void Update() 
    {
        if(Vector3.Distance(transform.position, destination) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed*Time.deltaTime);
        }
    }

    public void Move(Vector3 destination)
    {
        this.destination = pet.transform.position;
    }
}
