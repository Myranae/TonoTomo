using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public static float gameHourTimer;
    public float hourLength;

    public static TimingManager instance;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one TimingManager in Scene.");
    }

    private void Update() 
    {
        if(gameHourTimer <= 0)
        {
            gameHourTimer = hourLength;
        }
        else
        {
            gameHourTimer -= Time.deltaTime;
        }
    }
}
