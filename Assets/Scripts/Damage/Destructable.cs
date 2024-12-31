using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    
    [SerializeField] private GameObject deathVFX;


    private PickUpSpawner pickUpSpawner;


    private void Start()
    {
        pickUpSpawner = GetComponent<PickUpSpawner>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<DamageSource>() != null)
        {
            pickUpSpawner.Spawn();
            Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
