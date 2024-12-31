using UnityEngine;

public class PlayerHealth : BaseHealth
{

    //extra logic "screen shake" will be implemented later on
    

    protected override void ReceiveDamage(Collider2D collision)
    {
        if(collision.GetComponent<EnemyDamageSource>() != null)
        {
            EnemyDamageSource enemyDamage = collision.GetComponent<EnemyDamageSource>();
            KnockbackController(enemyDamage.transform);
        }
    }
}
