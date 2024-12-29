using UnityEngine;

public abstract class BaseHealth : MonoBehaviour, IDamageable
{
    [SerializeField] protected int startingHealth;
    [SerializeField] protected GameObject deathVFX;

    protected int currentHealth;
    protected Knockback knockback;


    protected virtual void Start()
    {
        knockback = GetComponent<Knockback>();
        currentHealth = startingHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        DetectHeath();
    }

    protected virtual void DetectHeath()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DamageSource>() != null)
        {
            DetectDamage(collision); 
        }
    }

    protected abstract void DetectDamage(Collider2D collision);

    protected void KnockbackController(Transform damageSource)
    {
        if (!knockback.CanBeKnocked)
            return;

        knockback.GetKnockedBack(damageSource);
        StartCoroutine(knockback.KnockbackCoroutine());
    }


}
