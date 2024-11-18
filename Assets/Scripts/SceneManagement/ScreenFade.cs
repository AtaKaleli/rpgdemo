using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration;


    private void Start()
    {
        StartCoroutine(FadeEffectCoroutine(1f, 0f));
    }


    public IEnumerator FadeEffectCoroutine(float startAlpha, float desiredAlpha, Action method = null)
    {
        PlayerController.instance.CanMove = false;
        float elapsedTime = 0;

        while(elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, desiredAlpha, elapsedTime / fadeDuration);

            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, newAlpha);

            yield return null;
        }

        PlayerController.instance.CanMove = true;
        method?.Invoke();
    }
}
