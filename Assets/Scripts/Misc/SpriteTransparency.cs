using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteTransparency : TransparentDetection
{
    private SpriteRenderer sr;
    private Color defaultColor;


    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        defaultColor = sr.color;
    }

    
    
    protected override void SetTransperency(float alpha)
    {
        sr.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, alpha);
    }
}
