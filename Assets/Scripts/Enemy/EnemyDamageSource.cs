using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSource : DamageSource
{
    [SerializeField] private EnemySO enemy;




    private void Start()
    {
        SetDamageAmount(enemy.damageAmount);
    }
}
