using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private WeaponSO weapon;


    public WeaponSO GetWeapon()
    {
        return weapon;
    }
}
