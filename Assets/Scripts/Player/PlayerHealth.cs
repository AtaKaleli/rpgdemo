using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public void Damage(int damage)
    {
        print("player took damage: " + damage);
    }

 
}
