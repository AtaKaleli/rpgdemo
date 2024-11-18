using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public string SpawnGate { get; private set; }
    public static SceneManagement instance;



    private void Awake()
    {
        if(instance != null && this.gameObject != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }


        DontDestroyOnLoad(this);
    }

    public void SetPlayerSpawnPosition(string spawnGate)
    {
        this.SpawnGate = spawnGate;
    }

    

}
