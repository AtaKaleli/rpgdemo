using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : BaseProjectile
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            Destroy(this.gameObject);
            //Instantiate(deathVFX, transform.position, Quaternion.identity);
        }
    }
}
