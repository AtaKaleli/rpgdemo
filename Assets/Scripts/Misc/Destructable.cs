using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    
    [SerializeField] private GameObject deathVFX;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<DamageSource>() != null)
        {
            GetComponent<PickUpSpawner>().Spawn();
            Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
