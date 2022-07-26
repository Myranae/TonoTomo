using UnityEngine;
using UnityEngine.SceneManagement;

public class PetManager : MonoBehaviour
{
    public PetController pet;
    public float petMoveTimer, originalPetMoveTimer;
    public Transform[] waypoints;
    public static PetManager instance;


    private void Awake() 
    {
        originalPetMoveTimer = petMoveTimer;
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one PetManager in the Scene");
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
    }

    private void MovePetToRandomWaypoint()
    {   
        int randomWaypoint = Random.Range(0, waypoints.Length);
        pet.Move(waypoints[randomWaypoint].position);
    }

    public void Die()
    {
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadScene("PetDeath");
    }
}
