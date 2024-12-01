using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum GameState { Playing, Freezed }

    public GameState CurrentState { get; set; } = GameState.Playing;





    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public bool AllowPlayerActions()
    {
        return CurrentState == GameState.Playing;
    }
}
