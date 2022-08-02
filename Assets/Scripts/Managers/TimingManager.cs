using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public static float gameHourTimer;
    public float hourLength;

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
