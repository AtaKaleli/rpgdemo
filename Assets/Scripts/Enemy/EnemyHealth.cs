using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int startingHealth;

    private int currentHealth;
    private Knockback knockback;

    [SerializeField] private GameObject deathVFX;
    [SerializeField] private Transform deathVFXParent;



    private void Awake()
    {
        knockback = GetComponent<Knockback>();
    }


    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void Damage(int damage)
    {
        if (!knockback.CanBeKnocked)
            return;

        StartCoroutine(knockback.KnockbackCoroutine());
        knockback.GetKnockedBack(PlayerController.instance.transform);
        currentHealth -= damage;
        DetectHeath();
    }
    

    private void DetectHeath()
    {
        print(currentHealth);
        if(currentHealth <= 0)
        {
            Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    /*
    public void TakeDamage(int damage)
    {
        if (!knockback.CanBeKnocked)
            return;

        StartCoroutine(knockback.KnockbackCoroutine());
        knockback.GetKnockedBack(PlayerController.instance.transform);
        currentHealth -= damage;
        DetectHeath();
    }*/
}
