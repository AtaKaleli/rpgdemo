using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectables : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<ICollectable>()?.Collected();
    }
}
