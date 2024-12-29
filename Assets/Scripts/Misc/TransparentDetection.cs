using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class TransparentDetection : MonoBehaviour
{

    [SerializeField] protected float maxAlpha = 1.0f;
    [SerializeField] protected float minAlpha = 0.8f;
    [SerializeField] protected float fadeTime = 0.5f;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            StartCoroutine(TrancparencyCouroutine(maxAlpha, minAlpha));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            StartCoroutine(TrancparencyCouroutine(minAlpha, maxAlpha));
        }
    }

    protected abstract void SetTransperency(float alpha);

    private IEnumerator TrancparencyCouroutine(float startAlpha, float targetAlpha)
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeTime);
            
            SetTransperency(newAlpha);

            yield return null;
        }

    }











}
