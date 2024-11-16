using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransparentDetection : MonoBehaviour
{
    private SpriteRenderer sr;
    private Tilemap tilemap;
    private Color defaultSrColor;
    private Color defaultTileColor;

    [SerializeField] private float maxAlpha = 1.0f;
    [SerializeField] private float minAlpha = 0.5f;
    [SerializeField] private float fadeTime = 0.5f;



    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        tilemap = GetComponent<Tilemap>();
        NullChecks();
    }

    private void NullChecks()
    {
        if (sr != null)
            defaultSrColor = sr.color;
        if (tilemap != null)
            defaultTileColor = tilemap.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            if(sr != null)
                StartCoroutine(TrancparencyCouroutine(sr,maxAlpha,minAlpha));
            else if(tilemap != null)
                StartCoroutine(TrancparencyCouroutine(tilemap, maxAlpha, minAlpha));

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            if (sr != null)
                StartCoroutine(TrancparencyCouroutine(sr, minAlpha, maxAlpha));
            else if (tilemap != null)
                StartCoroutine(TrancparencyCouroutine(tilemap, minAlpha, maxAlpha));
        }
    }

    private IEnumerator TrancparencyCouroutine(SpriteRenderer sr,float startAlpha, float targetAlpha)
    {
        float elapsedTime = 0;

        while(elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeTime);
            sr.color = new Color(defaultSrColor.r, defaultSrColor.g, defaultSrColor.b, newAlpha);
            
            yield return null;
        }

    }

    private IEnumerator TrancparencyCouroutine(Tilemap tilemap, float startAlpha, float targetAlpha)
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeTime);
            tilemap.color = new Color(defaultTileColor.r, defaultTileColor.g, defaultTileColor.b, newAlpha);

            yield return null;
        }

    }


}
