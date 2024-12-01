using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Canvas : MonoBehaviour
{
    public static UI_Canvas instance;


    private void Awake()
    {
        if (instance != null && this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this);
    }
}
