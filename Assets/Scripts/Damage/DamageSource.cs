using UnityEngine;

public class DamageSource : MonoBehaviour
{
    protected int damageAmount;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamageable>() != null)
        {
            IDamageable damage = collision.GetComponent<IDamageable>();
            damage.TakeDamage(damageAmount);
        }
    }

    protected void SetDamageAmount(int damageAmount)
    {
        this.damageAmount = damageAmount;
    }



}
