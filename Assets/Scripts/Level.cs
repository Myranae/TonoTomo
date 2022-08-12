using UnityEngine;

public class Level : MonoBehaviour
{
    public static string PreviousLevel { get; private set; }
    
    private void OnDestroy()
    {
        PreviousLevel = gameObject.scene.name;
    }
    
    private void Start()
    {
        Debug.Log(Level.PreviousLevel);  // use this in any level to get the last level.
    }
}