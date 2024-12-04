using UnityEngine;

public class BaseHealth : MonoBehaviour, IDamageable
{
    [SerializeField] protected int startingHealth;
    [SerializeField] protected GameObject deathVFX;

    protected int currentHealth;



    protected virtual void Start()
    {
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
}
