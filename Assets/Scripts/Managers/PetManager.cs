using UnityEngine;

public class PetManager : MonoBehaviour
{
    public PetController pet;
    public float petMoveTimer, originalPetMoveTimer;
    public Transform[] waypoints;

    private void Awake() 
    {
        originalPetMoveTimer = petMoveTimer;
    }
    private void Update() 
    {
        if(petMoveTimer > 0)
        {
            petMoveTimer -= Time.deltaTime;
        }
        else
        {
            MovePetToRandomWaypoint();
            petMoveTimer = Random.Range(1,6);
        }

        // RandomMoveTime();
    }

    private void MovePetToRandomWaypoint()
    {   
        int randomWaypoint = Random.Range(0, waypoints.Length);
        pet.Move(waypoints[randomWaypoint].position);
    }

    // private void RandomMoveTime()
    // {
    //     int randomTime = Random.Range(2,5);
    //     originalPetMoveTimer = randomTime;

    // }
}
