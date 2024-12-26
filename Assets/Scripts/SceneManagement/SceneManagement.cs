using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public string SpawnGate { get; private set; }
    public static SceneManagement instance;

    private ScreenFade screenFade;

    


    private void Awake()
    {
        if(instance != null && this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this);
        screenFade = FindAnyObjectByType<ScreenFade>();
    }

    
    public void SetPlayerSpawnPosition(string spawnGate)
    {
        this.SpawnGate = spawnGate;
    }

    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        StartCoroutine(screenFade.FadeEffectCoroutine(1f, 0f));
    }
    

    

}
