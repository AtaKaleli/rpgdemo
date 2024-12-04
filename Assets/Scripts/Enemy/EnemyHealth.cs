using UnityEngine;

public class EnemyHealth : BaseHealth
{
    private Knockback knockback;




    private void Awake()
    {
        knockback = GetComponent<Knockback>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerDamageSource>() != null)
        {
            print(collision);
            PlayerDamageSource playerDamage = collision.GetComponent<PlayerDamageSource>();
            KnockbackController(playerDamage.transform);
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
