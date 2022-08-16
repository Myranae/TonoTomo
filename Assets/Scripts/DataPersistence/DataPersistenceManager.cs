using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
public class DataPersistenceManager : MonoBehaviour
{
    // [Header("Debugging")]
    // [SerializeField] private bool initializeDataIfNull = false;
    private UserActionController userActionController;
    private NeedsController needsController;

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;
    public GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }

    private void Awake() 
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
    }

    private void OnEnable() 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable() 
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();

        LoadGame();
        
        Debug.Log("gameData.gamelastplayed onSceneLoaded: " + gameData.gameLastPlayed);

        if (scene.name == "BabyIdleScene")
        {
            userActionController = GameObject.FindWithTag("UAC GO").GetComponent<UserActionController>();

            if (gameData.isSleepingStat)
            {
                userActionController.GoToSleep();
            }
        }
    }

    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
        // if (scene.name != "Opening 2")
        // {
        //     Debug.Log("Saving on scene unload: " + scene.name);
        //     SaveGame();
        // }
        // else
        // {
        //     Debug.Log("Not saving when unloading opening.");
        // }
        Debug.Log("This is OnSceneUnloaded; game saved");
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        // if (this.gameData == null && initializeDataIfNull)
        // {
        //     NewGame();
        // }

        if (this.gameData == null)
        {
            Debug.Log("No data was found. A new game needs to be started before data can be loaded.");
            return;
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame() 
    {
        if (this.gameData == null)
        {
            Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
            return;
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        // Debug.Log(Application.persistentDataPath);
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        needsController = GameObject.FindWithTag("Pet").GetComponent<NeedsController>();
        needsController.lastTimePlayed = DateTime.UtcNow;
        Debug.Log("Game last played on quit: " + needsController.lastTimePlayed);  //correct time
        Debug.Log("Game last played on quit: " + gameData.gameLastPlayed); //incorrect time
        SaveGame();
        Debug.Log("Game last played on quit after save: " + gameData.gameLastPlayed); 

    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        return gameData != null;
    }
}
