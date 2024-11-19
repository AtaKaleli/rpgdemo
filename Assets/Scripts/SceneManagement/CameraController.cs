using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


   
    private CinemachineVirtualCamera virtualCam;


    private void Awake()
    {
        virtualCam = FindAnyObjectByType<CinemachineVirtualCamera>();
        virtualCam.Follow = PlayerController.instance.transform;
    }

    
}
