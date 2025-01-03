using UnityEngine;

public class EnemyHealth : BaseHealth
{
    


    protected override void ReceiveDamage(Collider2D collision)
    {
        if (collision.GetComponent<PlayerDamageSource>() != null)
        {
            PlayerDamageSource playerDamage = collision.GetComponent<PlayerDamageSource>();
            KnockbackController(playerDamage.transform);
        }
    }
    protected override void Die()
    {
        GetComponent<PickUpSpawner>().Spawn();
    }

}
