using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{

    [SerializeField] private GameObject bushDeathVFX;
    [SerializeField] private Transform VFXParent;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<DamageSource>() != null)
        {
            Instantiate(bushDeathVFX, transform.position, Quaternion.identity, VFXParent);
            Destroy(this.gameObject);
        }
    }
}
