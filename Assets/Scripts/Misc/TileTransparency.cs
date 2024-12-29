using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileTransparency : TransparentDetection
{
    private Tilemap tile;
    private Color defaultColor;


    private void Start()
    {
        tile = GetComponent<Tilemap>();
        defaultColor = tile.color;
    }

    
    

    protected override void SetTransperency(float alpha)
    {
        tile.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, alpha);
    }

}
