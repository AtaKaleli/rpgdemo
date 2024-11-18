using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string exitGateName;

    private ScreenFade screenFade;



    private void Awake()
    {
        screenFade = FindAnyObjectByType<ScreenFade>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            StartCoroutine(screenFade.FadeEffectCoroutine(0, 1, LoadScene));
            SceneManagement.instance.SetPlayerSpawnPosition(exitGateName);
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
