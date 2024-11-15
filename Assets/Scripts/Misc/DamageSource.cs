using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    
    [SerializeField] private int damageAmount;
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyHealth>()?.TakeDamage(damageAmount);
        collision.GetComponent<PlayerHealth>()?.TakeDamage(damageAmount);
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<IDamageable>() != null)
        {
            IDamageable damage = collision.GetComponent<IDamageable>();
            damage.Damage(damageAmount);
        }
    }

}
