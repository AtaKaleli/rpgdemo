using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponSO : ScriptableObject
{
    public GameObject weaponPref;
    public float weaponCooldown;
    public int damageAmount;
    public int weaponRange;
}
