using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    [SerializeField] private string entranceGateName;


    private void Start()
    {

        if(entranceGateName == SceneManagement.instance.SpawnGate)
        {
            PlayerController.instance.gameObject.transform.position = this.transform.position;
        }
    }
}
