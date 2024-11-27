using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSource : DamageSource
{
    [SerializeField] private WeaponSO weapon;

    private void Start()
    {
        SetDamageAmount(weapon.damageAmount);
    }
}
