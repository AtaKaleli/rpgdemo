using UnityEngine;

public class PlayerHealth : BaseHealth
{
    private Knockback knockback;



    private void Awake()
    {
        knockback = GetComponent<Knockback>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyDamageSource>() != null)
        {
            EnemyDamageSource enemyDamage = collision.GetComponent<EnemyDamageSource>();
            KnockbackController(enemyDamage.transform);
        }
    }

    private void KnockbackController(Transform damageSource)
    {
        if (!knockback.CanBeKnocked)
            return;

        knockback.GetKnockedBack(damageSource);
        StartCoroutine(knockback.KnockbackCoroutine());
    }



}
