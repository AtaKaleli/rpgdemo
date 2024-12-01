using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration;



    public IEnumerator FadeEffectCoroutine(float startAlpha, float desiredAlpha, Action method = null)
    {
        GameManager.instance.CurrentState = GameManager.GameState.Freezed;
        float elapsedTime = 0;

        while(elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, desiredAlpha, elapsedTime / fadeDuration);

            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, newAlpha);

            yield return null;
        }

        method?.Invoke();
        yield return new WaitForSeconds(0.25f);
        GameManager.instance.CurrentState = GameManager.GameState.Playing;
    }

}
