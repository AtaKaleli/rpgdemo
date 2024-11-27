using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    protected int damageAmount;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<IDamageable>() != null)
        {
            IDamageable damage = collision.GetComponent<IDamageable>();
            damage.Damage(damageAmount);
        }
    }

    protected void SetDamageAmount(int damageAmount)
    {
        this.damageAmount = damageAmount;
    }

}
